using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;
    float rotationZ = 0f;

    public float sensitivity = 10f;

    /*private void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY+= Input.GetAxis("Mouse Y") * sensitivity;
        if (Input.GetKey(KeyCode.W))
            rotationZ += sensitivity*Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            rotationZ -= sensitivity*Time.deltaTime;

        //rotationZ += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localEulerAngles = new Vector3(rotationY,rotationX,rotationZ);
    }*/
}
