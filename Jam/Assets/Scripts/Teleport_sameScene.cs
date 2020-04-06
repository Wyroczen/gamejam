using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport_sameScene : MonoBehaviour
{
    [SerializeField] private float xPos;
    [SerializeField] private float yPos;

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            collider.transform.position = new Vector3(xPos, yPos, collider.transform.position.z);

    }
}

