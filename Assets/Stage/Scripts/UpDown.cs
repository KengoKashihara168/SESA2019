using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    [SerializeField] private bool  moveUpFlag;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveRange;
    private Vector3 move;
    private float moveDistance;

	// Use this for initialization
	void Start ()
    {
        move =  moveUpFlag ? Vector3.up : Vector3.down;
        move *= moveSpeed;
        moveDistance = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(moveDistance <= moveRange)
        {
            transform.position += move;
            moveDistance += moveSpeed;
        }
        else
        {
            move *= -1.0f;
            moveDistance = 0.0f;
        }
    }    
}
