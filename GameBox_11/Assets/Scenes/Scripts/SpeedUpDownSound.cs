using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpDownSound : MonoBehaviour
{
    [SerializeField] private AudioSource SpeedUpSound;
    [SerializeField] private AudioSource SpeedDownSound;

    private string _speedUpButton;
    private float _secondSpeedLimit;
    private float _thirdSpeedLimit;
    private float _fourthSpeedLimit;
    private float _finalSpeedLimit;
    private void Start()
    {
        _speedUpButton = gameObject.GetComponent<Player_Controller>().PlayerForwardButton.ToString();
        _secondSpeedLimit = gameObject.GetComponent<Player_Controller>().SecondSpeedLimit;
        _thirdSpeedLimit = gameObject.GetComponent<Player_Controller>().ThirdSpeedLimit;
        _fourthSpeedLimit = gameObject.GetComponent<Player_Controller>().FourthSpeedLimit;
        _finalSpeedLimit = gameObject.GetComponent<Player_Controller>().FinalSpeedLimit;
    }
    private void Update()
    {
        PlaySpeedUpDownSounds();
    }

    private void PlaySpeedUpDownSounds()
    {
        if (Input.GetButton(_speedUpButton))
        {
            if (SpeedDownSound.isPlaying)
            {
                SpeedDownSound.Stop();
            }
            Player_Controller.PlaySoundLerp(gameObject, SpeedUpSound);
        }
        else
        {
            SpeedUpSound.Stop();
        }

        if (Input.GetButtonUp(_speedUpButton))
        {
            if (SpeedDownSound.isPlaying)
            {
                return;
            }
            if (SpeedUpSound.isPlaying)
            {
                SpeedUpSound.Stop();
            }
            Player_Controller.PlaySoundLerp(gameObject, SpeedDownSound);
        }
    }
}
