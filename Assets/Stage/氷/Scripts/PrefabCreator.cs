using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] float createSpan;
    private float time;
    private Vector3 position;
    private Quaternion rotation;

	// Use this for initialization
	void Start ()
    {
        position = transform.position;
        rotation = transform.rotation;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(createSpan < time)
        {
            Instantiate(this.gameObject, position, rotation);
            time = 0.0f;
            Destroy(this.gameObject);
        }
        else
        {
            time += Time.deltaTime;
        }
	}
}
