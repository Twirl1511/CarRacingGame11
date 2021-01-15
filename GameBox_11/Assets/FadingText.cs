using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingText : MonoBehaviour
{
    [SerializeField] private Image PressKeyToFropOil;
    [SerializeField] private GameObject PlayerStart;
    [SerializeField] private GameObject PlayerFinish;
    private GameObject _player;
    private float _distanse;
    private float _totalLength;
    private bool _flagCollision;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _flagCollision)
        {
            _player = collision.gameObject;
            _flagCollision = false;
        }
    }
    private void Start()
    {
        _flagCollision = true;
        _totalLength = (PlayerStart.transform.position - PlayerFinish.transform.position).magnitude;
    }
    void Update()
    {
        if(_player != null)
        {
            if(PressKeyToFropOil.fillAmount <= 0.1f)
            {
                PressKeyToFropOil.fillAmount = 0;
                _player = null;
                return;
            }
            _distanse = (_player.transform.position - PlayerFinish.transform.position).magnitude;
            PressKeyToFropOil.fillAmount = _distanse / _totalLength;
        }
    }
}
