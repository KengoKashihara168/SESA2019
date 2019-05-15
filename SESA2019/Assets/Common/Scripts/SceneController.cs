using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;

    public static SceneController Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("SceneController");
                instance = obj.AddComponent<SceneController>();
            }
            return instance;
        }

        set { }
    }

    public void ChangeScene(string sceneName, float fadeTime = 0.0f)
    {
        FadeManager.Instance.LoadScene(sceneName, fadeTime);
    }
}