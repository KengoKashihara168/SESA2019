using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIconController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private float time;
    private Transform stageTransform;

	// Use this for initialization
	void Start ()
    {
        time = 0.0f;
        stageTransform = GameObject.Find("Stage1").transform;
        //transform.SetParent(stage.transform);
        transform.GetChild(1).GetComponent<StarEffectController>().Play(!IsReach());
    }
	
	// Update is called once per frame
	void Update ()
    {              
        Move();
    }

    public void Migrate(Image nextStage)
    {
        //transform.SetParent(nextStage.transform);
        stageTransform = nextStage.transform;
    }

    void Move()
    {
        Vector2 from = transform.position;
        Vector2 to = stageTransform.position;
        time = 1.0f / moveSpeed;
        transform.position = Vector2.Lerp(from, to, time);
    }

    bool IsReach()
    {
        if (ParentDistance() <= 0.2f) return true;
        return false;
    }

    float ParentDistance()
    {
        Vector2 from = transform.position;
        Vector2 to = stageTransform.position;
        Vector2 distance = to - from;
        return distance.magnitude;
    }

    public Sprite GetTargetTextImage()
    {
        return stageTransform.gameObject.GetComponent<StageData>().textImage;
    }
}
