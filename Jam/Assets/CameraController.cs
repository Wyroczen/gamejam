using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 Offset { get; set; }

    void Start()
    {
        Offset = transform.position - Player.transform.position;
    }

    void Update()
    {
        transform.position = Player.transform.position + Offset;
    }
}
