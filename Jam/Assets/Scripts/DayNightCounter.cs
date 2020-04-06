using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class DayNightCounter : MonoBehaviour
    {
        DateTime start;
        TimeSpan timeSpan = new TimeSpan(0, 0, 10);
        public void Start()
        {
            start = DateTime.Now;
        }
        public void Update()
        {
            if (DateTime.Now - start > timeSpan)
            {
                Debug.Log("zmiana!");
                start = DateTime.Now;
            }
        }
    }
}
