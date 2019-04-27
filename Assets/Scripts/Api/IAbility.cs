using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Api
{
    interface IAbility
    {
        /// <summary>
        /// Whether or not the ability can be activated
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Whether or not the ability is active
        /// </summary>
        bool ActiveAbility { get; set; }

        void Activate();
    }
}
