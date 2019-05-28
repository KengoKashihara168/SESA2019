using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Sprite nomalFace;
    [SerializeField] Sprite damageFace;
    [SerializeField] SpriteRenderer face;
    [SerializeField] Transform effect;
    private int shakeCount;
    private Rigidbody2D rigid;
    private float rot;

	// Use this for initialization
	void Start ()
    {
        effect.GetComponent<StarEffectController>().Play(true);
        effect.GetComponent<EffectSE>().Play();
        shakeCount = 1;
        rigid = GetComponent<Rigidbody2D>();
        rot = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        rigid.MoveRotation(rot);
        rot -= 5.0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Stop();
        effect.GetComponent<StarEffectController>().Play(false);
        effect.GetComponent<EffectSE>().Stop();
        if(shakeCount >= 0)
        {
            GameObject.Find("VcamManager").GetComponent<VCameraController>().Shake();
            shakeCount--;
        }

        StartCoroutine(ChangeFace());
    }

    private IEnumerator ChangeFace()
    {
        face.sprite = damageFace;

        yield return new WaitForSeconds(0.5f);

        face.sprite = nomalFace;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "ScreenArea")
        {
            SceneController.Instance.ChangeScene(SceneController.stageType.ToString(), 0.0f);
        }
    }
}
