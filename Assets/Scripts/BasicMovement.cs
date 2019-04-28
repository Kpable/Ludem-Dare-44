using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public BoxCollider2D playerCollider;

    public float speed;
    
    public bool IsOnGround { get; set; }
    public bool IsMoving { get; set; }

    private float xScale;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        playerBody.freezeRotation = true;
        xScale = transform.localScale.x;
    }

    
    void FixedUpdate()
    {
        CheckGroundCondition();
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            var newVelocity = playerBody.transform.right * speed;
            playerBody.velocity = new Vector2(newVelocity.x, playerBody.velocity.y);
            transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            var newVelocity = playerBody.transform.right * speed * -1;
            playerBody.velocity = new Vector2(newVelocity.x, playerBody.velocity.y);
            transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
        }

        IsMoving = playerBody.velocity.magnitude != 0;
    }

    private void CheckGroundCondition()
    {
        RaycastHit2D[] rays = Physics2D.RaycastAll(new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y), Vector2.down, .1f);
        //Debug.DrawRay(new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y), Vector2.down, Color.white, .1f);

        bool hasPlatform = false;
        foreach(RaycastHit2D ray in rays)
        {
            if(ray.collider.tag == "platform")
            {   
                Debug.Log("Found Platform");
                hasPlatform = true;
            }
        }

        IsOnGround = hasPlatform;
    }
}
    