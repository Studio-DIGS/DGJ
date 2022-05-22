using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{

    public Player player;
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float orientation = player.orientation * -1;
        // Determine angle. 175 is used instead of 180 so that the player always rotates toward the camera instead of away
        float angle = Mathf.Clamp(orientation * 175, -180, 0);  
        Quaternion targetRot = Quaternion.Euler(0,angle,0);
        
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, Time.deltaTime * smooth);
    }
}
