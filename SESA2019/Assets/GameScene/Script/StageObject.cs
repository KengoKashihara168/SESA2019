using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObject : MonoBehaviour
{
    private Rigidbody2D _baseRigidbody2D;      // RigidBody2D

    private bool        _isPosing;             // ポーズ中かどうか

    private Vector2     _savedVelocity;        // ポーズ前に記録した速度

    private float       _savedAngularVelocity; // ポーズ前に記録した回転速度

    private float       _savedGravity;         // ポーズ前に記録した重力


    private void Start()
    {
        _baseRigidbody2D = GetComponent<Rigidbody2D>();

        Init();
    }    

    /// <summary>
    /// 初期化
    /// </summary>
    protected virtual void Init()
    {

    }

    /// <summary>
    /// ポーズ中でないときのUpdate
    /// </summary>
    protected virtual void NoPoseUpdate()
    {

    }

    /// <summary>
    /// ポーズ中のFixedUpdate
    /// </summary>
    protected virtual void PoseFixedUpdate()
    {

    }

    /// <summary>
    /// ポーズ中でないときのFixedUpdate
    /// </summary>
    protected virtual void NoPoseFixedUpdate()
    {

    }

    /// <summary>
    /// ポーズへ遷移
    /// </summary>
    protected virtual void ToPose()
    {
        if (_baseRigidbody2D == null) return;

        _savedVelocity            = _baseRigidbody2D.velocity;
        _baseRigidbody2D.velocity = Vector2.zero;

        _savedAngularVelocity            = _baseRigidbody2D.angularVelocity;
        _baseRigidbody2D.angularVelocity = 0;

        _savedGravity                 = _baseRigidbody2D.gravityScale;
        _baseRigidbody2D.gravityScale = 0;
    }

    protected virtual void ToNoPose()
    {
        if (_baseRigidbody2D == null) return;

        _baseRigidbody2D.velocity        = _savedVelocity;
        _baseRigidbody2D.angularVelocity = _savedAngularVelocity;
        _baseRigidbody2D.gravityScale    = _savedGravity;
    }

    private void Update()
    {
        if (_isPosing) { return; }

        NoPoseUpdate();
    }

    private void FixedUpdate()
    {
        if (_isPosing != GameData.Instance().IsPosing())
        {
            if (GameData.Instance().IsPosing())
            {
                ToPose();
            }
            else
            {
                ToNoPose();
            }

            _isPosing = GameData.Instance().IsPosing();
        }

        if (_isPosing)
        {
            PoseFixedUpdate();
        }
        else
        {
            NoPoseFixedUpdate();
        }
    }
}
