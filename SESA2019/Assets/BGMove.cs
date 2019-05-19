using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
     float moveSpeed;
    float backGroundWidth;

	// Use this for initialization
	void Start ()
    {
        moveSpeed = -0.1f;

        backGroundWidth = GetComponent<SpriteRenderer>().size.x;
    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.position.x < -backGroundWidth)
        {
            transform.position = new Vector3(backGroundWidth - 0.25f, 0, 0);
        }
        transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);    
    }
}
