﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour {

    int time;
	// Use this for initialization
	void Start () {
        time = 120;
	}
	
	// Update is called once per frame
	void Update () {
		if(time == 0)
        {
            SceneController.Instance.ChangeScene("SelectScene", 1.0f);
        }
        time--;
	}
}
