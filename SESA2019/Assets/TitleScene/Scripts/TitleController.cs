using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    public GameObject star;
    int count;

    // Use this for initialization
    void Start ()
    {
        count = -1;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            star.GetComponent<StarController>().fallFlag = true;
            count = 30;
        }

        if (count >= 0) count--;

        if (count == 0)
        {
            GameObject.Find("SceneManager").GetComponent<SceneController>().ChangeScene();
        }

	}
}
