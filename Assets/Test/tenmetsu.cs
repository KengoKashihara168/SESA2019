using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tenmetsu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.Sin(Time.time * 2f));
    }
}
