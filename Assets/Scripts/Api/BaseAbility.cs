using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Api
{
    public class BaseAbility : MonoBehaviour
    {
        /// <summary>
        /// Whether or not the ability can be activated
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Whether or not the ability is active
        /// </summary>
        public bool ActiveAbility { get; set; }

        public BaseAbility()
        {
            Enabled = true;
            ActiveAbility = false;
        }
    }
}
