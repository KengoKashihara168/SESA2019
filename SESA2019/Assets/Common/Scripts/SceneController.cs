using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeScene()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "TitleScene":
                FadeManager.Instance.LoadScene("SelectScene",1.0f);
                break;
            case "SelectScene":
                FadeManager.Instance.LoadScene("TitleScene",1.0f);
                break;
            case "GameScene":
                FadeManager.Instance.LoadScene("ResultScene",1.0f);
                break;
            case "ResultScene":
                FadeManager.Instance.LoadScene("TitleScene",1.0f);
                break;
        }
    }
}
