using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] ParticleSystem sparkle;
    [SerializeField] Transform target;
    [SerializeField] float actionSecond;
    private UnityAction action;

    // Use this for initialization
    void Start ()
    {
        action = NoneAction;
        actionSecond *= 60.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        action();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "SpeedRing") return;
        action = MoveBack;
    }

    private void NoneAction()
    {
        // 何もしない
    }

    private void MoveBack()
    {
        MoveTarget();
        GradualSmaller();
    }

    private void MoveTarget()
    {
        // 物理計算をしない
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.bodyType = RigidbodyType2D.Static;

        // ターゲットに向けて移動する
        Vector3 currentPos = transform.position; // 現在の座標
        Vector3 targetPos = target.position;     // ターゲットの座標
        Vector3 move = Vector3.Slerp(currentPos, targetPos, 1.0f / actionSecond); // 移動距離
        transform.position = move;

        // ターゲットの座標に到着したら
        if (move == targetPos) action = Shine;
    }

    private void GradualSmaller()
    {
        if (IsMinusVector(transform.localScale)) return;
        float shrink = 1.0f / actionSecond;
        transform.localScale -= new Vector3(shrink, shrink, shrink);
    }

    private void Shine()
    {
        if (sparkle.isPlaying) return;
        sparkle.Play();
        //action = ChangeScene;
    }

    private void ChangeScene()
    {
        SceneController.Instance.ChangeScene("SelectScene", 1.0f);
        action = NoneAction;
    }

    private bool IsMinusVector(Vector3 vec)
    {
        if (vec.x < 0.0f && vec.y < 0.0f && vec.z < 0.0f) return true;

        return false;
    }    
}

