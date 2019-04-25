using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectIconController : MonoBehaviour
{
    Transform moveEffect;

	// Use this for initialization
	void Start ()
    {
        GameObject stage = GameObject.Find("Stage1");
        transform.position = stage.transform.position;
        transform.SetParent(stage.transform);
        moveEffect = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update ()
    {              
        Move();
        moveEffect.GetComponent<StarEffectController>().Play(!IsReach());
    }

    public void Migrate(Image nextStage)
    {
        transform.SetParent(nextStage.transform);
    }

    void Move()
    {
        Vector2 from = transform.position;
        Vector2 to = transform.parent.transform.position;
        transform.position = Vector2.Lerp(from, to, 0.05f);        
    }

    bool IsReach()
    {
        if (ParentDistance() <= 0.2f) return true;
        return false;
    }

    float ParentDistance()
    {
        Vector2 from = transform.position;
        Vector2 to = transform.parent.transform.position;
        Vector2 distance = to - from;
        return distance.magnitude;
    }
}
