using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ToggleType { DoubleJump, Hover };

public class DiagnosticsController : MonoBehaviour
{

    AbilityManager abManager;
    PowerManager pwManager;
    public TMP_Text batteryText;
    public GameObject diagnosticsCanvas;
    public static bool bringUpDiagnosticsOnLoad = true;

    // Start is called before the first frame update
    void Start()
    {
        abManager = gameObject.GetComponent<AbilityManager>();
        if(!abManager)
        {
            Debug.LogError("Diagnostics Controller: Failed to load ability manager. ");
        }

        pwManager = gameObject.GetComponent<PowerManager>();
        if (!abManager)
        {
            Debug.LogError("Diagnostics Controller: Failed to load power manager. ");
        }

        if (!batteryText)
        {
            Debug.LogError("Diagnostics Controller: Failed to load battery text. ");
        }
        else
        {
            UpdateBattery();
        }


        //diagnosticsCanvas = GameObject.Find("Diagnostics");
        if( !diagnosticsCanvas)
        {
            Debug.LogError("Diagnostics Controller: Failed to find Diagnostics canvas ");
        }

        if (bringUpDiagnosticsOnLoad)
        {
            EnableDiagnostics();
        }
        bringUpDiagnosticsOnLoad = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBattery()
    {
        // Get current power from battery manager
        int currentPower = pwManager.Power();
        int maxPower = pwManager.MaxPower();

        // Update Graphic on battery
        batteryText.text = "Reserve Power Remaining: " + currentPower + " / " + maxPower;
    }

    public void AbilityToggle(ToggleType type, bool toggleValue)
    {
        // Update correct ability state
        switch (type)
        {
            case ToggleType.DoubleJump:
                abManager.ToggleDoubleJump();
                break;
            case ToggleType.Hover:
                abManager.ToggleHover();
                break;
        }

        // Update Power Manager
        if (toggleValue)
        {
            pwManager.SubtractPower(1);
        }
        else
        {
            pwManager.AddPower(1);
        }

        // Update 
        UpdateBattery();
    }

    public void TogDoubleJump(bool toggleValue)
    {
        AbilityToggle(ToggleType.DoubleJump, toggleValue);
    }

    public void TogHover(bool toggleValue)
    {
        AbilityToggle(ToggleType.Hover, toggleValue);
    }

    public void StartLevel()
    {
        DisableDiagnostics();
    }

    public void EnableDiagnostics()
    {
        diagnosticsCanvas.SetActive(true);
    }

    public void DisableDiagnostics()
    {
        diagnosticsCanvas.SetActive(false);
    }

    public void SetSceneLoadState(bool newState)
    {
        bringUpDiagnosticsOnLoad = newState;
    }

}
