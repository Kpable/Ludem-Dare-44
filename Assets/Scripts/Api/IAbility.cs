using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Api
{
    [SerializeField]
    public interface IAbility
    {
        /// <summary>
        /// Whether or not the ability can be activated
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Whether or not the ability is active
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Performs the ability. Meant to be called in an update method. 
        /// </summary>
        void Activate();

        /// <summary>
        /// Clock for timing within this ability
        /// </summary>
        float Clock { get; set; }

    }
}
