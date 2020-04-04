using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapParallax : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.3f;
    [SerializeField] float offSet = 0f;
    [SerializeField] public GameObject ViewTarget; //camera
    [SerializeField] bool xOnly = true;

    Tilemap tileMap;
    // Start is called before the first frame update
    void Start()
    {
        tileMap = GetComponent<Tilemap>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float newXPos = ViewTarget.transform.position.x * (scrollSpeed + offSet);
        float newYPos = ViewTarget.transform.position.y * (scrollSpeed + offSet);

        if (xOnly)
        {
            tileMap.transform.position = new Vector3(newXPos, tileMap.transform.position.y, tileMap.transform.position.z);
        }
        else
        {
            tileMap.transform.position = new Vector3(newXPos, newYPos, tileMap.transform.position.z);
        }
    }
}
