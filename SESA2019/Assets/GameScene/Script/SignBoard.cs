using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBoard : MonoBehaviour
{
    private bool _isOpened; // ウィンドウを開いている状態か

    [SerializeField] private Transform  _playerTransform;
    [SerializeField] private GameObject _messageWindow;


    private void FixedUpdate()
    {
        if (_isOpened && Input.GetMouseButtonDown(0))
        {
            GameData.Instance().NoPose();
            _messageWindow.SetActive(false);
            _isOpened = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Circle"))
        {
            _isOpened = true;
            GameData.Instance().Pose();
            _messageWindow.SetActive(true);
        }
    }

}
