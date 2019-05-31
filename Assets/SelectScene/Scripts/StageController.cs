using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    [SerializeField] Image[]    stages;       // ステージ
    [SerializeField] GameObject selectIcon;  // セレクトアイコン
    [SerializeField] Button     describe;    // 説明テキスト
    bool changeFlag;

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
        SetDescribeImage(stages[(int)SceneController.stageType].GetComponent<StageData>().textImage);
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

    // ステージのフラグを全てリセット
    void StageReset()
    {
        foreach(Image i in stages)
        {
            i.GetComponent<StageData>().Reset();
        }
    }

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
        SetDescribeImage(stage.GetComponent<StageData>().textImage);
    }

    // 説明テキストの設定
    public void SetDescribeImage(Sprite text)
    {
        describe.GetComponent<Image>().sprite = text; // 画像を設定する
    }

    public void SceneTransition()
    {
        if (changeFlag) return;
        // 決定音の再生
        GetComponent<AudioSource>().Play();
        SceneController.Instance.ChangeScene("StartScene", 1.0f);
        changeFlag = false;
        describe.interactable = false;
    }
}
