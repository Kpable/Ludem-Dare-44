using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;

    public float speed;
    public bool isOnGround;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        playerBody.freezeRotation = true;
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            var newVelocity = playerBody.transform.right * speed;
            playerBody.velocity = new Vector2(newVelocity.x, playerBody.velocity.y);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            var newVelocity = playerBody.transform.right * speed * -1;
            playerBody.velocity = new Vector2(newVelocity.x, playerBody.velocity.y);
        }
    }
}
    