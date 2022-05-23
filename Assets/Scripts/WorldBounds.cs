using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class WorldBounds : MonoBehaviour
{
    public PathCreator pathCreator;

    // Start is called before the first frame update
    void Awake()
    {
        print("awake");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pathCreator != null)
        {
            foreach (Transform child in transform)
            {
                float distance = pathCreator.path.GetClosestDistanceAlongPath(child.transform.position);
                child.transform.forward = pathCreator.path.GetDirectionAtDistance(distance);

                Vector3 correction = pathCreator.path.GetPointAtDistance(distance) - child.transform.position;
                Vector3 target = new Vector3(correction.x, 0, correction.z);
                // print(target);
                // print(child.transform.position);
                child.transform.position += target;
            }
        }
    }

}
