/******************************************************************************
Author: Marcus

Name of Class: MouseLook

Description of Class: Makes camera and body able to transform according to mouse 
movement

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //mouse sense
    public float mouseSensitivity = 100f;

    //player look
    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //disable cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //look horizontal
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //look vertical
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //rotate player body
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
