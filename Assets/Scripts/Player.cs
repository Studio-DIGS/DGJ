using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;
    float input; //horizontal input
    float accel;
    Vector3 direction;
    Vector3 velocity;
    Vector3 horiMove;
    float vertMove;

    public float orientation = 1; // -1 is left, +1 is right

    [SerializeField] float maxSpeed = 18f;
    [SerializeField] float jumpHeight = 30f;
    [SerializeField] float gravity = 1.5f;
    [SerializeField] float groundAcceleration = 10f;
    [SerializeField] float airAcceleration =7f;
    [SerializeField] float terminalVelocity = 45f;
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        _updatePlayer();
    }

    void _updatePlayer()
    {
        input = Input.GetAxisRaw("Horizontal"); // get movement input
        // orientation = Mathf.Clamp(orientation + (input * 2), -1, 1); // calculate the orientation (left or right) based on input
        
        direction = (transform.forward * input); // get direction of movement based on forward direction

        
        if (controller.isGrounded)
        {
            vertMove = -0.5f;
            accel = groundAcceleration;

            if (Input.GetButton("Jump"))
            {
                vertMove = jumpHeight;
                accel = airAcceleration;
            }
        }

        // velocity.x += accel * Time.deltaTime;
        // velocity.x += accel * Time.deltaTime;
        // velocity.y += gravity * Time.deltaTime;

        horiMove = Vector3.Lerp(horiMove, direction * maxSpeed, accel * Time.deltaTime);
        vertMove = Mathf.Lerp(vertMove, -1 * terminalVelocity, gravity * Time.deltaTime);

        velocity = new Vector3(horiMove.x, vertMove, horiMove.z);
        
        controller.Move(velocity * Time.deltaTime);
    }
}