using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateOpposite : MonoBehaviour
{
    [SerializeField] float triggerScale = 8f;
    [SerializeField] GameObject interactable;
    new BoxCollider collider = null;
    BoxCollider stepCollision = null;

    private void Awake()
    {
    collider = GetComponent<BoxCollider>();
    collider.isTrigger = false;

    stepCollision = gameObject.AddComponent<BoxCollider>();
    stepCollision.size = new Vector3(collider.size.x, collider.size.y * triggerScale, collider.size.z);
    stepCollision.center = collider.center;
    stepCollision.isTrigger = true;
    }

    private void OnTriggerStay(Collider other) {
        interactable.SetActive(true);
        Debug.Log("Pressure plate has been sat on");
    }
    private void OnTriggerExit(Collider other) {
        interactable.SetActive(false);
    }
}
