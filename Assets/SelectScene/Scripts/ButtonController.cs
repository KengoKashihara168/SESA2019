using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Image selectStage; // 選択されているステージ

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    /// <summary>
    /// 選択されたステージの取得
    /// </summary>
    /// <param name="stage">選択ステージ</param>
    public void SetTarget(Image stage)
    {
        selectStage = stage;
    }

    /// <summary>
    /// クリックされた関数
    /// </summary>
    public void OnClick()
    {
        // 選択されているステージを設定
        SceneController.stageType = selectStage.GetComponent<StageData>().stageType;
    }
}
