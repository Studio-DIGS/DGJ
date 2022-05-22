using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraBounds : MonoBehaviour
{
    float horiInput = 0.0f;
    [SerializeField] float speed = 10.0f;
    private Vector3 motion;
    Camera cam;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    Transform p1trans;
    Transform p2trans;
    float finalSpeed = 0;
    [SerializeField] float leftBound = -12;
    [SerializeField] float rightBound = 10;
    float futureX = 0.0f;
    void Awake()
    {
        cam = GetComponent<Camera>();
        p1trans = player1.GetComponent<Transform>();
        p2trans = player2.GetComponent<Transform>();
    }
    void Update()
    {
        horiInput = Input.GetAxisRaw("Horizontal");
        Vector3 viewPosP1 = cam.WorldToViewportPoint(p1trans.position);
        Vector3 viewPosP2 = cam.WorldToViewportPoint(p2trans.position);
        futureX = transform.position.x + horiInput * speed * Time.deltaTime;
        //Attempting to move right
        if (((viewPosP1.x < 0.2f || viewPosP2.x < 0.2f) && horiInput > 0) || futureX > rightBound)
        {
            finalSpeed = 0;
            if (futureX > rightBound)
            {
                transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
            }
            return;
        } else 
        {
            finalSpeed = speed;
        }
        //Attempting to move left
        if (((viewPosP1.x > 0.8f || viewPosP2.x > 0.8f) && horiInput < 0) || futureX < leftBound)
        {
            finalSpeed = 0;
            if (futureX < leftBound)
            {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
            }
            return;
        } else 
        {
            finalSpeed = speed;
        }
        motion = new Vector3(horiInput * finalSpeed * Time.deltaTime, 0, 0);
        transform.Translate(motion);

    }
}
