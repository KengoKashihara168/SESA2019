using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
	// Use this for initialization
	void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rigid.velocity = new Vector2(5f, 0.0f);
	}
}
