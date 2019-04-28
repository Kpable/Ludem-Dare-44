using Assets.Scripts.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpAbility : JumpAbility
{
    public int JumpsLeft { get; set; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public override void SubActivate()
    {
        ActiveAbility = true;
        if (playerMovement.IsOnGround == false)
        {
            if (JumpsLeft > 0)
            {
                Vector2 pVelocity = playerBody.velocity;
                if (pVelocity.y > CAP_VELOCITY.y)
                {
                    playerBody.velocity += CAP_VELOCITY;
                }
                else
                {
                    if (playerBody.velocity.y <= 0)
                    {
                        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpSpeed);
                    }
                    else
                    {
                        playerBody.velocity += Vector2.up * jumpSpeed;
                    }
                }
                JumpsLeft -= 1; // Remove a jump from count
            }
            
        }
        else
        {
            JumpsLeft = 1;
        }
        ActiveAbility = false;
    }
}
