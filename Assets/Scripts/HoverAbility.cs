using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Api
{ 
    public class HoverAbility : BaseAbility
    {
        private bool isHovering = false;
        private bool canHover = true;
        private float originalGravityScale;
        private float originalYVelocity;
        private float DRAG_OFFSET = 3f;

        // Start is called before the first frame update
        void Start()
        {
            originalGravityScale = playerBody.gravityScale;
        }

        /// <summary>
        /// Sets the the hovering member to true
        /// </summary>
        public void StartHover()
        {
            isHovering = true;
        }

        /// <summary>
        /// Launches hover coroutine after checking grounded condition and current hovering status
        /// </summary>
        public override void SubActivate()
        {
            if(playerMovement.IsOnGround == false)
            {
                if (isHovering && canHover)
                {
                    StartCoroutine("HoverCoroutine");
                    isHovering = canHover = false;
                }
                else
                {
                    canHover = true;
                }
            }
        }

        /// <summary>
        /// Performs the hovering physic/logic
        /// </summary>
        /// <returns></returns>
        IEnumerator HoverCoroutine()
        {
            // Check if it is negative velocity
            Debug.Log(playerBody.velocity.y);
            if(playerBody.velocity.y <= 0)
            {
                IsActive = true;
                playerBody.gravityScale = 0;
                originalYVelocity = playerBody.velocity.y;
                playerBody.drag += DRAG_OFFSET;
                playerBody.velocity = new Vector2(playerBody.velocity.x, 0);

                yield return new WaitForSeconds(Clock);

                playerBody.drag -= DRAG_OFFSET;
                playerBody.gravityScale = originalGravityScale;
                playerBody.velocity = new Vector3(playerBody.velocity.x, originalYVelocity);
                IsActive = false;
            }
            else
            {
                canHover = true;
            }
        }
    }
}
