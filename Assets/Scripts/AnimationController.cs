using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    BasicMovement basicMovement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if (animator == null) Debug.LogError("No animator Found");
        basicMovement = GetComponent<BasicMovement>();
        if (basicMovement == null) Debug.LogError("No basicMovement Found");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
