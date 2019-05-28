using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackManager : MonoBehaviour
{
    private int _loadId;
    [SerializeField] private List<Transform> _loadTransform;
    [SerializeField] private Sprite          _loadSprite;

    private int _backId;
    [SerializeField] private List<Transform> _backTransform;
    [SerializeField] private Sprite          _backSprite;

    [SerializeField] private Transform _playerTransform;

    void Start()
    {
        _loadId = 0;
        _backId = 0;
    }

    void Update()
    {
        manageLoad();
        manageBack();
    }

    void manageLoad()
    {
        var playerPos = _playerTransform.position;

        int j = (_loadId + 1) % 2;

        if (_loadTransform[_loadId].position.x < playerPos.x)
        {
            var pos = _loadTransform[j].localPosition;
            var size = _loadSprite.rect.size.x;

            Debug.Log(size);

            pos.x += size * 0.1f * _loadTransform[j].localScale.x;

            _loadTransform[j].localPosition = pos;

            _loadId = j;
        }
    }

    void manageBack()
    {
        var playerPos = _playerTransform.position;

        int j = (_backId + 1) % 2;

        if (_backTransform[_backId].position.x < playerPos.x)
        {
            var pos = _backTransform[j].localPosition;
            var size = _backSprite.rect.size.x;

            pos.x += size * 0.1f * _backTransform[j].localScale.x;

            _backTransform[j].localPosition = pos;

            _backId = j;
        }
    }
}
