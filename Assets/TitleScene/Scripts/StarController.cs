using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;
using UniRx.Triggers;

public class StarController : MonoBehaviour
{
    [SerializeField] AudioSource startSE; // クリックされた音
    float moveY;                          // 星の移動速度
    float gravity;                        // 星が落下するときの加速度
    UnityAction action;                   // コールバック

    // Use this for initialization
    void Start ()
    {
        gravity = 0.7f;
        // 浮遊
        action = Float;

        // シーン遷移の関数を1回だけ呼ぶ設定
        this.UpdateAsObservable()
            .First(x => transform.position.y <= -2.0f) // 星のY座標が-2以下になったら
            .Subscribe(x => SceneTransition());        // シーン遷移関数の実行
    }
	
	// Update is called once per frame
	void Update ()
    {
        // クリックされたら
        if (Input.GetMouseButtonDown(0))
        {
            // 落下
            action = Fall;
            // SEを再生
            startSE.Play();
        }

        // 星の動き
        Move(action);
    }

    /// <summary>
    /// 星の動き
    /// </summary>
    /// <param name="callback"></param>
    private void Move(UnityAction callback)
    {
        // コールバックの再生
        callback();
        // Y軸方向に動かす
        Vector2 move = new Vector2(0.0f, moveY);
        transform.position = move;
    }

    /// <summary>
    /// 浮遊
    /// </summary>
    private void Float()
    {
        float sin = Mathf.Sin(Time.time);
        moveY = sin;
    }

    /// <summary>
    /// 落下
    /// </summary>
    private void Fall()
    {
        // 重力の加速
        gravity *= 1.01f;
        // 現在の座標から重力分下
        moveY = transform.position.y - gravity;
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    private void SceneTransition()
    {
        // 最初のステージをチュートリアルにする
        SceneController.stageType = StageType.Tutorial;
        // セレクトシーンに遷移
        SceneController.Instance.ChangeScene("SelectScene", 1.0f);
    }
}
