using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlane : MonoBehaviour
{
    public float ForwardSpeed = 20f;
    float RotateSpeed = 0.5f;
    
    Transform PlaneBody;
    void Start()
    {
        PlaneBody = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void FixedUpdate()
    {
         transform.Translate(new Vector3(0, 0, ForwardSpeed * Time.deltaTime), Space.Self);

        if (ControlMoving.pitch != 0 || ControlMoving.yaw != 0)
        {
        
            float Rz = -ControlMoving.pitch / 100f * 90f;
            Quaternion ToQuat = Quaternion.Euler(0, 0, Rz);
            Quaternion FromQUat = Quaternion.Euler(0, 0, 0);
            PlaneBody.localRotation = Quaternion.Slerp(FromQUat, ToQuat, 0.4f);
            
            transform.Rotate(new Vector3(-ControlMoving.yaw * Time.deltaTime * RotateSpeed,
            ControlMoving.pitch * Time.deltaTime * RotateSpeed, 0), Space.Self);
        }
        else {
            Quaternion ToQuat = Quaternion.Euler(0, 0, 0);
            Quaternion FromQUat = PlaneBody.localRotation;
            PlaneBody.localRotation = Quaternion.Slerp(FromQUat, ToQuat, 0.4f);

            ToQuat = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            FromQUat = transform.rotation;
            transform.rotation = Quaternion.Slerp(FromQUat, ToQuat,0.1f);
        }
        
    }
}
