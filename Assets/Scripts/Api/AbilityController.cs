using Assets.Scripts.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{

    public GameObject playerObj;
    public BasicMovement playerMovement;
    private Dictionary<IAbility, float> clocks; // dict of clocks associated with the ability

    JumpAbility jumpAbility;
    DoubleJumpAbility doubleJumpAbility;
    HoverAbility hoverAbility;
    MotorControlDisAbility motorControlAbility;


    // Start is called before the first frame update
    void Start()
    {
        clocks = new Dictionary<IAbility, float>();
        foreach (IAbility ab in playerObj.GetComponents<IAbility>())
        {
            clocks.Add(ab,ab.Clock);
        }


        jumpAbility = playerObj.GetComponent<JumpAbility>();
        doubleJumpAbility = playerObj.GetComponent<DoubleJumpAbility>();
        hoverAbility = playerObj.GetComponent<HoverAbility>();
        motorControlAbility = playerObj.GetComponent<MotorControlDisAbility>();
    }

    // Update is called once per frame
    void Update()
    {
        // ---- JUMP ----
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if(hoverAbility.IsActive == false)
            {
                jumpAbility.Activate();
                doubleJumpAbility.Activate();
            }
        }
        

        // ---- HOVER ----
        hoverAbility.Clock = 2f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hoverAbility.StartHover();
            hoverAbility.Activate();
        }

        // ---- MOTOR CONTROL ----
        motorControlAbility.Activate();
    }
}
