﻿using System.Collections;
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
    private void Update()
    {
        PlaySpeedUpSound();
        PlaySpeedDownSound();
    }
    private void PlaySpeedUpSound()
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
    }
    private void PlaySpeedDownSound()
    {
        if (Input.GetButtonUp(_speedUpButton))
        {
            if (SpeedUpSound.isPlaying)
            {
                SpeedUpSound.Stop();
            }
            if (SpeedDownSound.isPlaying)
            {
                return;
            }
            Player_Controller.PlaySoundLerp(gameObject, SpeedDownSound);
        }
    }
}