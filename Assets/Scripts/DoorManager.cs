using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private PowerManager powerManager;

    // Start is called before the first frame update
    void Start()
    {
        var go = GameObject.Find("GameManager");
        if (go != null) powerManager = go.GetComponent<PowerManager>();
        else Debug.LogWarning("Unable to find GameManager");
        if (!powerManager) Debug.LogWarning("Unable to find component PowerManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player has entered");

            powerManager.SubtractPower(1);
        }
    }
}
