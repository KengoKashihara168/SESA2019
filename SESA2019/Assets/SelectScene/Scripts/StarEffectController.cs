using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEffectController : MonoBehaviour
{
    ParticleSystem starEffect;

	// Use this for initialization
	void Start ()
    {
        starEffect = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update ()
    {
        
	}

    public void Play(bool isPlay)
    {
        if (isPlay)
        {
            if (starEffect.isPlaying) return;
            starEffect.Play();
        }
        else
        {
            if (!starEffect.isPlaying) return;
            starEffect.Stop();
        }
    }
}
