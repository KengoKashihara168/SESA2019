using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEffectController : MonoBehaviour
{
    ParticleSystem starEffect; // 星のエフェクト

	// Use this for initialization
	void Start ()
    {
        starEffect = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update ()
    {
        
	}

    /// <summary>
    /// エフェクトの開始と停止
    /// </summary>
    /// <param name="isPlay"> true = "開始" / fasle = "停止" </param>
    public void Play(bool isPlay)
    {
        if (isPlay)
        {
            // 開始
            if (starEffect.isPlaying) return;
            starEffect.Play();
        }
        else
        {
            // 停止
            if (!starEffect.isPlaying) return;
            starEffect.Stop();
        }
    }
}
