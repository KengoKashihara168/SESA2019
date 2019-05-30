using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Vector2   _offset;          // プレイヤーとカメラのずれ
    [SerializeField] private float     _cameraMoveRate;  // カメラの移動の比率
    [SerializeField] private Transform _playerTransform; // プレイヤーのTransform

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        var playerPos = new Vector3(_playerTransform.localPosition.x, _playerTransform.localPosition.y,
            transform.localPosition.z);
        playerPos.x += _offset.x;
        playerPos.y += _offset.y;

        var pos =
            _cameraMoveRate * transform.localPosition
            + (1 - _cameraMoveRate) * playerPos;

        transform.localPosition = pos;
    }

}
