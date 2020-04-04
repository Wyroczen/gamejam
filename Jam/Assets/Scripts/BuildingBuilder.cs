using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class BuildingBuilder : MonoBehaviour
    {
        public GameObject BuildingPrefab;
        public GameObject Player;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.B) /*and enough money and no building in here (optional)*/)
            {
            var home = Instantiate(BuildingPrefab) as GameObject;
            home.transform.position = new Vector3(Player.transform.position.x, -1.75f, Player.transform.position.z);
            }
        }
    }
}
