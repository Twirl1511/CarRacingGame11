using System.Collections;
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

    [SerializeField] private GameObject BarrelPlayer1_Car_FULL;
    [SerializeField] private GameObject BarrelPlayer1_Moto_FULL;
    [SerializeField] private GameObject BarrelPlayer2_Car_FULL;
    [SerializeField] private GameObject BarrelPlayer2_Moto_FULL;

    [SerializeField] private Text Player1_CircleCounterText;
    [SerializeField] private Text Player2_CircleCounterText;
    [SerializeField] private Text Player1_SpeedText;
    [SerializeField] private Text Player2_SpeedText;

    [SerializeField] private GameObject Player1_car;
    [SerializeField] private GameObject Player1_moto;
    [SerializeField] private GameObject Player2_car;
    [SerializeField] private GameObject Player2_moto;

    [SerializeField] private GameObject[] ArrowsPlayer1;
    [SerializeField] private GameObject[] ArrowsPlayer2;
    [SerializeField] private GameObject Player1_WinPanel;
    [SerializeField] private GameObject Player2_WinPanel;
    [SerializeField] private GameObject VictoryPanel;


    void Update()
    {
        DamageDone();
    }
    // потом уберать говнокод с ифами
    private void DamageDone()
    {
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
        #region[blue car 1]
        if (Player2_car.gameObject.activeSelf)
        {
            int numberOfCircle;
            for (int i = 0; i < ArrowsPlayer2.Length; i++)
            {
                numberOfCircle = Player2_car.GetComponent<CircleCounter>().PlayerCircleCounter - 1;

                for (int j = 0; j < ArrowsPlayer2.Length; j++)
                {
                    ArrowsPlayer2[j].SetActive(false);
                }
                if (numberOfCircle >= 0 && numberOfCircle < 10)
                {
                    ArrowsPlayer1[numberOfCircle].SetActive(true);
                    if (numberOfCircle == 9)
                    {
                        VictoryPanel.SetActive(true);
                        Player2_WinPanel.SetActive(true);
                    }
                        
                }
            }

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
            if (Player2_car.GetComponent<Player_Controller>().PlayerHasGotAnOil)
            {
                BarrelPlayer2_Car_FULL.SetActive(true);
            }
            else
            {
                BarrelPlayer2_Car_FULL.SetActive(false);
            }

        }
        #endregion
        #region[blue moto 1]
        if (Player2_moto.gameObject.activeSelf)
        {
            int numberOfCircle;
            for (int i = 0; i < ArrowsPlayer2.Length; i++)
            {
                numberOfCircle = Player2_moto.GetComponent<CircleCounter>().PlayerCircleCounter - 1;

                for (int j = 0; j < ArrowsPlayer2.Length; j++)
                {
                    ArrowsPlayer2[j].SetActive(false);
                }
                if (numberOfCircle >= 0 && numberOfCircle < 10)
                {
                    ArrowsPlayer2[numberOfCircle].SetActive(true);
                    if (numberOfCircle == 9)
                    {
                        VictoryPanel.SetActive(true);
                        Player2_WinPanel.SetActive(true);
                    }
                }
            }

            Player2_CircleCounterText.text = Player2_moto.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
            Player2_SpeedText.text = Player2_moto.GetComponent<Player_Controller>().PlayerSpeedLimit;

            switch (Player2_moto.GetComponent<Player_Controller>().HowManyDamagePlayerHas)
            {
                case 1:
                    SpeedSticksPlayer2_Moto[0].SetActive(false);
                    break;
                case 2:
                    SpeedSticksPlayer2_Moto[1].SetActive(false);
                    break;
                case 3:
                    SpeedSticksPlayer2_Moto[2].SetActive(false);
                    break;
                case 4:
                    SpeedSticksPlayer2_Moto[3].SetActive(false);
                    break;
                case 5:
                    SpeedSticksPlayer2_Moto[4].SetActive(false);
                    break;
                case 6:
                    SpeedSticksPlayer2_Moto[5].SetActive(false);
                    break;
                case 7:
                    SpeedSticksPlayer2_Moto[6].SetActive(false);
                    break;
                default:
                    break;
            }
            switch (Player2_moto.GetComponent<Player_Controller>().crushesCounter)
            {
                case 1:
                    DurabilitySticksPlayer2_Moto[0].SetActive(false);
                    break;
                default:
                    DurabilitySticksPlayer2_Moto[0].SetActive(true);
                    break;

            }
            if (Player2_moto.GetComponent<Player_Controller>().PlayerHasGotAnOil)
            {
                BarrelPlayer2_Moto_FULL.SetActive(true);
            }
            else
            {
                BarrelPlayer2_Moto_FULL.SetActive(false);
            }
        }
        #endregion
        #region[red car 2]
        if (Player1_car.gameObject.activeSelf)
        {
            int numberOfCircle;
            for(int i = 0; i < ArrowsPlayer1.Length; i++)
            {
                numberOfCircle = Player1_car.GetComponent<CircleCounter>().PlayerCircleCounter - 1;

                for(int j = 0; j < ArrowsPlayer1.Length; j++)
                {
                    ArrowsPlayer1[j].SetActive(false);
                }
                if(numberOfCircle >= 0 && numberOfCircle < 10)
                {
                    ArrowsPlayer1[numberOfCircle].SetActive(true);
                    if (numberOfCircle == 9)
                    {
                        VictoryPanel.SetActive(true);
                        Player1_WinPanel.SetActive(true);
                    }
                }
            }

            Player1_CircleCounterText.text = Player1_car.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
            Player1_SpeedText.text = Player1_car.GetComponent<Player_Controller>().PlayerSpeedLimit;

            switch (Player1_car.GetComponent<Player_Controller>().HowManyDamagePlayerHas)
            {
                case 1:
                    SpeedSticksPlayer1_Car[0].SetActive(false);
                    break;
                case 2:
                    SpeedSticksPlayer1_Car[1].SetActive(false);
                    break;
                case 3:
                    SpeedSticksPlayer1_Car[2].SetActive(false);
                    break;
                case 4:
                    SpeedSticksPlayer1_Car[3].SetActive(false);
                    break;
                case 5:
                    SpeedSticksPlayer1_Car[4].SetActive(false);
                    break;
                default:
                    break;
            }
            switch (Player1_car.GetComponent<Player_Controller>().crushesCounter)
            {
                case 1:
                    DurabilitySticksPlayer1_Car[0].SetActive(false);
                    break;
                case 2:
                    DurabilitySticksPlayer1_Car[1].SetActive(false);
                    break;
                default:
                    DurabilitySticksPlayer1_Car[0].SetActive(true);
                    DurabilitySticksPlayer1_Car[1].SetActive(true);
                    break;

            }
            if (Player1_car.GetComponent<Player_Controller>().PlayerHasGotAnOil)
            {
                BarrelPlayer1_Car_FULL.SetActive(true);
            }
            else
            {
                BarrelPlayer1_Car_FULL.SetActive(false);
            }

        }
        #endregion
        #region[red moto 2]
        if (Player1_moto.gameObject.activeSelf)
        {
            int numberOfCircle;
            for (int i = 0; i < ArrowsPlayer1.Length; i++)
            {
                numberOfCircle = Player1_moto.GetComponent<CircleCounter>().PlayerCircleCounter - 1;

                for (int j = 0; j < ArrowsPlayer1.Length; j++)
                {
                    ArrowsPlayer1[j].SetActive(false);
                }
                if (numberOfCircle >= 0 && numberOfCircle < 10)
                {
                    ArrowsPlayer1[numberOfCircle].SetActive(true);
                    if (numberOfCircle == 9)
                    {
                        VictoryPanel.SetActive(true);
                        Player1_WinPanel.SetActive(true);
                    }
                }
            }


            Player1_CircleCounterText.text = Player1_moto.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
            Player1_SpeedText.text = Player1_moto.GetComponent<Player_Controller>().PlayerSpeedLimit;

            switch (Player1_moto.GetComponent<Player_Controller>().HowManyDamagePlayerHas)
            {
                case 1:
                    SpeedSticksPlayer1_Moto[0].SetActive(false);
                    break;
                case 2:
                    SpeedSticksPlayer1_Moto[1].SetActive(false);
                    break;
                case 3:
                    SpeedSticksPlayer1_Moto[2].SetActive(false);
                    break;
                case 4:
                    SpeedSticksPlayer1_Moto[3].SetActive(false);
                    break;
                case 5:
                    SpeedSticksPlayer1_Moto[4].SetActive(false);
                    break;
                case 6:
                    SpeedSticksPlayer1_Moto[5].SetActive(false);
                    break;
                case 7:
                    SpeedSticksPlayer1_Moto[6].SetActive(false);
                    break;
                default:
                    break;
            }
            switch (Player1_moto.GetComponent<Player_Controller>().crushesCounter)
            {
                case 1:
                    DurabilitySticksPlayer1_Moto[0].SetActive(false);
                    break;
                default:
                    DurabilitySticksPlayer1_Moto[0].SetActive(true);
                    break;

            }
            if (Player1_moto.GetComponent<Player_Controller>().PlayerHasGotAnOil)
            {
                BarrelPlayer1_Moto_FULL.SetActive(true);
            }
            else
            {
                BarrelPlayer1_Moto_FULL.SetActive(false);
            }
        }
        #endregion
    }
}
