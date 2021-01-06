using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private GameObject MainVictoryPanel;
    [SerializeField] private GameObject Player1_BlueVictoryPanel;
    [SerializeField] private GameObject Player2_RedVictoryPanel;

    [SerializeField] private GameObject Player1_BlueCar;
    [SerializeField] private GameObject Player1_BlueMoto;
    [SerializeField] private GameObject Player1_BlueMonster;
    [SerializeField] private GameObject Player2_RedCar;
    [SerializeField] private GameObject Player2_RedMoto;
    [SerializeField] private GameObject Player2_RedMonster;


    private void Update()
    {
        ShowVictoryPanel();
    }
    private void ShowVictoryPanel()
    {
        if(Player1_BlueCar.activeSelf == true)
        {
            if(Player1_BlueCar.GetComponent<CircleCounter>().PlayerCircleCounter >= CircleCounter.HOW_MANY_CIRCLES_TO_WIN)
            {
                MainVictoryPanel.SetActive(true);
                Player1_BlueVictoryPanel.SetActive(true);
            }
        }
        if (Player1_BlueMoto.activeSelf == true)
        {
            if (Player1_BlueMoto.GetComponent<CircleCounter>().PlayerCircleCounter >= CircleCounter.HOW_MANY_CIRCLES_TO_WIN)
            {
                MainVictoryPanel.SetActive(true);
                Player1_BlueVictoryPanel.SetActive(true);
            }
        }
        if (Player1_BlueMonster.activeSelf == true)
        {
            if (Player1_BlueMonster.GetComponent<CircleCounter>().PlayerCircleCounter >= CircleCounter.HOW_MANY_CIRCLES_TO_WIN)
            {
                MainVictoryPanel.SetActive(true);
                Player1_BlueVictoryPanel.SetActive(true);
            }
        }

        if (Player2_RedCar.activeSelf == true)
        {
            if (Player2_RedCar.GetComponent<CircleCounter>().PlayerCircleCounter >= CircleCounter.HOW_MANY_CIRCLES_TO_WIN)
            {
                MainVictoryPanel.SetActive(true);
                Player2_RedVictoryPanel.SetActive(true);
            }
        }
        if (Player2_RedMoto.activeSelf == true)
        {
            if (Player2_RedMoto.GetComponent<CircleCounter>().PlayerCircleCounter >= CircleCounter.HOW_MANY_CIRCLES_TO_WIN)
            {
                MainVictoryPanel.SetActive(true);
                Player2_RedVictoryPanel.SetActive(true);
            }
        }
        if (Player2_RedMonster.activeSelf == true)
        {
            if (Player2_RedMonster.GetComponent<CircleCounter>().PlayerCircleCounter >= CircleCounter.HOW_MANY_CIRCLES_TO_WIN)
            {
                MainVictoryPanel.SetActive(true);
                Player2_RedVictoryPanel.SetActive(true);
            }
        }
    }
}
