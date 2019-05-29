using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeChanger : MonoBehaviour
{
    // 選択用の識別番号
    private int _shapeId; // 選択している形の識別番号
    private const int WideId   = 2; // Wide  型のID
    private const int NormalId = 1; // Normal型のID
    private const int SharpId  = 0; // Sharp 型のID

    // 形のセレクタの座標について
    private bool  _isSelecting; // 選択中か
    private float _goalPos;     // 目的座標
    private const float _centerPos = 3.0f; // バーの中心座標
    private const float _barSize   = 4.5f; // バーのサイズ
    [SerializeField] private float _selectRange; // カーソルを選択できる範囲
    [SerializeField] private float _moveRate;    // 移動時の比率
    [SerializeField] private Transform _selecterTransform; // 選択用のマーカーのTransform

    // ジャンプボタン 
    private bool _isJamping; // ジャンプボタンを押したか
    [SerializeField] private Transform      _jampBottonTransform;      // ジャンプボタンの中心座標
    [SerializeField] private float          _jampBottonSize;           // ジャンプボタンのサイズ
    [SerializeField] private SpriteRenderer _jampBottonSpriteRenderer; // ジャンプボタンのSpriteRenderer
    [SerializeField] private List<Sprite>   _spriteList;               // ジャンプボタンの画像のリスト

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        _shapeId     = NormalId;
        _isSelecting = false;
        _goalPos     = _centerPos;
        _isJamping   = false;
    }


    /// <summary>
    /// 更新
    /// </summary>
    private void Update()
    {
        if (_isSelecting)
        {
            if (Input.GetMouseButtonUp(0))
            {
                _isSelecting = false;
            }

            return;
        }

        if (Input.GetMouseButtonDown(0) && Distance(GetLocalMousePosition(), _selecterTransform.localPosition) < _selectRange)
        {
            _isSelecting = true;
        }

        if (Input.GetMouseButtonDown(0) && Distance(GetLocalMousePosition(), _jampBottonTransform.localPosition) < _jampBottonSize)
        {
            _isJamping = true;
        }

        ////////////////////////////////////////////////////////////////
        
        //if(Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    _shapeId = SharpId;
        //}

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    _shapeId = NormalId;
        //}

        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    _shapeId = WideId;
        //}

        ////////////////////////////////////////////////////////////////
    }


    /// <summary>
    /// 補正更新
    /// </summary>
    private void FixedUpdate()
    {
        if (!_isSelecting)
        {
            switch (_shapeId)
            {
                case SharpId:
                    _goalPos = _centerPos + _barSize;
                    break;
                case NormalId:
                    _goalPos = _centerPos;
                    break;
                case WideId:
                    _goalPos = _centerPos - _barSize;
                    break;
            }
        }
        else
        {
            var mousePos = GetLocalMousePosition();

            if (_shapeId == SharpId)
            {
                if (mousePos.y < _centerPos + _barSize / 2)
                {
                    _shapeId = NormalId;
                }
            }
            else if (_shapeId == NormalId)
            {
                if (mousePos.y > _centerPos + _barSize / 2)
                {
                    _shapeId = SharpId;
                }
                else if (mousePos.y < _centerPos - _barSize / 2)
                {
                    _shapeId = WideId;
                }
            }
            else if (_shapeId == WideId)
            {
                if (mousePos.y > _centerPos - _barSize / 2)
                {
                    _shapeId = NormalId;
                }
            }

            _goalPos = mousePos.y;
            _goalPos = Mathf.Max(_goalPos, _centerPos - _barSize);
            _goalPos = Mathf.Min(_goalPos, _centerPos + _barSize);
        }

        var pos = _selecterTransform.localPosition;
        pos.y = _moveRate * _goalPos + (1 - _moveRate) * pos.y;
        _selecterTransform.localPosition = pos;

        _jampBottonSpriteRenderer.sprite = _spriteList[_shapeId];
    }


    /// <summary>
    /// local座標の取得
    /// </summary>
    /// <returns> local座標 </returns>
    private Vector3 GetLocalMousePosition()
    {
        var position = Input.mousePosition;

        var screenWorldPointPosition = Camera.main.ScreenToWorldPoint(position);

        return new Vector3(screenWorldPointPosition.x, screenWorldPointPosition.y, 0) - transform.position;
    }


    /// <summary>
    /// 距離
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    private float Distance(Vector2 v1,Vector2 v2)
    {
        return (v1 - v2).magnitude;
    }


    /// <summary>
    /// 形の識別番号
    /// </summary>
    /// <returns></returns>
    public int ShapeId()
    {
        return _shapeId;
    }


    /// <summary>
    /// ジャンプ
    /// </summary>
    /// <returns></returns>
    public bool Jamp()
    {
        bool rtn = _isJamping;
        _isJamping = false;
        return rtn;
    }


}
