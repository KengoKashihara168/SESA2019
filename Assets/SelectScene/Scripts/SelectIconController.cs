using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIconController : MonoBehaviour
{
    [SerializeField] float moveSpeed;               // 移動速度
    [SerializeField] ParticleSystem starEffect;     // キラキラエフェクト
    [SerializeField] private Transform targetStage; // 選択されたステージ
    private float time;                             // 移動時間

    void Awake()
    {
        time = 0.0f;
    }

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        // 移動
        Move();
    }

    /// <summary>
    /// 選択されたステージの取得
    /// </summary>
    /// <param name="stage"></param>
    public void SetTarget(Image stage)
    {
        targetStage = stage.transform;
    }

    /// <summary>
    /// 移動
    /// </summary>
    void Move()
    {
        Vector2 from = transform.position; // 現在の座標
        Vector2 to = targetStage.position; // 目的の座標
        time = 1.0f / moveSpeed;           // 移動時間
        // 補間移動
        transform.position = Vector2.Lerp(from, to, time);
    }
}
