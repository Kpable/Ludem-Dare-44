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
    // Start is called before the first frame update
    void Start()
    {
        Enabled = true;
        jumpSpeed = jumpSpeedDefault;
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
            playerBody.velocity += Vector2.up * jumpSpeed;
        }
        ActiveAbility = false;
    }
}
