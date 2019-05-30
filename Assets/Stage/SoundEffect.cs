using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] AudioClip[] audios;

    public const int RingSound   = 0;
    public const int JumpSound   = 1;
    public const int DamageSound = 2;
    public const int TransSound  = 3;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlaySE(int id)
    {
        AudioSource source = GetComponent<AudioSource>();
        if (source.clip == audios[id] && source.isPlaying) return;
        source.clip = audios[id];
        source.Play();
    }
}
