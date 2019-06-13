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
        public BasicMovement playerMovement;
        public Rigidbody2D playerBody;
        public SoundEngine sound;

        /// <summary>
        /// Whether or not the ability can be activated
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Whether or not the ability is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Holds related clock information
        /// </summary>
        public float Clock { get; set; }

        /// <summary>
        /// Constructor. Sets <seealso cref="IsActive"/> to false.
        /// </summary>
        public BaseAbility()
        {
            IsActive = false;
        }

        /// <summary>
        /// Executes the ability if the ability <seealso cref="Enabled"/> == true
        /// </summary>
        public void Activate()
        {
            if (Enabled)
            {
                SubActivate();
            }
        }

        /// <summary>
        /// This is called within a FixedUpdate function from the controller.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        virtual public void SubActivate()
        {
            throw new NotImplementedException("Sub Abilities should override this function");
        }
    }
}
