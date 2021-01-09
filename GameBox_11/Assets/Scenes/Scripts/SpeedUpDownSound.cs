using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpDownSound : MonoBehaviour
{
    [SerializeField] private AudioSource SpeedUpSound;
    [SerializeField] private AudioSource SpeedDownSound;

    private string _speedUpButton;
    private void Start()
    {
        _speedUpButton = gameObject.GetComponent<Player_Controller>().PlayerForwardButton.ToString();
    }
    private void FixedUpdate()
    {
        if (Input.GetButton(_speedUpButton))
        {
            if (SpeedUpSound.isPlaying)
            {
                return;
            }
            Player_Controller.PlaySound(gameObject, SpeedUpSound);
        }

        if (Input.GetButtonUp(_speedUpButton))
        {
            if (SpeedDownSound.isPlaying)
            {
                return;
            }
            Player_Controller.PlaySound(gameObject, SpeedDownSound);
        }
    }
}
