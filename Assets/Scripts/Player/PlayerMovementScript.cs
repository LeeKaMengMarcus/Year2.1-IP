/******************************************************************************
Author: Marcus

Name of Class: PlayerMovementScript

Description of Class: Keeps track of player movement, speed and jumping condition

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //set controller
    public CharacterController controller;

    //set stat
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //jump condition
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //check if ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //able to jump or not
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //move with wasd
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //direction input
        Vector3 move = transform.right * x + transform.forward * z;

        //movement 
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
