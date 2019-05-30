﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Image selectStage;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetTarget(Image stage)
    {
        selectStage = stage;
    }

    public void OnClick()
    {
        SceneController.stageType = selectStage.GetComponent<StageData>().stageType;

    }
}
