using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpaceShip : Enemy
{
    [SerializeField] float moveSpeed;
    [SerializeField] float moveRange;
    private UnityAction action;
    private Rigidbody2D rigid;
    private float moveDistance;
    private Vector3 startPosition;

	// Use this for initialization
	void Start ()
    {
        action = MoveDown;
        rigid = GetComponent<Rigidbody2D>();
        moveDistance = 0.0f;
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(moveFlag)
        {
            action();
        }
	}

    private void MoveDown()
    {
        Vector2 move = new Vector2(0.0f, -moveSpeed);
        rigid.velocity = move;
    }

    private void MoveRight()
    {
        Vector3 move = new Vector3(moveSpeed, 0.0f,0.0f);
        rigid.velocity = transform.rotation * move;
        rigid.velocity = rigid.velocity.normalized * moveSpeed;
        moveDistance = transform.position.x - startPosition.x;
        if(moveDistance >= moveRange)
        {
            action = MoveUp;
            rigid.MoveRotation(0.0f);
        }
    }

    private void MoveUp()
    {
        Vector3 move = new Vector3(0.0f, moveSpeed, 0.0f);
        rigid.velocity = move;
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        action = MoveRight;
        rigid.velocity = Vector2.zero;
        rigid.MoveRotation(-17.0f);
    }
}
