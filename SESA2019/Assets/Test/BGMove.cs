using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    float backGroundWidth;

	// Use this for initialization
	void Start ()
    {
        backGroundWidth = GetComponent<SpriteRenderer>().size.x;
    }

    // Update is called once per frame
    void Update ()
    {
        float length = player.transform.position.x - backGroundWidth;
        if(transform.position.x < length)
        {
            Destroy(gameObject);
            //Debug.Log(this.name + "削除");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Vector3 nextPos = transform.position;
            nextPos.x += backGroundWidth;
            Instantiate(gameObject, nextPos,gameObject.transform.rotation);            
        }
    }
}
