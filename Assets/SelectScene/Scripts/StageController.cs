using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    [SerializeField] Image[]    stages;     // ステージ
    [SerializeField] GameObject selectIcon; // セレクトアイコン
    [SerializeField] Button     nameButton; // 説明テキスト
    bool changeFlag;                        // シーン遷移フラグ

	// Use this for initialization
	void Start ()
    {
        // ステージを選択する
        Select(stages[(int)SceneController.stageType]);

        // 各ステージに中心点を設定する
        Vector3 center = stages[stages.Length - 1].transform.position;
        foreach (Image i in stages)
        {
            i.GetComponent<StageData>().SetCenterPoint(center);
        }

        // 説明テキストを設定
        SetNameSprite(stages[(int)SceneController.stageType].GetComponent<StageData>().textImage);
        changeFlag = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0)) // クリックされたら
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // マウスの座標
            for (int i = 0; i < stages.Length; i++)
            {
                // ステージの範囲を求めてマウスの座標と比較する
                if (stages[i].GetComponent<StageData>().IsRange(mousePos)) // クリックされた座標が範囲内なら
                {
                    Select(stages[i]);
                    break;
                }
            }            
        }

        /************************動画撮影用隠しコマンド************************/

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Select(stages[(int)StageType.Tutorial]);
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Select(stages[(int)StageType.Ice]);
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Select(stages[(int)StageType.Forest]);
        //}

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    Select(stages[(int)StageType.Fungi]);
        //}

        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    Select(stages[(int)StageType.darkness]);
        //}

            /**********************************************************************/

        }

    /// <summary>    
    /// ステージのフラグを全てリセット
    /// </summary>
    void StageReset()
    {
        foreach(Image i in stages)
        {
            i.GetComponent<StageData>().Reset();
        }
    }

    /// <summary>
    /// 選択
    /// </summary>
    /// <param name="stage"></param>
    private void Select(Image stage)
    {
        if (stage.GetComponent<StageData>().GetFlag()) // 既に選択されていたら
        {
            // 選択されているステージに遷移
            SceneTransition();
            return;
        }

        // ステージを選択する
        StageReset();
        selectIcon.GetComponent<SelectIconController>().SetTarget(stage);
        stage.GetComponent<StageData>().Selected();
        SceneController.stageType = stage.GetComponent<StageData>().stageType;
        // 説明テキストを設定する
        SetNameSprite(stage.GetComponent<StageData>().textImage);
    }

    /// <summary>
    /// 名前ボタンに惑星名を設定
    /// </summary>
    /// <param name="nameSprite"></param>
    private void SetNameSprite(Sprite nameSprite)
    {
        nameButton.GetComponent<Image>().sprite = nameSprite; // 画像を設定する
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    public void SceneTransition()
    {
        if (changeFlag) return;
        // 決定音の再生
        GetComponent<AudioSource>().Play();
        // スタートムービーへ遷移
        SceneController.Instance.ChangeScene("StartScene", 1.0f);
        changeFlag = false;
        nameButton.interactable = false;
    }
}
