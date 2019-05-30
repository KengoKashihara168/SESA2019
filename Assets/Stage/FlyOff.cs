using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyOff : Enemy
{
    [SerializeField] private MoveType moveType;
    [SerializeField] private float moveSpeed;

	// Use this for initialization
	void Start ()
    {
        moveFlag = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!moveFlag) return;

        Vector2 pos = transform.position;

        switch(moveType)
        {
            case MoveType.Up:
                pos.y += moveSpeed;
                break;
            case MoveType.Down:
                pos.y -= moveSpeed;
                break;
            case MoveType.Right:
                pos.x += moveSpeed;
                break;
            case MoveType.Left:
                pos.x -= moveSpeed;
                break;
        }

        transform.position = pos;
	}
}

public enum MoveType
{
    Up,
    Down,
    Right,
    Left,
}
