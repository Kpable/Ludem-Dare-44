using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed;

    public bool isOnGround;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

        }        
    }
}
