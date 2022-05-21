using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCollider : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] string nextlevel;
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
            SceneManager.LoadScene(sceneName: nextlevel);
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
    }
}
