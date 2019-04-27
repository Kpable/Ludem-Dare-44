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

    public void SetDoubleJump(bool enabled)
    {
        doubleJumpEnabled = enabled;
    }

    public void SetHover(bool enabled)
    {
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
