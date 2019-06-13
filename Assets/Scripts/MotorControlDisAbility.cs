using Assets.Scripts.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorControlDisAbility : BaseAbility
{
    const float TIMEOUT = 3f;
    const float SHOCK_TIMEOUT = 5f;
    float shockCountdown = 5f;

    /// <summary>
    /// Flag to check if the shock feature of this ability is active
    /// </summary>
    public bool ShockEnabled { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Clock = TIMEOUT;
        ShockEnabled = false;
    }

    /// <summary>
    /// Performs timing countdown for when to imobilize playerbody
    /// </summary>
    public override void SubActivate()
    {
        IsActive = true;
        if (Clock <= 0)
        {
            ShockEnabled = true; // Enable shocking period
            Clock = TIMEOUT; // Reset clock
            shockCountdown = SHOCK_TIMEOUT; // Reset clock
        }
        else
        {
            if (ShockEnabled)
            {
                playerBody.velocity = Vector2.zero;
                if (shockCountdown > 0)
                    shockCountdown -= Time.deltaTime;
                else
                    ShockEnabled = false;
            }
            else
            {
                Clock -= Time.deltaTime;
            }
        }
        IsActive = false;
    }
}
