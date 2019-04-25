using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public Camera mainCamera;
    public bool zoomFlag;
    Transform target;

	// Use this for initialization
	void Start ()
    {
        zoomFlag = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (zoomFlag)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 100.0f, 0.01f);
            mainCamera.transform.position = new Vector3(target.position.x, target.position.y, -10.0f);
        }
    }

    public void Zoom(Transform target)
    {
        zoomFlag = true;
        this.target = target;
     }
}
