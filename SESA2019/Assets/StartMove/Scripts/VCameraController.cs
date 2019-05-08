using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VCameraController : MonoBehaviour
{
    int noiseTime;

	// Use this for initialization
	void Start ()
    {
        noiseTime = -1;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(noiseTime == 0)
        {
            this.gameObject.SetActive(true);
        }
        noiseTime--;
	}

    public void Shake()
    {
        this.gameObject.SetActive(false);
        noiseTime = 60;
    }
}
