using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    [SerializeField] Vector2 maxVelocity;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GetComponent<Rigidbody2D>().velocity.sqrMagnitude >= maxVelocity.sqrMagnitude)
        {
            GetComponent<Rigidbody2D>().velocity = maxVelocity;
        }
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Goal"))
        {
            SceneController.Instance.ChangeScene("GoalScene", 1.0f);
        }
    }
}
