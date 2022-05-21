using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCollider : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    BoxCollider winCollider;
    // Start is called before the first frame update
    bool player1Win = false;
    bool player2Win = false;
    void Start()
    {
        winCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Win && player2Win)
        {
            Debug.Log("Player has won!\n");
            player1Win = false;
            player2Win = false;
        }
    }
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject == player1)
        {
            player1Win = true;
        }
        if (other.gameObject == player2)
        {
            player2Win = true;
        }
        Debug.Log(player1Win + ", " + player2Win);
    }
    
    void OnTriggerExit(Collider other) {
        if (other.gameObject == player1)
        {
            player1Win = false;
        }
        if (other.gameObject == player2)
        {
            player2Win = false;
        }
        Debug.Log(player1Win + ", " + player2Win);
    }
}
