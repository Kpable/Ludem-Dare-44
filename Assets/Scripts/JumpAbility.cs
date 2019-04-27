using Assets.Scripts.Api;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class JumpAbility : BaseAbility
{
    private float CAP_CLOCK = 2f;
    private Vector2 CAP_VELOCITY = new Vector2(0, 30);
    private float clock;

    public Rigidbody2D playerBody;
    public float jumpSpeed;
    public float jumpSpeedDefault = 15; // The jump speed is set to this on Start
    private TimingHelper timing;
    // Start is called before the first frame update
    void Start()
    {
        Enabled = true;
        clock = CAP_CLOCK;
        jumpSpeed = jumpSpeedDefault;
        timing = new TimingHelper();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timing.ClockTime = 2;
            timing.OnTimeUpHandler = SetNotActive;
            timing.StartCountdown = true;
            ActiveAbility = true;

            if (ActiveAbility == false)
            {
                Activate();
            }
        }
    }

    private void SetNotActive()
    {
        ActiveAbility = false;
    } 

    public override void SubActivate()
    {
        Vector2 pVelocity = playerBody.velocity;
        if (pVelocity.y > CAP_VELOCITY.y)
        {
            playerBody.velocity += CAP_VELOCITY;
        }
        else
        {
            playerBody.velocity += Vector2.up * jumpSpeed;
        }
    }
}
