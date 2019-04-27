using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{

    // Ability toggles
    public bool doubleJumpEnabled = false;
    public bool hoverEnabled = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDoubleJump()
    {
        Debug.Log("Double Jump set to: " + !doubleJumpEnabled);
        doubleJumpEnabled = !doubleJumpEnabled;
    }

    public void ToggleHover()
    {
        Debug.Log("Hover set to: " + !hoverEnabled);
        hoverEnabled = !hoverEnabled;
    }

    public void ToggleDoubleJump(bool enabled)
    {
        Debug.Log("Double Jump set to: " + enabled);
        doubleJumpEnabled = enabled;
    }

    public void ToggleHover(bool enabled)
    {
        Debug.Log("Hover set to: " + enabled);
        hoverEnabled = enabled;
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
