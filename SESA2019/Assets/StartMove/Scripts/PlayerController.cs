using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform effect;

	// Use this for initialization
	void Start ()
    {
        effect = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        effect.GetComponent<StarEffectController>().Play(false);
        GameObject.Find("Vcam").GetComponent<VCameraController>().Shake();
    }
}
