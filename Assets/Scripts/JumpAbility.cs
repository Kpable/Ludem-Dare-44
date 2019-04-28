using Assets.Scripts.Api;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class JumpAbility : BaseAbility
{
    public float jumpSpeed;
    public float jumpSpeedDefault = 15; // The jump speed is set to this on Start

    protected Vector2 CAP_VELOCITY = new Vector2(0, 30);

    public JumpAbility()
    {
        jumpSpeed = jumpSpeedDefault;
    }

    // Start is called before the first frame update    
    void Start()
    {
        Enabled = true;
    }

    public override void SubActivate()
    {
        Debug.Log(string.Format("Jump SubActivate - on ground = {0}", playerMovement.IsOnGround));
        ActiveAbility = true;
        if (playerMovement.IsOnGround)
        {
            Vector2 pVelocity = playerBody.velocity;
            if (pVelocity.y > CAP_VELOCITY.y)
            {
                playerBody.velocity += CAP_VELOCITY;
            }
            else
            {
                if(playerBody.velocity.y <= 0)
                {
                    playerBody.velocity = new Vector2(playerBody.velocity.x, jumpSpeed) ;
                }
                else
                {
                    playerBody.velocity += Vector2.up * jumpSpeed;
                }
            }
        }
        ActiveAbility = false;
    }
}
