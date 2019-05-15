using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    Vector2 move;
    float gravity;
    public bool fallFlag;
    int count;

    // Use this for initialization
    void Start ()
    {
        move = new Vector2();
        gravity = 0.05f;
        count = -1;
    }
	
	// Update is called once per frame
	void Update ()
    {        
        if(!fallFlag)
        {
            float sin = Mathf.Sin(Time.time);
            move.y = sin * 0.01f;
        }
        else
        {
            move.y -= gravity;
            gravity *= 1.01f;
        }
        
        this.gameObject.transform.Translate(move);

        if (Input.GetMouseButtonDown(0))
        {
            fallFlag = true;
            count = 30;
        }

        if (count >= 0) count--;

        if (count == 0)
        {
            SceneController.Instance.ChangeScene("SelectScene", 1.0f);
        }
    }
}
