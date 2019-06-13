using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Api
{
    public class OpticsAbility : BaseAbility
    {
        public GameObject optics;

        /// <summary>
        /// Uses the unity engine <see cref="Behaviour.enabled"/> to set it's enabled status
        /// </summary>
        public new bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                if (optics) optics.SetActive(!Enabled);
            }
        }


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