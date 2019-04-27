using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TimingHelper : MonoBehaviour
{

    private float clockBackup;
    private float clock;

    public bool StartCountdown { get; set; }
    public float ClockTime
    {
        get
        {
            return ClockTime;
        }
        set
        {
            clockBackup = value;
            clock = value;
        }
    }

    public delegate void OnTimeUp();
    public OnTimeUp OnTimeUpHandler { get; set; }

    public delegate void OnTimeStart();
    public OnTimeUp OnTimeStartHandler { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (StartCountdown == true)
        {
            ClockTime -= Time.deltaTime;

            if (ClockTime <= 0)
            {
                OnTimeUpHandler?.Invoke();
                StartCountdown = false;
            }
        }
    }
}
