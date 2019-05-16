using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;
using UniRx.Triggers;

public class StarController : MonoBehaviour
{
    float moveY;
    float gravity;
    UnityAction action;

    // Use this for initialization
    void Start ()
    {
        gravity = 0.7f;
        action = Float;

        this.UpdateAsObservable().First(x => transform.position.y <= -2.0f).Subscribe(x => SceneTransition());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            action = Fall;            
        }

        Move(action);       
    }

    private void Move(UnityAction callback)
    {
        callback();
        Vector2 move = new Vector2(0.0f, moveY);
        transform.position = move;
    }

    private void Float()
    {
        float sin = Mathf.Sin(Time.time);
        moveY = sin;
    }

    private void Fall()
    {
        gravity *= 1.01f;
        moveY = transform.position.y - gravity;
    }

    private void SceneTransition()
    {        
        SceneController.Instance.ChangeScene("SelectScene", 1.0f);
    }
}
