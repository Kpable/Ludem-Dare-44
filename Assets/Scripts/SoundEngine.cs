using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEngine : MonoBehaviour
{
    public AudioSource audioSource;
    public List< AudioClip> clips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBlip()
    {
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    public void PlayBlip2()
    {
        audioSource.clip = clips[1];
        audioSource.Play();
    }

    public void PlayFizzle()
    {
        audioSource.clip = clips[2];
        audioSource.Play();
    }

    public void PlayVHS()
    {
        audioSource.clip = clips[3];
        audioSource.Play();
    }
}
