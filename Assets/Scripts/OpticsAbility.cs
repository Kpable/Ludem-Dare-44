using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Api
{
    public class OpticsAbility : BaseAbility
    {
        public bool Enabled { get { return enabled; }
            set
            {
                enabled = value;
                if (optics) optics.SetActive(!Enabled);
            }
        }

        public GameObject optics;

        // Start is called before the first frame update
        void Start()
        {
        }

        public override void SubActivate()
        {
            //Debug.Log("No need to activate");
        }
    }
}