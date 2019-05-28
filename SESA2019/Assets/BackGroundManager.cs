using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] Sprite[]  backGrounds;
    [SerializeField] Sprite[]  floors;
    [SerializeField] Transform backGround;
    [SerializeField] Transform floor;
    private StageType          stage;

    private void Awake()
    {
        stage = SceneController.stageType;
    }

    // Use this for initialization
    void Start ()
    {
        backGround.GetComponent<SpriteRenderer>().sprite = backGrounds[(int)stage];
        floor.GetComponent<SpriteRenderer>().sprite      = floors[(int)stage];
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
