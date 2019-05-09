using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Transform effect;
    int shakeCount;
    Rigidbody2D rigid;
    float rot;

	// Use this for initialization
	void Start ()
    {
        effect = transform.GetChild(0);
        shakeCount = 1;
        rigid = GetComponent<Rigidbody2D>();
        rot = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        rigid.MoveRotation(rot);
        rot -= 5.0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        effect.GetComponent<StarEffectController>().Play(false);
        if(shakeCount >= 0)
        {
            GameObject.Find("VcamManager").GetComponent<VCameraController>().Shake();
            shakeCount--;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "ScreenArea")
        {
            GameObject.Find("SceneManager").GetComponent<SceneController>().ChangeScene();
        }
    }
}
