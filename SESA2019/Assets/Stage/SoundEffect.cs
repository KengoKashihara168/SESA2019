using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] AudioClip[] audios;
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
        source.clip = audios[id];
        source.Play();
    }
}
