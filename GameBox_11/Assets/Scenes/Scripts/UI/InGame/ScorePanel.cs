﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private GameObject[] SpeedSticksPlayer1_Car;
    [SerializeField] private GameObject[] DurabilitySticksPlayer1_Car;
    [SerializeField] private GameObject[] SpeedSticksPlayer1_Moto;
    [SerializeField] private GameObject[] DurabilitySticksPlayer1_Moto;

    [SerializeField] private GameObject[] SpeedSticksPlayer2_Car;
    [SerializeField] private GameObject[] DurabilitySticksPlayer2_Car;
    [SerializeField] private GameObject[] SpeedSticksPlayer2_Moto;
    [SerializeField] private GameObject[] DurabilitySticksPlayer2_Moto;

    [SerializeField] private Text Player1_CircleCounterText;
    [SerializeField] private Text Player2_CircleCounterText;
    [SerializeField] private Text Player1_SpeedText;
    [SerializeField] private Text Player2_SpeedText;

    [SerializeField] private GameObject Player1_car;
    [SerializeField] private GameObject Player1_moto;
    [SerializeField] private GameObject Player2_car;
    [SerializeField] private GameObject Player2_moto;
    
    void Update()
    {
        DamageDone();
        //if (Player1_car.gameObject.activeSelf)
        //{
        //    Player1_CircleCounterText.text = Player1_car.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
        //    Player1_SpeedText.text = Player1_car.GetComponent<Player_Controller>().PlayerSpeedLimit;
        //}
        //if (Player1_moto.gameObject.activeSelf)
        //{
        //    Player1_CircleCounterText.text = Player1_moto.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
        //    Player1_SpeedText.text = Player1_moto.GetComponent<Player_Controller>().PlayerSpeedLimit;
        //}
        //if (Player2_car.gameObject.activeSelf)
        //{
        //    Player2_CircleCounterText.text = Player2_car.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
        //    Player2_SpeedText.text = Player2_car.GetComponent<Player_Controller>().PlayerSpeedLimit;
        //}
        //if (Player2_moto.gameObject.activeSelf)
        //{
        //    Player2_CircleCounterText.text = Player2_moto.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
        //    Player2_SpeedText.text = Player2_moto.GetComponent<Player_Controller>().PlayerSpeedLimit;
        //}
    }
    // потом уберать говнокод с ифами
    private void DamageDone()
    {
        if (Player1_car.gameObject.activeSelf)
        {
            Player1_CircleCounterText.text = Player1_car.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
            Player1_SpeedText.text = Player1_car.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
        if (Player1_moto.gameObject.activeSelf)
        {
            Player1_CircleCounterText.text = Player1_moto.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
            Player1_SpeedText.text = Player1_moto.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
        //blue car2
        if (Player2_car.gameObject.activeSelf)
        {
            Player2_CircleCounterText.text = Player2_car.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
            Player2_SpeedText.text = Player2_car.GetComponent<Player_Controller>().PlayerSpeedLimit;

            switch (Player2_car.GetComponent<Player_Controller>().HowManyDamagePlayerHas)
            {
                case 1:
                    SpeedSticksPlayer2_Car[0].SetActive(false);
                    break;
                case 2:
                    SpeedSticksPlayer2_Car[1].SetActive(false);
                    break;
                case 3:
                    SpeedSticksPlayer2_Car[2].SetActive(false);
                    break;
                case 4:
                    SpeedSticksPlayer2_Car[3].SetActive(false);
                    break;
                case 5:
                    SpeedSticksPlayer2_Car[4].SetActive(false);
                    break;
                default:
                    break;
            }
            switch (Player2_car.GetComponent<Player_Controller>().crushesCounter)
            {
                case 1:
                    DurabilitySticksPlayer2_Car[0].SetActive(false);
                    break;
                case 2:
                    DurabilitySticksPlayer2_Car[1].SetActive(false);
                    break;
                default:
                    DurabilitySticksPlayer2_Car[0].SetActive(true);
                    DurabilitySticksPlayer2_Car[1].SetActive(true);
                    break;

            }

        }
        if (Player2_moto.gameObject.activeSelf)
        {
            Player2_CircleCounterText.text = Player2_moto.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
            Player2_SpeedText.text = Player2_moto.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
    }
}
