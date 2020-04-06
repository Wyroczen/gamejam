using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class LoadBuildings : MonoBehaviour
    {
        public GameObject[] Sheds;
        public GameObject NewShed;
        public void Start()
        {
            foreach (var building in Constants.BuiltBuildings)
            {
                var oldShed = Sheds[building];
                var newShed = Instantiate(NewShed) as GameObject;
                newShed.transform.position = new Vector3(oldShed.transform.position.x, oldShed.transform.position.y + 3.0f, oldShed.transform.position.z);
                Destroy(oldShed);
            }
        }
    }
}
