using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoalController : MonoBehaviour
{
    [SerializeField] Animator anime;
    [SerializeField] ParticleSystem sparkle;
    [SerializeField] AudioClip[] audios;
    private AudioSource[] audioSources;

    const float ANIMATION_TIME = 4.0f;


    // Use this for initialization
    void Start ()
    {
        anime.StopPlayback();
        audioSources = GetComponents<AudioSource>();
        for(int i = 0;i < audios.Length;i++)
        {
            audioSources[i].clip = audios[i];
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void PlaySounds()
    {
        
        foreach (AudioSource i in audioSources)
        {
            i.Play();
        }
        StartCoroutine(FadeSound());
    }

    private IEnumerator FadeSound()
    {
        float time = 0.0f;
        float fadeVolume = audioSources[1].volume / (ANIMATION_TIME * 60.0f);
        while (time <= ANIMATION_TIME)
        {
            audioSources[1].volume -= fadeVolume;
            time += Time.deltaTime;                        
            yield return null;
        }
    }

    private void StopSounds()
    {
        foreach (AudioSource i in audioSources)
        {
            i.Stop();
        }
    }

    private void PlayEffect()
    {        
        sparkle.Play();
        sparkle.GetComponent<AudioSource>().Play();
        StartCoroutine(IsChange());
    }

    private IEnumerator IsChange()
    {
        if (!sparkle.isPlaying) yield break;

        while(sparkle.IsAlive(true))
        {
            yield return null;
        }

        SceneController.Instance.ChangeScene("SelectScene", 1.0f);
    }
}
