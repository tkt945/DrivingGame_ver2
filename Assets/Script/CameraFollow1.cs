using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow1 : MonoBehaviour
{
    public GameObject Car,offset,cam;
    Vector3 cameraOffset;
    Vector3 targetPosition;   // 目標位置
    Vector3 currentVelocity = Vector3.zero;     // 當前速度，這個值由你每次呼叫這個函式時被修改
    float maxSpeed = 50f;    // 選擇允許你限制的最大速度
    float smoothTime = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = offset.gameObject.GetComponent<Transform>().localPosition;
    }

          // 達到目標大約花費的時間。 一個較小的值將更快達到目標。

    void Update()
    {
        targetPosition = Car.GetComponent<Transform>().position + Car.transform.forward * cameraOffset.z + Car.transform.up * cameraOffset.y + Car.transform.right * cameraOffset.x; 
        cam.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime, maxSpeed);
        cam.transform.rotation= offset.transform.rotation;
    }
    
}
