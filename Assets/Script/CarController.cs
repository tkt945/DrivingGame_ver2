﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using UnityEngine.UI;
using System.Threading;


public class CarController : MonoBehaviour
{
    public SerialPort sp = new SerialPort("COM3", 74880);

    public GameObject CarSteering;  //方向盤
    public AudioSource audioSource1;  //引擎聲音1
    public AudioSource audioSource2;  //引擎聲音2
    public Text speedometer; //面板參考

    //輸入裝置的input
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    //本來是寫給自動駕駛但後來沒用到
    private List<Transform> nodes;
    private int currentNode = 0;
    public Transform path;
    public float CheckpointDistance;

    //輪胎 F:front R:rear D:driver P:passenger
    public WheelCollider W_FD, W_FP, W_RD, W_RP;
    public Transform T_FD, T_FP, T_RD, T_RP;
    public Vector3 centreOfMass;
    
    //參數
    public float maxSteerAngle;
    public float maxSpeed;
    public float motorForce;
    public int Gear;

    //擷取資料(值會變動)
    int i;
    float speed, lastVelocity, acceleration, timer_a;
    double R, centri_acce;

    double acce1; //前後的坐墊位移值
    double acce2; //左右的坐墊位移值
    double tilt; //傾斜角
    string info; //傳送給Arduino的字串


