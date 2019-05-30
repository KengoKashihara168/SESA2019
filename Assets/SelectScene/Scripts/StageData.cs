using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageData : MonoBehaviour
{
    public StageType stageType;                  // ステージの種類
    public Sprite textImage;                     // 説明文のスプライト
    [SerializeField] private float aroundTime;   // １周する時間(秒÷360°)
    [SerializeField] private float rotateTime;   // 自転する時間(秒÷360°)
    private Vector3 point;                       // 恒星の座標
    private bool checkFlag;                      // 選択判別フラグ
    private RectTransform rect;                  // 画像データ
    private Vector2 defaultSize;                 // 初期サイズ

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        defaultSize = rect.sizeDelta;
    }

    // Use this for initialization
    void Start ()
    {        
        Reset(); // 設定をクリアする
	}
	
	// Update is called once per frame
	void Update ()
    {
        Revolution(); // 公転
        Rotation();
	}

    // 公転
    void Revolution()
    {
        Vector3 axis = Vector3.forward;              // 公転軸
        float angle = 360.0f / (aroundTime * 60.0f); // 回転速度
        transform.RotateAround(point, axis, angle);  // 公転処理
    }

    void Rotation()
    {
        Vector3 rot = Vector3.zero;            // 回転
        rot.z = 360.0f / (rotateTime * 60.0f); // 角度
        transform.Rotate(rot);                 // 回転処理
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
        Vector2 extend = new Vector2(1.0f, 1.0f);
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
