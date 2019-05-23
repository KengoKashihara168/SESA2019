using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Time.time >= 50.0f)
        {
            Debug.Log(Time.time + ":" +transform.position.magnitude);
            gameObject.SetActive(false);
        }
    }
}
