using Assets.Scripts.Api;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class JumpAbility : BaseAbility
{
    private Vector2 CAP_VELOCITY = new Vector2(0, 30);

    public Rigidbody2D playerBody;
    public float jumpSpeed;
    public float jumpSpeedDefault = 15; // The jump speed is set to this on Start

    public int JumpsLeft { get; set; }

    public bool DoubleJumpEnabled { get; set; }

    /// <summary>
    ///  Enable/Disables the Double Jump Ability
    /// </summary>
    public bool Enable
    {
        get
        {
            return DoubleJumpEnabled;
        }
        set
        {
            DoubleJumpEnabled = value;
        }
    }


    // Start is called before the first frame update    
    void Start()
    {
        Enabled = true;
        jumpSpeed = jumpSpeedDefault;
        JumpsLeft = 2;
        DoubleJumpEnabled = true;
    }

    public override void SubActivate()
    {
        ActiveAbility = true;
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
        ActiveAbility = false;
    }
}
