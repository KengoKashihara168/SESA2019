using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : StageObject
{
    private bool _flag; // 
    [SerializeField] private Transform _meteoTransform; // 隕石のTransform
    [SerializeField] private float     _fallSpeed;      // 落下速度 

    protected override void Init()
    {
        _flag = false;
    }

    protected override void NoPoseFixedUpdate()
    {
        if (!_flag) return;

        var pos = _meteoTransform.position;
        pos.y -= _fallSpeed;
        _meteoTransform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Circle"))
        {
            _flag = true;
        }
    }
}
