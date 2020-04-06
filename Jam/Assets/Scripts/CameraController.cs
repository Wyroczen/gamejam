using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 Offset { get; set; }
    [SerializeField] bool lockY;

    void Start()
    {
        Offset = transform.position - Player.transform.position;
    }

    void Update()
    {
        if (lockY)
        {
            transform.position = new Vector3(Player.transform.position.x + Offset.x, transform.position.y, Player.transform.position.z + Offset.z);
        }
        else
        { 
            transform.position = Player.transform.position + Offset;
        } 
        
    }
}
