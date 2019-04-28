using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum ToggleType { DoubleJump, Hover, Optics, Motor };

public class DiagnosticsController : MonoBehaviour
{

    AbilityManager abManager;
    PowerManager pwManager;
    public GameObject batteryGroup;
    TMP_Text batteryText;
    Image batteryImage;
    public GameObject diagnosticsCanvas;
    public static bool bringUpDiagnosticsOnLoad = true;
    List<Toggle> toggleList;
    public Sprite[] batterySprites;

    // Start is called before the first frame update
    void Start()
    {

        toggleList = new List<Toggle>();

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

        batteryText = batteryGroup.GetComponentInChildren<TMP_Text>();
        batteryImage = batteryGroup.GetComponentInChildren<Image>();

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

        foreach ( GameObject tog in GameObject.FindGameObjectsWithTag("Toggle"))
        {
            toggleList.Add(tog.GetComponent<Toggle>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            bringUpDiagnosticsOnLoad = true;
        }
    }

    public void UpdateBattery()
    {
        // Get current power from battery manager
        int currentPower = pwManager.Power();
        int maxPower = pwManager.MaxPower();

        // Update Graphic on battery
        batteryText.text = "Reserve Power Remaining: " + currentPower + " / " + maxPower;

        Debug.Log(currentPower);
        batteryImage.sprite = batterySprites[currentPower];

        foreach(Toggle tog in toggleList)
        {
            if(currentPower == 0)
            {
                tog.interactable = tog.isOn;
            }
            else
            {
                tog.interactable = true;
            }
        }
        
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
            case ToggleType.Optics:
                abManager.ToggleOptics();
                break;
            case ToggleType.Motor:
                abManager.ToggleMotor();
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

    public void TogOptics(bool toggleValue)
    {
        AbilityToggle(ToggleType.Optics, toggleValue);
    }

    public void TogMotor(bool toggleValue)
    {
        AbilityToggle(ToggleType.Motor, toggleValue);
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
