using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarMover : StageObject
{
    // コンポーネント
    private Rigidbody2D _rgdb;   // RigidBody

    // 星の形
    private int _selectedStarCollider; // 選択中のコライダーの番号
    private int _sharpColliderId = 0;  // Sharpコライダーの番号
    private int _wideColliderId  = 2;  // Wide コライダーの番号
    [SerializeField] private Transform        _faceTransform;    // 顔(l_l)のTransform
    [SerializeField] private List<GameObject> _starColliderList; // 星形のリスト
    [SerializeField] private ShapeChanger     _shapeChanger;     // 形変更のやつ

    // 刺さっている動作の処理
    private int     _stickerNum;   // 隣接しているStirckerレイヤーをもつオブジェクト数
    private bool    _isStick;      // 刺さっている挙動をするとき true
    private Vector3 _stickerCenter;// 刺さっているオブジェクトの中心
    [SerializeField] private float _stickerSpeed; // 刺さっているときのスピード
    [SerializeField] private float _stickPower;   // 刺さる強さ

    // スピードの最大値
    [SerializeField] private float _maxAuglarSpeed; // 最高角速度
    [SerializeField] private float _maxSpeed;       // 最高速度
    [SerializeField] private float _wideMaxSpeed;   // wide時の最高速度
    [SerializeField] private float _defaultGravity; // デフォルトの重力
    [SerializeField] private float _accelPower;     // 加速時にかかる力

    // ジャンプ
    private int _jampTime;                         // ジャンプの残り対空時間
    [SerializeField] private Vector2 _jampPower;   // ジャンプの力
    [SerializeField] private int     _maxJampTime; // ジャンプの対空時間の最大値
    
    // リングでの速度上昇
    [SerializeField] private Vector2 _ringSpeed;   // リングを通ったあとのスピード

    // ダメージを受けた時
    private int         _damageTime;        // ダメージを受けたときの無敵時間
    private const float _noDamageAlpha = 1; // 無敵でないときアルファ値 
    private int         _poseTime;
    [SerializeField] private int                  _maxDamageTime; // 無敵時間の最大値
    [SerializeField] private float                _damageAlpha;   // 無敵中のアルファ値
    [SerializeField] private List<SpriteRenderer> _spriteList;    // 星形ごとのSpriteRenderer
    [SerializeField] private int                  _poseMaxTime;   // ポーズ時間

    // 床の状態での減速
    private const int KoroKoro   = -1; // ころころ (減速 なし)
    private const int TsuruTsuru = 0;  // つるつる (Wide 減速)
    private const int BetaBeta   = 2;  // べたべた (Sharp減速)
    private int _groundState; // 床の状態
    [SerializeField] private float _slowSpeed;   // 減速時のスピード


    // デバッグ
    [SerializeField]
    private float speed;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Init()
    {
        _rgdb                 = GetComponent<Rigidbody2D>();
        _rgdb.gravityScale    = _defaultGravity;
        _selectedStarCollider = 1;
        _stickerNum           = 0;
        _isStick              = false;
        _poseTime             = 0;
        _groundState          = KoroKoro;
    }


    /// <summary>
    /// ポーズ中でないときのUpdate
    /// </summary>
    protected override void NoPoseUpdate()
    {
        ChangeCollider(+1, _selectedStarCollider < _shapeChanger.ShapeId());
        ChangeCollider(-1, _selectedStarCollider > _shapeChanger.ShapeId());
        Jamp(_shapeChanger.Jamp());
    }


    /// <summary>
    /// ポーズ中のFixedUpdate
    /// </summary>
    protected override void PoseFixedUpdate()
    {
        if(++_poseTime > _poseMaxTime)
        {
            _poseTime = 0;
            GameData.Instance().NoPose();
        }
    }


    /// <summary>
    /// ポーズ中でないときのFixedUpdate
    /// </summary>
    protected override void NoPoseFixedUpdate()
    {
        speed = _rgdb.velocity.magnitude;

        _faceTransform.eulerAngles = Vector3.zero;

        if (--_damageTime < 0)
        {
            changeAlpha(_noDamageAlpha);
        }


        // 刺さっているときの処理
        if (_stickerNum > 0 && _isStick)
        {
            _rgdb.gravityScale = 0;

            var sd3 = (_stickerCenter - transform.position).normalized;
            var stickDirection = _stickPower * new Vector2(sd3.x, sd3.y);

            stickDirection.x -= sd3.y;
            stickDirection.y += sd3.x;

            stickDirection = stickDirection.normalized;

            _rgdb.velocity = _stickerSpeed * stickDirection;

            _jampTime = 0;
        }

        // 刺さってないときの処理
        else
        {
            --_jampTime;

            if (_jampTime < 0)
            {
                _rgdb.gravityScale = _defaultGravity;

                // 加減速
                if(_selectedStarCollider == _groundState)
                {
                    if (_rgdb.velocity.magnitude > _slowSpeed)
                    {
                        var sp = (_rgdb.velocity.magnitude + _slowSpeed) / 2;
                        _rgdb.velocity = sp * _rgdb.velocity.normalized;
                    }
                }
                else if (_selectedStarCollider == _wideColliderId && _rgdb.velocity.x > 0)
                {
                    _rgdb.AddForce(new Vector2(_accelPower, 0));
                }

                // 最高速度の調整
                var maxS = _selectedStarCollider == _wideColliderId ? _wideMaxSpeed : _maxSpeed;
                if (_rgdb.velocity.magnitude > maxS)
                {
                    _rgdb.velocity = maxS * _rgdb.velocity.normalized;
                }
            }
            else // ジャンプ中
            {
                _rgdb.angularVelocity = 0;
                if (_jampTime == 0)
                {
                    _rgdb.velocity=Vector2.zero;
                }
                _rgdb.gravityScale = 0;
            }
        }
        

        if (_rgdb.angularVelocity > _maxAuglarSpeed)
        {
            _rgdb.angularVelocity = _maxAuglarSpeed;
        }
        else if (_rgdb.angularVelocity < -_maxAuglarSpeed)
        {
            _rgdb.angularVelocity = -_maxAuglarSpeed;
        }
    }


    /// <summary>
    /// 衝突時の処理
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Sticker"))
        {
            ++_stickerNum;

            _stickerCenter = col.transform.position;
        }

        if (col.tag.Equals("SpeedRing"))
        {
            _rgdb.velocity     = _ringSpeed;
            _rgdb.gravityScale = 0;
            _jampTime          = _maxJampTime;
        }

        if (col.tag.Equals("Enemy") && _damageTime < 0)
        {
            _damageTime = _maxDamageTime;
            changeAlpha(_damageAlpha);
            GameData.Instance().Pose();
        }

        if (col.tag.Equals("TsuruTsuru"))
        {
            _groundState = TsuruTsuru;
        }

        if (col.tag.Equals("BetaBeta"))
        {
            _groundState = BetaBeta;
        }

        if(col.tag.Equals("Finish"))
        {
            SceneController.Instance.ChangeScene("GoalScene", 0.0f);
        }
    }


    /// <summary>
    /// 離れた時の処理
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Sticker"))
        {
            --_stickerNum;
        }

        if (col.tag.Equals("TsuruTsuru") || col.tag.Equals("BetaBeta"))
        {
            _groundState = KoroKoro;
        }
    }


    /// <summary>
    /// 当たり判定の範囲を変更します
    /// </summary>
    /// <param name="v"> 変更値 </param>
    /// <param name="changeAble"> 変更可能か </param>
    private void ChangeCollider(int v, bool changeAble)
    {
        if (!changeAble)
        {
            return;
        }
        if (_selectedStarCollider + v < 0 || _selectedStarCollider + v >= _starColliderList.Count)
        {
            return;
        }
        _starColliderList[_selectedStarCollider].SetActive(false);
        _selectedStarCollider = (v + _selectedStarCollider + _starColliderList.Count) % _starColliderList.Count;
        _starColliderList[_selectedStarCollider].SetActive(true);

        if (_selectedStarCollider == _sharpColliderId)
        {
            _isStick = true;
        }
        if (_selectedStarCollider != _sharpColliderId)
        {
            _isStick = false;
        }
    }


    /// <summary>
    /// ジャンプします
    /// </summary>
    /// <param name="able"> ジャンプ可能か </param>
    private void Jamp(bool able)
    {
        if (!able)
        {
            return;
        }

        _rgdb.velocity     = _jampPower;
        _rgdb.gravityScale = 0;
        _jampTime          = _maxJampTime;
    }

    /// <summary>
    /// アルファ値の変更
    /// </summary>
    /// <param name="a"> 変更後のアルファ値 </param>
    private void changeAlpha(float a)
    {
        foreach(var sprite in _spriteList)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, a);
        }
    }
}
