﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            // Todo reset did diagnostics contrller flag
            SceneTransitioner.Instance.RestartScene();
        }
    }
}
