using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject star;
    Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        star = GameObject.Find("Star");
        //プレイヤーとカメラ間の距離を計算
        offset = transform.position - star.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(star.GetComponent<StarController>().fallFlag)
        {
            if(transform.localPosition.y > -17.0f)
            {
                transform.position = star.transform.position + offset;
            }
        }
    }
}
