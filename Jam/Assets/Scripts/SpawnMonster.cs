using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnMonster : MonoBehaviour
    {
        public GameObject Monster;
        public void Start()
        {

        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                GameObject newMonster = Instantiate(Monster) as GameObject;
                newMonster.transform.position = new Vector3(29.61842f, -1.434389f, -1.4f);
            }
        }
    }
}
