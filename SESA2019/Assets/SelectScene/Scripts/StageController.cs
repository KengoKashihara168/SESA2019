using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    [SerializeField] Image[] stage;    // ステージ
    [SerializeField] Button  describe; // 説明テキスト
    GameObject selectIcon;
    bool changeFlag;

	// Use this for initialization
	void Start ()
    {
        // 各ステージに中心点を設定する
        Vector3 center = stage[stage.Length - 1].transform.position;
        foreach (Image i in stage)
        {
            i.GetComponent<StageData>().SetCenterPoint(center);
        }
        // 説明テキストを非表示にする
        describe.GetComponent<Image>().color = Color.clear;
        selectIcon = GameObject.Find("SelectIcon");
        SetDescribeImage(selectIcon.transform.parent.GetComponent<StageData>().textImage);
        changeFlag = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0)) // クリックされたら
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // マウスの座標
            for (int i = 0; i < stage.Length; i++)
            {
                // ステージの範囲を求めてマウスの座標と比較する
                if (stage[i].GetComponent<StageData>().IsRange(mousePos)) // クリックされた座標が範囲内なら
                {
                    Select(stage[i]);
                    break;
                }
            }            
        }
    }

    // ステージのフラグを全てリセット
    void StageReset()
    {
        foreach(Image i in stage)
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
            //GetComponent<ZoomController>().Zoom(selectStage.transform);
        }
        else
        {
            // ステージを選択する
            StageReset();            
            selectIcon.GetComponent<SelectIconController>().Migrate(stage);
            stage.GetComponent<StageData>().Selected();
        }
        // 説明テキストを設定する
        SetDescribeImage(stage.GetComponent<StageData>().textImage);
    }

    // 説明テキストの設定
    public void SetDescribeImage(Sprite text)
    {
        //Transform child = describe.transform.GetChild(0);
        describe.GetComponent<Image>().sprite = text;       // 画像を設定する
        describe.GetComponent<Image>().color = Color.white; // 画像を表示する
    }

    public void SceneTransition()
    {
        if (changeFlag) return;
        // 決定音の再生
        GetComponent<AudioSource>().Play();
        SceneController.Instance.ChangeScene("StartScene", 1.0f);
        changeFlag = false;
    }
}
