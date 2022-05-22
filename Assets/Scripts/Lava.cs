using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject gameOverScreen;
    BoxCollider hitbox;
    void Awake()
    {
        hitbox = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject == player1 || other.gameObject == player2)
        {
            other.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }
}
