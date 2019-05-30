using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRing : StageObject
{
    private int            _time;           // 画像を変更するために使う
    private SpriteRenderer _spriteRenderer; // 右のリングのSpriteRenderer
    [SerializeField] private int            _initTime;         // 時間の初期化
    [SerializeField] private int            _changeSpriteSpan; // 画像を変更する期間
    [SerializeField] private List<Sprite>   _spriteList;       // 左のリングのSpriteのリスト


    protected override void Init()
    {
        _time = _initTime;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void NoPoseFixedUpdate()
    {
        if (++_time % _changeSpriteSpan == 0)
        {
            var id = (_time / _changeSpriteSpan) % _spriteList.Count;
            _spriteRenderer.sprite = _spriteList[id];
        }
    }
}
