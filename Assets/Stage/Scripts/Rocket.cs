using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Enemy
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (moveFlag)
        {
            Vector2 move = new Vector2(-0.1f, 0.0f);
            transform.Translate(move);
        }        
	}
}
