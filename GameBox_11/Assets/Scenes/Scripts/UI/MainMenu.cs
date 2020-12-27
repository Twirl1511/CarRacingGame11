using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject Player1_CarBlueButton;
    [SerializeField] private GameObject Player1_MotoBlueButton;
    [SerializeField] private GameObject Player1_MonsterBlueButton;

    [SerializeField] private GameObject SpeedometerPlayer1_BlueCar;
    [SerializeField] private GameObject SpeedometerPlayer1_BlueMoto;
    [SerializeField] private GameObject SpeedometerPlayer1_BlueMonster;


    [SerializeField] private GameObject Player2_CarRedButton;
    [SerializeField] private GameObject Player2_MotoRedButton;
    [SerializeField] private GameObject Player2_MonsterRedButton;

    [SerializeField] private GameObject SpeedometerPlayer2_RedCar;
    [SerializeField] private GameObject SpeedometerPlayer2_RedMoto;
    [SerializeField] private GameObject SpeedometerPlayer2_RedMonster;

    [SerializeField] private Button Start;
    [SerializeField] private Image MusicOn;
    [SerializeField] private Image MusicOff;
    [SerializeField] private Button Exit;

    [SerializeField] private GameObject Player1_CarBlue;
    [SerializeField] private GameObject Player1_MotoBlue;
    [SerializeField] private GameObject Player1_MonsterBlue;
    [SerializeField] private GameObject Player2_CarRed;
    [SerializeField] private GameObject Player2_MotoRed;
    [SerializeField] private GameObject Player2_MonsterRed;

    private bool SoundSwitch = false;
   

    public void OnStartButtonClick()
    {
        Player1_BlueTurnOn();
        Player2_RedTurnOn();
        gameObject.SetActive(false);
    }
    public void OnExitClick()
    {
        Debug.Log("!!!!!!!!!!");
        Application.Quit();
    }
    public void OnSoundClick()
    {
        SoundSwitch = !SoundSwitch;
        AudioListener.pause = SoundSwitch;
    }

    private void Player1_BlueTurnOn()
    {
        if (Player1_CarBlueButton.gameObject.activeSelf)
        {
            Player1_CarBlue.SetActive(true);
            SpeedometerPlayer1_BlueCar.SetActive(true);
        }
        if (Player1_MotoBlueButton.gameObject.activeSelf)
        {
            Player1_MotoBlue.SetActive(true);
            SpeedometerPlayer1_BlueMoto.SetActive(true);
        }
        if (Player1_MonsterBlueButton.gameObject.activeSelf)
        {
            Player1_MonsterBlue.SetActive(true);
            SpeedometerPlayer1_BlueMonster.SetActive(true);
        }
    }
    private void Player2_RedTurnOn()
    {
        if (Player2_CarRedButton.gameObject.activeSelf)
        {
            Player2_CarRed.SetActive(true);
            SpeedometerPlayer2_RedCar.SetActive(true);
        }
        if (Player2_MotoRedButton.gameObject.activeSelf)
        {
            Player2_MotoRed.SetActive(true);
            SpeedometerPlayer2_RedMoto.SetActive(true);
        }
        if (Player2_MonsterRedButton.gameObject.activeSelf)
        {
            Player2_MonsterRed.SetActive(true);
            SpeedometerPlayer2_RedMonster.SetActive(true);
        }
    }
}
