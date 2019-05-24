using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] Animator anime;
    [SerializeField] ParticleSystem sparkle;

	// Use this for initialization
	void Start ()
    {
        anime.StopPlayback();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void PlayEffect()
    {
        sparkle.Play();
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
