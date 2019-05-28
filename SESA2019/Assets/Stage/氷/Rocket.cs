using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] Transform player;
    private bool moveFlag;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float length =  player.position.magnitude - transform.position.magnitude;
        if (length <= 50.0f)
        {
            Vector2 move = new Vector2(-0.1f, 0.0f);
            transform.Translate(move);
        }

        if(moveFlag)
        {
            
        }
	}

    public void StartMove()
    {
        moveFlag = true;
    }
}
