using Assets.Scripts.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{

    // Ability toggles
    public bool doubleJumpEnabled = false;
    public bool hoverEnabled = false;

    public JumpAbility jumpAbility;
    public HoverAbility hoverAbility;
    public DoubleJumpAbility doubleJumpAbility;


    // Start is called before the first frame update
    void Start()
    {
        jumpAbility.Enabled = true;
        hoverAbility.Enabled = false;
        doubleJumpAbility.Enabled = false;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDoubleJump()
    {
        Debug.Log("Double Jump set to: " + !doubleJumpEnabled);
        doubleJumpEnabled = !doubleJumpEnabled;
        doubleJumpAbility.Enabled = doubleJumpEnabled;
    }

    public void ToggleDoubleJump(bool enabled)
    {
        Debug.Log("Double Jump set to: " + enabled);
        doubleJumpEnabled = enabled;
        doubleJumpAbility.Enabled = doubleJumpEnabled;
    }

    public void ToggleHover()
    {
        Debug.Log("Hover set to: " + !hoverEnabled);
        hoverEnabled = !hoverEnabled;
        hoverAbility.Enabled = hoverEnabled;
    }


    public void ToggleHover(bool enabled)
    {
        Debug.Log("Hover set to: " + enabled);
        hoverEnabled = enabled;
        hoverAbility.Enabled = hoverEnabled;
    }

    public bool CanDoubleJump()
    {
        return doubleJumpEnabled;
    }

    public bool CanHover()
    {
        return hoverEnabled;
    }
}
