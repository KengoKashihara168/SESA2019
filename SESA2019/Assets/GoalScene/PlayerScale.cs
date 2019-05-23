using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScale : MonoBehaviour
{

    /// <summary>
    /// 徐々に縮小
    /// </summary>
    /// <param name="actionSecond">アクション実行時間</param>
    public void GradualSmaller(float actionSecond)
    {
        // スケールが0以下なら何もしない
        if (IsMinusVector(transform.localScale)) return;

        // 徐々に縮小
        Vector3 shrinkSize = transform.localScale / actionSecond;
        transform.localScale -= shrinkSize;
    }

    /// <summary>
    /// ベクターがマイナスか調べる
    /// </summary>
    /// <param name="vec">ベクター</param>
    /// <returns> + : false / - : true</returns>
    private bool IsMinusVector(Vector3 vec)
    {
        if (vec.x < 0.0f && vec.y < 0.0f && vec.z < 0.0f) return true;

        return false;
    }
}
