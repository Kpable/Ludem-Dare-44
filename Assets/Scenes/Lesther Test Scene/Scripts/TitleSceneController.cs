﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandlePlayButtonPressed()
    {
        Debug.Log("Here");
        SceneTransitioner.Instance.NextScene();
    }

    public void HandleReturnToTitlePressed()
    {
        SceneTransitioner.Instance.TransitionToScene(0);
    }
}
