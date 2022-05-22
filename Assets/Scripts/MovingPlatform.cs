using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public PathCreator pathCreator;
    public EndOfPathInstruction end;
    public float speed = 5.0f;
    public float height = 5.0f;
    float dstTravelled = 0.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dstTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(dstTravelled, end);
        transform.position = new Vector3 (transform.position.x, height, transform.position.z);
    }
}
