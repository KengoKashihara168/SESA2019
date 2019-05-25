using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSE : MonoBehaviour
{
    private new AudioSource audio;

	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Play()
    {
        if (audio.isPlaying) return;
        audio.Play();
    }

    public void Stop()
    {
        if (!audio.isPlaying) return;
        audio.Stop();
    }
}
