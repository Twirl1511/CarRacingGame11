using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchRacer : MonoBehaviour
{
    [SerializeField] private GameObject[] Player1_RacersBlue;
    [SerializeField] private Button SwitchLeftPlayer1_Blue;
    [SerializeField] private Button SwitchRightPlayer1_Blue;

    [SerializeField] private GameObject[] Player2_RacersRed;
    [SerializeField] private Button SwitchLeftPlayer2_Red;
    [SerializeField] private Button SwitchRightPlayer2_Red;

    private int Player1_BlueRacerNumber = 0;
    private int Player2_RedRacerNumber = 0;

    public void OnLeftSwitchClickPlayer1_Blue()
    {
        Debug.Log("LEFT");
        Player1_BlueRacerNumber--;
        if (Player1_BlueRacerNumber < 0) Player1_BlueRacerNumber = 2;
        for (int i = 0; i < Player1_RacersBlue.Length; i++)
        {
            Player1_RacersBlue[i].SetActive(false);
        }
        Player1_RacersBlue[Player1_BlueRacerNumber].SetActive(true);
    }

    public void OnRightSwitchClickPlayer1_Blue()
    {
        Debug.Log("RIGHT");
        Player1_BlueRacerNumber++;
        if (Player1_BlueRacerNumber > 2) Player1_BlueRacerNumber = 0;
        for (int i = 0; i < Player1_RacersBlue.Length; i++)
        {
            Player1_RacersBlue[i].SetActive(false);
        }
        Player1_RacersBlue[Player1_BlueRacerNumber].SetActive(true);
    }

    public void OnLeftSwitchClickPlayer2_Red()
    {
        Player2_RedRacerNumber--;
        if (Player2_RedRacerNumber < 0) Player2_RedRacerNumber = 2;
        for (int i = 0; i < Player2_RacersRed.Length; i++)
        {
            Player2_RacersRed[i].SetActive(false);
        }
        Player2_RacersRed[Player2_RedRacerNumber].SetActive(true);
    }

    public void OnRightSwitchClickPlayer2_Red()
    {
        Player2_RedRacerNumber++;
        if (Player2_RedRacerNumber > 2) Player2_RedRacerNumber = 0;
        for (int i = 0; i < Player2_RacersRed.Length; i++)
        {
            Player2_RacersRed[i].SetActive(false);
        }
        Player2_RacersRed[Player2_RedRacerNumber].SetActive(true);
    }


}
