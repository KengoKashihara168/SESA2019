using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : StageObject
{
    [SerializeField] private float _fallSpeed; // 落下速度 

    protected override void NoPoseFixedUpdate()
    {
        var pos = transform.position;
        pos.y -= _fallSpeed;
        transform.position = pos;
    }

}
