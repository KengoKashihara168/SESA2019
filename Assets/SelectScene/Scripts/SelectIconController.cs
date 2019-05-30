using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIconController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] ParticleSystem starEffect;
    [SerializeField] private Transform targetStage;
    private float time;

    void Awake()
    {
        time = 0.0f;
    }

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {              
        Move();
    }

    public void SetTarget(Image stage)
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
}
