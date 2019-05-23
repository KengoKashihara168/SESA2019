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
    private float actionParsent;

    // Use this for initialization
    void Start ()
    {
        action = NoneAction;
        actionSecond *= 60.0f;
        actionParsent = 1.0f / actionSecond;
	}
	
	// Update is called once per frame
	void Update ()
    {
        action();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("SpeedRing"))
        {
            action = MoveBack;
        }

        if (collision.tag.Equals("Target"))
        {
            Debug.Log("hit");
        }
    }

    private void NoneAction()
    {
        // 何もしない
    }

    private void MoveBack()
    {
        MoveTarget();
        GradualSmaller();
        actionSecond -= 1.0f;
    }

    private void MoveTarget()
    {
        // 物理計算をしない
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.bodyType = RigidbodyType2D.Kinematic;

        // ターゲットに向けて移動する
        Vector3 currentPos = transform.position; // 現在の座標
        Vector3 targetPos = target.position;     // ターゲットの座標
        Vector3 move = Vector3.Lerp(currentPos, targetPos, 1.0f / actionSecond); // 移動距離
        rigid.position = move;
        Debug.Log("動く");
        // ターゲットの座標に到着したら
        if (move == targetPos) action = PlayEffect;
    }

    private void GradualSmaller()
    {
        if (IsMinusVector(transform.localScale)) return;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        //transform.localScale -= new Vector3(1.0f / actionSecond, 1.0f / actionSecond, 1.0f / actionSecond);
        Debug.Log(renderer.size);
    }

    private void PlayEffect()
    {
        StartCoroutine("Sparkle");
    }

    private IEnumerator Sparkle()
    {
        if (sparkle.isPlaying) yield break;
        sparkle.Play();

        yield return new WaitWhile(() => sparkle.IsAlive(true));
        action = ChangeScene;
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

