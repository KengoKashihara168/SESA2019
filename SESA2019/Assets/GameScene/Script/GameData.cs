using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private static GameData _instance = new GameData(); // シングルトンのインスタンス

    private bool _isPosing; // 停止中なら true

    private GameData()
    {
        _isPosing = false;
    }

    public static GameData Instance()
    {
        return _instance;
    }

    public void Pose()
    {
        _isPosing = true;
    }

    public void NoPose()
    {
        _isPosing = false;
    }

    public bool IsPosing()
    {
        return _isPosing;
    }


}
