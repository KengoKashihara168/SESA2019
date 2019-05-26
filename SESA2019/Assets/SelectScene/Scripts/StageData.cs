using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageData : MonoBehaviour
{
    Vector3 point;             // 恒星の座標
    public float aroundTime;   // １回転する時間(秒÷360°)
    bool checkFlag;            // 選択判別フラグ
    public Sprite textImage;   // 説明文のスプライト
    RectTransform rect;        // 画像データ
    Vector2 defaultSize;       // 初期サイズ

    // Use this for initialization
    void Start ()
    {
        rect = GetComponent<RectTransform>();
        defaultSize = rect.sizeDelta;
        Reset(); // 設定をクリアする
	}
	
	// Update is called once per frame
	void Update ()
    {
        Revolution(); // 公転
	}

    // 公転
    void Revolution()
    {
        Vector3 axis = Vector3.forward;              // 公転軸
        float angle = 360.0f / (aroundTime * 60.0f); // 回転速度
        transform.RotateAround(point, axis, angle);  // 公転処理
    }

    // 引数の座標との中間地点の距離を求める
    public float GetMiddleDistance(Vector2 to)
    {
        Vector2 from = transform.position;              // 座標
        float length = to.magnitude - from.magnitude;   // 次のステージまでの距離
        float planetArea = from.magnitude + length / 2; // 次のステージとの中間点までの距離
        return planetArea;
    }

    // 選択された処理
    public void Selected()
    {
        // フラグを立てる
        checkFlag = true;
        // 画像を大きくする
        Vector2 extend = new Vector2(0.5f, 0.5f);
        rect.sizeDelta += extend;
        // セレクト音の再生
        GetComponent<AudioSource>().Play();
    }

    // 設定のクリア
    public void Reset()
    {
        checkFlag = false;
        rect.sizeDelta = defaultSize;
    }

    // フラグの取得
    public bool GetFlag()
    {
        return checkFlag;
    }

    // 恒星の座標を設定
    public void SetCenterPoint(Vector3 point)
    {
        this.point = point;
    }

    public bool IsRange(Vector2 mousePoint)
    {
        float mouseLength = mousePoint.magnitude;
        if (mouseLength > GetOverRange()) return false;
        if (mouseLength < GetUnderRange()) return false;
        return true;
    }

    float GetOverRange()
    {
        Vector2 position = transform.position;
        Vector2 size = rect.sizeDelta / 2;
        float range = position.magnitude + size.magnitude;
        return range;
    }

    public float GetUnderRange()
    {
        Vector2 position = transform.position;
        Vector2 size = rect.sizeDelta / 2;
        float range = position.magnitude - size.magnitude;
        return range;
    }
}
