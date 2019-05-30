using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    [SerializeField] Vector3 rotation;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.eulerAngles = rotation;
	}

    void ChangeFace(Sprite faseSprite)
    {
        GetComponent<SpriteRenderer>().sprite = faseSprite;

    }
}
