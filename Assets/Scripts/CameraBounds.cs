using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CameraBounds : MonoBehaviour
{
    float horiInput = 0.0f;
    [SerializeField] float speed = 10.0f;
    private Vector3 motion;
    void Start()
    {
    }
    void Update()
    {
        horiInput = Input.GetAxisRaw("Horizontal");
        motion = new Vector3(horiInput * speed * Time.deltaTime, 0, 0);
        transform.Translate(motion);

    }
}
