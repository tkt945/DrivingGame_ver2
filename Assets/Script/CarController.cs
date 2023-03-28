using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class CarController : MonoBehaviour
{
    public SerialPort sp = new SerialPort("COM6", 115200);

    public GameObject CarSteering,warning_vision,doinWell;  //方向盤
    public AudioSource audioSource1;  //引擎聲音1
    public AudioSource audioSource2;  //引擎聲音2
    public Text speedometer,gear,tilt_txt; //面板參考

    //輸入裝置的input
    private float m_horizontalInput;
    private float m_brakeInput=0,m_brakeGasInput =1, m_gasInput=0;
    private bool m_brakePressed = false, m_brakeGasPressed = false, m_gasPressed=false;
    private float m_steeringAngle;
//    private Vector2 stick;

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

    double maxTilt = 0;
    double minTilt = 0;


    private void Start()
    {
        sp.Open();
        GetComponent<Rigidbody>().centerOfMass = centreOfMass;
        gear.text = "N";
        // 本來是寫給自動駕駛但後來沒用到
        //Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        //nodes = new List<Transform>();

        //for (int i = 0; i < pathTransform.Length; i++)
        //{
        //if (pathTransform[i] != path.transform)
        //{
        //nodes.Add(pathTransform[i]);
        //}
        //}
    }
    private void Update() {
        //GetInput();
        warning_vision.SetActive(Mathf.Abs((float)tilt) >= 15);
        tilt_txt.text = tilt.ToString();

    }
    private void FixedUpdate()
    {
        
        Steer();
        Accelerate();
        UpdateWheelPoses();
        EngineSound();
        SendInfo();

        //ApplySteer(); 本來是寫給自動駕駛但後來沒用到
        //CheckWayPointDistance(); 本來是寫給自動駕駛但後來沒用到   
    }

    //取得輸入值    
 /*   public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal"); //方向盤的輸入
        m_gasInput = Input.GetAxis("Vertical"); //油門煞車的輸入
        //wheel.text = Convert.ToString(Input.GetAxis("Horizontal"));

        //汽車位置變換
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            transform.position = new Vector3(-193.07f,-1.676f,29.973f);
            transform.rotation = new Quaternion(0, 185.07f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            transform.position = new Vector3(-193.07f, -1.676f, 29.973f);
            transform.rotation = new Quaternion(0,0, 0, 0);
        }
         

        //D檔R檔切換
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Gear = 1;
            gear.text = "D";
        }

        if(Input.GetKeyDown(KeyCode.D)) 
        {
            Gear = 1;
            gear.text = "D";
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Gear = 0;
            gear.text = "R";
        }

        if(Input.GetKeyDown(KeyCode.S)) {
            Gear = 0;
            gear.text = "R";
        }

    }*/

    public void Turn(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            m_horizontalInput = ctx.ReadValue<float>();            
        }
    }

    public void BrakePeddle_Brake(InputAction.CallbackContext ctx)
    {        
        if (ctx.performed)
        {
            m_brakeInput = ctx.ReadValue<float>();
            //Debug.Log("Brake Pressed");
            m_brakePressed = true;
        }
        else if (ctx.canceled)
        {
            m_brakeInput = 0;
            m_brakePressed = false;
            //Debug.Log("Brake Up");
        }
    }
    
    public void BrakePeddle_Gas(InputAction.CallbackContext ctx)
    {        
        if (ctx.performed)
        {
            m_brakeGasInput = ctx.ReadValue<float>();
            //Debug.Log("Brake Peddle Gas Pressed");
            m_brakeGasPressed = true;            
        }
        else if (ctx.canceled)
        {
            m_brakeGasPressed = false;
            //Debug.Log("Brake Peddle Gas Up");
        }
    }

    public void Gas(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            m_gasInput = (ctx.ReadValue<float>()*(-1)+1)/2;
            //Debug.Log(ctx.ReadValue<float>());
            //Debug.Log("Gas Pressed");
            m_gasPressed = true;
        }
        else if (ctx.canceled)
        {
            m_gasInput = 0;
            m_gasPressed = false;
            //Debug.Log("Gas Up");
        }
    }
    public void PosReset0(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            transform.position = new Vector3(-193.07f, -1.676f, 29.973f);
            transform.rotation = new Quaternion(0, 185.07f, 0, 0);
        }
        
    }
    public void PosReset1(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            transform.position = new Vector3(-193.07f, -1.676f, 29.973f);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

    }
    public void ShiftGear(InputAction.CallbackContext ctx)
    {        
        if (ctx.performed)
        {
            if (ctx.ReadValue<float>() < 0 && Gear > 0)
            {
                Gear -= 1;
            }
            else if(ctx.ReadValue<float>() > 0 && Gear < 2)
            {
                Gear += 1;
            }
                        
        }

        if(Gear == 0)
        {
            gear.text = "R";
        }
        else if(Gear == 1)
        {
            gear.text = "N";
        }
        else if(Gear == 2)
        {
            gear.text = "D";
        }

    }




        /*public void Tilt0(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                tilt = 0;
            }
        }
        public void Tilt8(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                tilt = 8;
            }
        }*/
        
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
        if (!m_brakePressed && Gear == 2)
        {
            W_FD.motorTorque = (m_brakeGasInput * 0.25f + m_gasInput * 0.75f) * motorForce * (maxSpeed - speed * 3.6f + 20) / maxSpeed;
            W_FP.motorTorque = (m_brakeGasInput * 0.25f + m_gasInput * 0.75f) * motorForce * (maxSpeed - speed * 3.6f + 20) / maxSpeed;
            W_RD.motorTorque = (m_brakeGasInput * 0.25f + m_gasInput * 0.75f) * motorForce * (maxSpeed - speed * 3.6f + 20) / maxSpeed;
            W_RP.motorTorque = (m_brakeGasInput * 0.25f + m_gasInput * 0.75f) * motorForce * (maxSpeed - speed * 3.6f + 20) / maxSpeed;
            W_FD.brakeTorque = 0;
            W_FP.brakeTorque = 0;
            W_RD.brakeTorque = 0;
            W_RP.brakeTorque = 0;
        }

        //倒車
        else if (!m_brakePressed && Gear == 0)
        {
            W_FD.motorTorque = -1 * (m_brakeGasInput * 0.25f + m_gasInput * 0.75f) * motorForce / 3;
            W_FP.motorTorque = -1 * (m_brakeGasInput * 0.25f + m_gasInput * 0.75f) * motorForce / 3;
            W_RD.motorTorque = -1 * (m_brakeGasInput * 0.25f + m_gasInput * 0.75f) * motorForce / 3;
            W_RP.motorTorque = -1 * (m_brakeGasInput * 0.25f + m_gasInput * 0.75f) * motorForce / 3;
            W_FD.brakeTorque = 0;
            W_FP.brakeTorque = 0;
            W_RD.brakeTorque = 0;
            W_RP.brakeTorque = 0;
        }

        //N檔
        else if(!m_brakePressed && Gear == 1)
        {
            W_FD.motorTorque = 0;
            W_FP.motorTorque = 0;
            W_RD.motorTorque = 0;
            W_RP.motorTorque = 0;

            W_FD.brakeTorque = 0;
            W_FP.brakeTorque = 0;
            W_RD.brakeTorque = 0;
            W_RP.brakeTorque = 0;
        }

        //煞車
        else if (m_brakePressed)
        {
            W_FD.motorTorque = 0;
            W_FP.motorTorque = 0;
            W_RD.motorTorque = 0;
            W_RP.motorTorque = 0;
            W_FD.brakeTorque = -1.6f * m_brakeInput * motorForce;
            W_FP.brakeTorque = -1.6f * m_brakeInput * motorForce;
            W_RD.brakeTorque = -1.6f * m_brakeInput * motorForce;
            W_RP.brakeTorque = -1.6f * m_brakeInput * motorForce;
        }

        //漸停
        else
        {
            W_FD.motorTorque = 0;
            W_FP.motorTorque = 0;
            W_RD.motorTorque = 0;
            W_RP.motorTorque = 0;

            W_FD.brakeTorque = 0.0001f;
            W_FP.brakeTorque = 0.0001f;
            W_RD.brakeTorque = 0.0001f;
            W_RP.brakeTorque = 0.0001f;
        }
    }

    //呈現輪胎和方向盤的旋轉
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(W_FD, T_FD);
        UpdateWheelPose(W_FP, T_FP);
        UpdateWheelPose(W_RD, T_RD);
        UpdateWheelPose(W_RP, T_RP);

        CarSteering.transform.localEulerAngles = new Vector3(-20, 180, m_horizontalInput * 540);
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

            //tilt + 前傾, - 後傾
            tilt = GetComponent<Rigidbody>().rotation.eulerAngles.x;

            
            
            if (tilt > 180)
            {
                tilt = tilt - 360;
            }

            if (tilt > maxTilt)
            {
                maxTilt = tilt;
            }
            
            if (tilt < minTilt)
            {
                minTilt = tilt;
            }
            Debug.Log("最大前傾角=" + maxTilt + "  最大後傾角=" + minTilt +"  現在傾角"+tilt);

            if (tilt >= 5)
            {
                tilt = 5;
            }

            if (tilt <= -5)
            {
                tilt = -5;
            }
            
            //傳給Arduino
            info = "s,"+acce1.ToString("#0.00") + "," + acce2.ToString("#0.00") + "," + tilt.ToString("#0.00")+",";
            sp.WriteLine(info);
            //在面板上check
            //speedometer.text = Math.Round(speed*3.6f, 2, MidpointRounding.AwayFromZero) + " km/hr " + Environment.NewLine + Math.Round(acceleration, 2, MidpointRounding.AwayFromZero) + Environment.NewLine + Math.Round(centri_acce, 2, MidpointRounding.AwayFromZero) + Environment.NewLine + Math.Round(tilt, 2, MidpointRounding.AwayFromZero) + Environment.NewLine + Math.Round(acce1, 2, MidpointRounding.AwayFromZero) + Environment.NewLine + Math.Round(acce2, 2, MidpointRounding.AwayFromZero);
            speedometer.text = Math.Round(speed * 3.6f, 2, MidpointRounding.AwayFromZero) + " km/hr " ;

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
