using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] ParticleSystem sparkle;
    [SerializeField] Transform target;
    [SerializeField] float actionSecond;
    private UnityAction action;
    private Rigidbody2D rigid;

    // Use this for initialization
    void Start()
    {
        action = NoneAction;
        actionSecond *= 60.0f;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // コールバック関数の実行
        action();
    }

    /// <summary>
    /// トリガーオブジェクトとの衝突判定
    /// </summary>
    /// <param name="trigger">衝突したトリガーオブジェクト</param>
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        // ゴールリングに衝突したら
        if (trigger.tag.Equals("SpeedRing"))
        {
            // 後方へ移動
            action = MoveBack;
        }

        // ターゲットに衝突したら
        if (trigger.tag.Equals("Target"))
        {
            // 物理挙動を停止
            rigid.bodyType = RigidbodyType2D.Static;
            // エフェクトの実行
            action = PlayEffect;
        }
    }

    /// <summary>
    /// 何もしない関数
    /// </summary>
    private void NoneAction()
    {
        // 何もしない
    }

    /// <summary>
    /// 後方へ移動する
    /// </summary>
    private void MoveBack()
    {
        // ターゲットへ向かって移動
        MoveTarget();
        // 徐々に縮小
        transform.GetChild(0).GetComponent<PlayerScale>().GradualSmaller(actionSecond);
        // アクション実行時間のカウントダウン
        actionSecond -= 1.0f;
    }

    /// <summary>
    /// ターゲットへ向かって移動
    /// </summary>
    private void MoveTarget()
    {
        // 物理挙動を制限
        rigid.bodyType = RigidbodyType2D.Kinematic;

        // ターゲットに向けて移動する
        Vector3 currentPos = transform.position;                                 // 現在の座標
        Vector3 targetPos = target.position;                                     // ターゲットの座標
        Vector3 move = Vector3.Slerp(currentPos, targetPos, 1.0f / actionSecond); // 移動距離
        rigid.position = move;
    }

    /// <summary>
    /// エフェクトの実行
    /// </summary>
    private void PlayEffect()
    {
        sparkle.Play();
        // エフェクトの再生が終了したかチェック
        action = IsEffectAlive;
    }

    /// <summary>
    /// エフェクトの再生が終了するまでチェック
    /// </summary>
    private void IsEffectAlive()
    {
        // エフェクトの再生が終了したら
        if(!sparkle.IsAlive(true))
        {         
            // シーン遷移   
            action = ChangeScene;
        }
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    private void ChangeScene()
    {
        SceneController.Instance.ChangeScene("SelectScene", 1.0f);
        action = NoneAction;
    }
}

