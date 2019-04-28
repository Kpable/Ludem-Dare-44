using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    // Power Params
    public int currentPower = 2;
    static public int maxPower = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPower(int amount)
    {
        int newAmount = currentPower + amount;
        currentPower = (newAmount > maxPower) ? maxPower : newAmount;
    }

    public void SubtractPower(int amount)
    {
        int newAmount = currentPower - amount;
        currentPower = (newAmount < 0) ? 0 : newAmount;
    }

    public int Power()
    {
        return currentPower;
    }

    public int MaxPower()
    {
        return maxPower;
    }

    public void SetMaxPower(int amount)
    {
        if(amount < 0)
        {
            maxPower = 0;
            currentPower = 0;
        } else if( amount < currentPower)
        {
            maxPower = amount;
            currentPower = amount;
        }
        else
        {
            maxPower = amount;
        }
    }

    public void PayPowerToll()
    {
        SetMaxPower(maxPower - 1);
    }
}
