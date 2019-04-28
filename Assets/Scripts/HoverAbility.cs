﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Api
{ 
    public class HoverAbility : BaseAbility
    {
        public Rigidbody2D playerBody;

        private bool hover = false;
        private bool canHover = true;
        private float originalGravityScale;
        private float originalYVelocity;

        // Start is called before the first frame update
        void Start()
        {
            Enabled = true;
            originalGravityScale = playerBody.gravityScale;
        }

        // Update is called once per frame
        public void StartHover()
        {
            hover = true;
        }

        public override void SubActivate()
        {
            if (hover && canHover)
            {
                StartCoroutine("HoverCoroutine");
                hover = canHover = false;
            }
            else
            {
                canHover = true;
            }
        }

        IEnumerator HoverCoroutine()
        {
            // Check if it is negative velocity
            Debug.Log(playerBody.velocity.y);
            if(playerBody.velocity.y <= 0)
            {
                ActiveAbility = true;
                playerBody.gravityScale = 0;
                originalYVelocity = playerBody.velocity.y;
                playerBody.velocity = new Vector2(playerBody.velocity.x, 0);

                yield return new WaitForSeconds(Clock);

                playerBody.gravityScale = originalGravityScale;
                playerBody.velocity = new Vector3(playerBody.velocity.x, originalYVelocity);
                ActiveAbility = false;
            }
            else
            {
                canHover = true;
            }
        }
    }
}
