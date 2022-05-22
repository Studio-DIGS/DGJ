using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{

    public Player player;
    public Animator animator;
    public float smooth;
    private Quaternion targetRot;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        _updateRotation();
        transform.localRotation = targetRot;
    }

    // Update is called once per frame
    void Update()
    {
        _updateRotation();
        // Smooth rotations when changing directions
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, Time.deltaTime * smooth);

        _animate();

    }

    void _updateRotation()
    {
        float orientation = player.orientation * -1;
        // Determine angle. 175 is used instead of 180 so that the player always rotates toward the camera instead of away
        float angle = Mathf.Clamp(orientation * 175, -180, 0);  
        targetRot = Quaternion.Euler(0,angle,0);
    }

    void _animate()
    {
        float speed = Mathf.Abs(player.input) * player.maxSpeed;
        animator.SetFloat("Speed", speed);

        animator.SetBool("IsJumping", player.isJumping);
    }

}

