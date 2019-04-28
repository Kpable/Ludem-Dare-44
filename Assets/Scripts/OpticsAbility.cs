using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Api
{
    public class OpticsAbility : BaseAbility
    {
        public GameObject optics;

        // Start is called before the first frame update
        void Start()
        {
            if (optics) optics.SetActive(Enabled);
        }

        public override void SubActivate()
        {
            
        }
    }
}