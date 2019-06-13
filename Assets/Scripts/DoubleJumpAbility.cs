using Assets.Scripts.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpAbility : JumpAbility
{
    // Remaining jump count
    public int JumpsLeft { get; set; }

    // Start is called before the first frame update
    void Start()
    {
    }

    /// <summary>
    /// Performs a second vertical velocity boost if the player body is moving down 
    /// </summary>
    public override void SubActivate()
    {
        IsActive = true;
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
        IsActive = false;
    }
}