    private void Start()
    {
        sp.Open();
        GetComponent<Rigidbody>().centerOfMass = centreOfMass;

        // 本來是寫給自動駕駛但後來沒用到
        Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != path.transform)
            {
                nodes.Add(pathTransform[i]);
            }
        }
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        EngineSound();
        SendInfo();

        //ApplySteer(); 本來是寫給自動駕駛但後來沒用到
        //CheckWayPointDistance(); 本來是寫給自動駕駛但後來沒用到   
    }

    //取得輸入值
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal"); //方向盤的輸入
        m_verticalInput = Input.GetAxis("Vertical"); //油門煞車的輸入

        //汽車位置變換
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            transform.position = new Vector3(65, -8, 243);
            transform.rotation = new Quaternion(0, 8, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            transform.position = new Vector3(-290, -214, 30);
            transform.rotation = new Quaternion(0, 8, 0, 0);
        }

        //D檔R檔切換
        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            Gear = 1;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            Gear = 0;
        }
    }

    //方向盤控制輪胎轉角
    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        W_FD.steerAngle = m_steeringAngle;
        W_FP.steerAngle = m_steeringAngle;

        //轉彎半徑
        if (W_FP.steerAngle < 0.005 && W_FP.steerAngle > -0.005)
        {
            R = Mathf.Infinity;
        }
        else
        {
            R = 2.9 / Math.Sin(W_FP.steerAngle / 180 * Math.PI);
        }
    }

    //油門煞車控制車輛動力
    private void Accelerate()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude; //unit: m/s  transfer to km/h *3.6

        //加速
        if (m_verticalInput > 0 && Gear == 1)
        {
            W_FD.motorTorque = m_verticalInput * motorForce * (maxSpeed - speed * 3.6f + 20) / maxSpeed;
            W_FP.motorTorque = m_verticalInput * motorForce * (maxSpeed - speed * 3.6f + 20) / maxSpeed;
            W_RD.motorTorque = m_verticalInput * motorForce * (maxSpeed - speed * 3.6f + 20) / maxSpeed;
            W_RP.motorTorque = m_verticalInput * motorForce * (maxSpeed - speed * 3.6f + 20) / maxSpeed;
            W_FD.brakeTorque = 0;
            W_FP.brakeTorque = 0;
            W_RD.brakeTorque = 0;
            W_RP.brakeTorque = 0;
        }
        else if (m_verticalInput > 0 && Gear == 0)
        {
            W_FD.motorTorque = -1 * m_verticalInput * motorForce / 3;
            W_FP.motorTorque = -1 * m_verticalInput * motorForce / 3;
            W_RD.motorTorque = -1 * m_verticalInput * motorForce / 3;
            W_RP.motorTorque = -1 * m_verticalInput * motorForce / 3;
            W_FD.brakeTorque = 0;
            W_FP.brakeTorque = 0;
            W_RD.brakeTorque = 0;
            W_RP.brakeTorque = 0;
        }

        //煞車
        else if (m_verticalInput < 0 )
        {
            W_FD.motorTorque = 0;
            W_FP.motorTorque = 0;
            W_RD.motorTorque = 0;
            W_RP.motorTorque = 0;
            W_FD.brakeTorque = -1.6f * m_verticalInput * motorForce;
            W_FP.brakeTorque = -1.6f * m_verticalInput * motorForce;
            W_RD.brakeTorque = -1.6f * m_verticalInput * motorForce;
            W_RP.brakeTorque = -1.6f * m_verticalInput * motorForce;
        }

        //漸停
        else
        {
            W_FD.motorTorque = 0;
            W_FP.motorTorque = 0;
            W_RD.motorTorque = 0;
            W_RP.motorTorque = 0;
            W_FD.brakeTorque = 100;
            W_FP.brakeTorque = 100;
            W_RD.brakeTorque = 100;
            W_RP.brakeTorque = 100;
        }
    }

    //呈現輪胎和方向盤的旋轉
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(W_FD, T_FD);
        UpdateWheelPose(W_FP, T_FP);
        UpdateWheelPose(W_RD, T_RD);
        UpdateWheelPose(W_RP, T_RP);

        CarSteering.transform.localEulerAngles = new Vector3(-20, 180, m_horizontalInput * 135);
    }
    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);
        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    //引擎聲
    void EngineSound()
    {
        float enginePitch = speed / 30 + 1;
        audioSource1.pitch = enginePitch;
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource2.Play();
    }

    
    // SendInfo: 傳送資料給Arduino
    private void SendInfo()
    {
        timer_a += Time.fixedDeltaTime;
        i++;
        if (i >= 10) //每10幀傳送
        {
            acceleration = (speed - lastVelocity) / timer_a; //計算加速度
            centri_acce = speed * speed / R; //計算向心加速度

            //計算1.坐墊前後位移值 2.坐墊左右位移值 3.傾斜角
            if (acceleration >= 0 && Gear == 1)
            {
                acce1 = Math.Pow((acceleration / 0.1172f), (1 / 1.7406f));
                if (acce1 > 9.64)
                {
                    acce1 = 9.64;
                }
                if (speed < 1)
                {
                    acce1 = 0;
                }
            }

            if (acceleration < 0 && Gear == 0)
            {
                acce1 = Math.Pow((-1 * acceleration / 0.1172f), (1 / 1.7406f));
                if (acce1 > 9.64)
                {
                    acce1 = 9.64;
                }
                if (speed < 1)
                {
                    acce1 = 0;
                }
            }

            if (acceleration < 0 && Gear == 1)
            {
                acce1 = -1 * Math.Pow((-1 * acceleration / 0.1148f), (1 / 1.8216f));
                if (acce1 < -9.18)
                {
                    acce1 = -9.18;
                }
                if (speed < 1)
                {
                    acce1 = 0;
                }
            }

            if (acceleration >= 0 && Gear == 0)
            {
                acce1 = -1 * Math.Pow((acceleration / 0.1148f), (1 / 1.8216f));
                if (acce1 < -9.18)
                {
                    acce1 = -9.18;
                }
                if (speed < 1)
                {
                    acce1 = 0;
                }
            }

            if (centri_acce >= 0)
            {
                acce2 = Math.Pow((centri_acce / 0.1272f), (1 / 1.6941f));
                if (acce2 > 9.11)
                {
                    acce2 = 9.11;
                }
            }

            if (centri_acce < 0)
            {
                acce2 = -1 * Math.Pow((-1 * centri_acce / 0.1243f), (1 / 1.7132f));
                if (acce2 < -9.2)
                {
                    acce2 = -9.2;
                }
            }

            tilt = GetComponent<Rigidbody>().rotation.eulerAngles.x;

            if (tilt > 300)
            {
                tilt = tilt - 360;
            }

            if (tilt >= 8)
            {
                tilt = 8;
            }

            if (tilt <= -8)
            {
                tilt = -8;
            }
            
            //傳給Arduino
            info = acce1.ToString("#0.00") + "," + acce2.ToString("#0.00") + "," + tilt.ToString("#0.00");
            sp.WriteLine(info);
            //在面板上check
            speedometer.text = Math.Round(speed, 2, MidpointRounding.AwayFromZero) + " m/s " + Environment.NewLine + Math.Round(acceleration, 2, MidpointRounding.AwayFromZero) + Environment.NewLine + Math.Round(centri_acce, 2, MidpointRounding.AwayFromZero) + Environment.NewLine + Math.Round(tilt, 2, MidpointRounding.AwayFromZero) + Environment.NewLine + Math.Round(acce1, 2, MidpointRounding.AwayFromZero) + Environment.NewLine + Math.Round(acce2, 2, MidpointRounding.AwayFromZero);

            lastVelocity = GetComponent<Rigidbody>().velocity.magnitude;
            timer_a = 0;
            i = 0;
        }
    }

    // ApplySteer() & CheckWayPointDistance() 本來是寫給自動駕駛但後來沒用到
    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        W_FD.steerAngle = newSteer;
        W_FP.steerAngle = newSteer;
    }

    private void CheckWayPointDistance()
    {
        if (Vector3.Distance(base.transform.position, nodes[currentNode].position) < CheckpointDistance)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else currentNode++;
        }
    }

    private void OnDisable()
    {
        //Unity在離開當前場景後會自動呼叫這個函數
    }

    private void OnApplicationQuit()
    {
        //當應用程式結束時會自動呼叫這個函數
    }
}