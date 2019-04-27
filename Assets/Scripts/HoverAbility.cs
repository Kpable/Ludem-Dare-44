using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Api
{ 
    public class HoverAbility : BaseAbility
    {
        public Rigidbody2D playerBody;
        public float hoverDuration = 2f;

        private bool hover = false;
        private bool canHover = true;
        private float originalGravityScale;
        private float originalYVelocity;

        // Start is called before the first frame update
        void Start()
        {
            originalGravityScale = playerBody.gravityScale;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                hover = true;
            }
        }

        private void FixedUpdate()
        {
            if (hover && canHover)
            {
                StartCoroutine("HoverCoroutine");
                hover = canHover = false;
            }
        }

        public override void SubActivate()
        {
            Debug.Log("SubActivate called");
        }

        IEnumerator HoverCoroutine()
        {
            playerBody.gravityScale = 0;
            originalYVelocity = playerBody.velocity.y;
            playerBody.velocity = new Vector2(playerBody.velocity.x, 0);

            yield return new WaitForSeconds(hoverDuration);

            playerBody.gravityScale = originalGravityScale;
            playerBody.velocity = new Vector3(playerBody.velocity.x, originalYVelocity);
            canHover = true;
        }
    }
}
