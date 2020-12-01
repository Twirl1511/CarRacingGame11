using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private GameObject Player1_BlueVictoryPanel;
    [SerializeField] private GameObject Player2_RedVictoryPanel;

    [SerializeField] private GameObject Player1_BlueCar;
    [SerializeField] private GameObject Player1_BlueMoto;
    [SerializeField] private GameObject Player2_RedCar;
    [SerializeField] private GameObject Player2_RedMoto;


    private void Update()
    {
        ShowVictoryPanel();
    }
    private void ShowVictoryPanel()
    {
        if(Player1_BlueCar.activeSelf == true)
        {
            if(Player1_BlueCar.GetComponent<CircleCounter>().PlayerCircleCounter >= Player1_BlueCar.GetComponent<CircleCounter>().HOW_MANY_CIRCLES_TO_WIN)
            {
                Player1_BlueVictoryPanel.SetActive(true);
            }
        }
        if (Player1_BlueMoto.activeSelf == true)
        {
            if (Player1_BlueMoto.GetComponent<CircleCounter>().PlayerCircleCounter >= Player1_BlueMoto.GetComponent<CircleCounter>().HOW_MANY_CIRCLES_TO_WIN)
            {
                Player1_BlueVictoryPanel.SetActive(true);
            }
        }
        if (Player2_RedCar.activeSelf == true)
        {
            if (Player2_RedCar.GetComponent<CircleCounter>().PlayerCircleCounter >= Player2_RedCar.GetComponent<CircleCounter>().HOW_MANY_CIRCLES_TO_WIN)
            {
                Player2_RedVictoryPanel.SetActive(true);
            }
        }
        if (Player2_RedMoto.activeSelf == true)
        {
            if (Player2_RedMoto.GetComponent<CircleCounter>().PlayerCircleCounter >= Player2_RedMoto.GetComponent<CircleCounter>().HOW_MANY_CIRCLES_TO_WIN)
            {
                Debug.Log("победил красный мотик");
                Player2_RedVictoryPanel.SetActive(true);
            }
        }
    }
}
