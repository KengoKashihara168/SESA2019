using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;

public class SceneController : MonoBehaviour
{
    public static StageType stageType = StageType.Tutorial; // 選択されたステージ
    private static SceneController instance;                // シングルトンのインスタンス

    /// <summary>
    /// インスタンス
    /// </summary>
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

    /// <summary>
    /// シーン遷移
    /// </summary>
    /// <param name="sceneName">遷移するシーン名</param>
    /// <param name="fadeTime">遷移時のフェード時間</param>
    public void ChangeScene(string sceneName, float fadeTime = 0.0f)
    {
        this.UpdateAsObservable()
            .Take(1)                                                              // 1回だけ実行
            .Subscribe(x => FadeManager.Instance.LoadScene(sceneName, fadeTime)); // シーン遷移
    }
}

/// <summary>
/// ステージの種類
/// </summary>
public enum StageType
{
    Tutorial, // 星空    
    Ice,      // 氷
    Forest,   // 森
    Fungi,    // きのこ
    darkness, // 暗闇
}
