using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIconController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] ParticleSystem starEffect;
    private float time;
    private Transform targetStage;

	// Use this for initialization
	void Start ()
    {
        time = 0.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {              
        Move();
    }

    public void Migrate(Image stage)
    {
        targetStage = stage.transform;
    }

    void Move()
    {
        Vector2 from = transform.position;
        Vector2 to = targetStage.position;
        time = 1.0f / moveSpeed;
        transform.position = Vector2.Lerp(from, to, time);
    }

    float TargetDistance()
    {
        Vector2 from = transform.position;
        Vector2 to = targetStage.position;
        Vector2 distance = to - from;
        return distance.magnitude;
    }
}
