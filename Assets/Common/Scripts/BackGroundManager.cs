using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] Sprite[]  backGrounds; // 背景画像の配列
    [SerializeField] Sprite[]  floors;      // 床画像の配列
    [SerializeField] Transform backGround;  // 背景
    [SerializeField] Transform floor;       // 床
    private StageType          stage;       // 選択されたステージ

    private void Awake()
    {
        stage = SceneController.stageType;
    }

    // Use this for initialization
    void Start ()
    {
        // 背景と床に画像を適用
        backGround.GetComponent<SpriteRenderer>().sprite = backGrounds[(int)stage];
        floor.GetComponent<SpriteRenderer>().sprite      = floors[(int)stage];
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
