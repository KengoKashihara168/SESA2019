using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VCameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstVcam;
    [SerializeField] CinemachineVirtualCamera secondVcam;
    [SerializeField] int shakeTime;

    private bool shakeFlag;
    

    // Use this for initialization
    void Start ()
    {
        if (firstVcam.Priority < secondVcam.Priority)
        {
            ChangePriority();
        }
        shakeFlag = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(shakeFlag)
        {
            shakeTime--;
            if(shakeTime <= 0)
            {
                ChangePriority();
                shakeFlag = false;
            }
        }
	}

    public void Shake()
    {
        if (shakeFlag) return;
        shakeFlag = true;
        ChangePriority();
    }

    void ChangePriority()
    {
        Debug.Assert(firstVcam != secondVcam, "カメラの優先度が同じです");
        int tmp = firstVcam.Priority;
        firstVcam.Priority = secondVcam.Priority;
        secondVcam.Priority = tmp;
    }
}
