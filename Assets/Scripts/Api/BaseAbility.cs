using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Api
{
    public class BaseAbility : MonoBehaviour, IAbility
    {
        /// <summary>
        /// Whether or not the ability can be activated
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Whether or not the ability is active
        /// </summary>
        public bool ActiveAbility { get; set; }

        public float Clock { get; set; }

        public BaseAbility()
        {
            ActiveAbility = false;
        }

        public void Activate()
        {
            if (Enabled)
            {
                SubActivate();
            }
        }

        /// <summary>
        /// This is called within a FixedUpdate function from the controller
        /// </summary>
        virtual public void SubActivate()
        {
            throw new NotImplementedException("Sub Abilities should override this function");
        }
    }
}
