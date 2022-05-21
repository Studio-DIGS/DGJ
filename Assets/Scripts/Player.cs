using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;
    Vector2 input;
    float verticalSpeed = 0.0f;

    public float orientation = 1; // -1 is left, +1 is right
    public float speed;
    [SerializeField] float jumpSpeed = 9;
    [SerializeField] float gravity = 9.8f;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        _updatePlayer();
        _updateParticles();
    }

    void _updatePlayer()
    {
        /*
            Gets player movement input
        */

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized; // get movement input
        orientation = Mathf.Clamp(orientation + (input.x * 2), -1, 1); // calculate the orientation (left or right) based on input
        Vector3 move = transform.forward * input.x + new Vector3(0,input.y,0); // get direction of movement based on forward direction

        if (controller.isGrounded)
        {
            verticalSpeed = 0.0f;
            if (Input.GetKeyDown("space"))
            {
                verticalSpeed = jumpSpeed;
            }
        }
        verticalSpeed -= gravity * Time.deltaTime;
        move.y = verticalSpeed / speed;
        controller.Move(move * Time.deltaTime * speed);
        Debug.DrawLine(transform.position, transform.position + move * speed, Color.blue);
    }

    void _updateParticles()
    {
        return;
    }
}