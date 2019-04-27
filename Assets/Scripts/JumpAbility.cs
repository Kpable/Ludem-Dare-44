using Assets.Scripts.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAbility : BaseAbility
{
    public Rigidbody2D playerBody;
    public float jumpSpeed;

    /// <summary>
    /// The jump speed is set to this on Start
    /// </summary>
    public float jumpSpeedDefault = 15;
    private Vector2 CAP_VELOCITY = new Vector2(0, 30);

    // Start is called before the first frame update
    void Start()
    {
        jumpSpeed = jumpSpeedDefault;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 pVelocity = playerBody.velocity; 
            if(pVelocity.y > CAP_VELOCITY.y)
            {
                playerBody.velocity += CAP_VELOCITY;
            }
            else
            {
                playerBody.velocity += Vector2.up * jumpSpeed;
            }
        }
    }
}
