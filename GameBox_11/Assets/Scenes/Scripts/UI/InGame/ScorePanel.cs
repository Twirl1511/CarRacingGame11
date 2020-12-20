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

    [SerializeField] private GameObject BarrelPlayer1_BlueCar_FULL;
    [SerializeField] private GameObject BarrelPlayer1_BlueMoto_FULL;
    [SerializeField] private GameObject BarrelPlayer2_RedCar_FULL;
    [SerializeField] private GameObject BarrelPlayer2_RedMoto_FULL;

    [SerializeField] private Text Player1_BlueCircleCounterText;
    [SerializeField] private Text Player2_RedCircleCounterText;
    [SerializeField] private Text Player1_BlueSpeedText;
    [SerializeField] private Text Player2_RedSpeedText;

    [SerializeField] private GameObject Player1_BlueCar;
    [SerializeField] private GameObject Player1_BlueMoto;
    [SerializeField] private GameObject Player2_RedCar;
    [SerializeField] private GameObject Player2_RedMoto;

    [SerializeField] private GameObject[] SpeedometerArrowsPlayer1_Blue;
    [SerializeField] private GameObject[] SpeedometerArrowsPlayer2_Red;
    [SerializeField] private GameObject Player1_BlueWinPanel;
    [SerializeField] private GameObject Player2_RedWinPanel;
    [SerializeField] private GameObject VictoryPanel;


    //void Update()
    //{
    //    DamageDone();
    //}
    //// потом убрать говнокод с ифами
    //private void DamageDone()
    //{

    //    #region[blue car 1]
    //    if (Player1_BlueCar.gameObject.activeSelf)
    //    {
    //        int numberOfCircle;
    //        for (int i = 0; i < SpeedometerArrowsPlayer2_Red.Length; i++)
    //        {
    //            numberOfCircle = Player2_RedCar.GetComponent<CircleCounter>().PlayerCircleCounter - 1;

    //            for (int j = 0; j < SpeedometerArrowsPlayer2_Red.Length; j++)
    //            {
    //                SpeedometerArrowsPlayer2_Red[j].SetActive(false);
    //            }
    //            if (numberOfCircle >= 0 && numberOfCircle < 10)
    //            {
    //                SpeedometerArrowsPlayer2_Red[numberOfCircle].SetActive(true);
    //                if (numberOfCircle == 9)
    //                {
    //                    VictoryPanel.SetActive(true);
    //                    Player2_RedWinPanel.SetActive(true);
    //                }
                        
    //            }
    //        }

    //        Player2_RedCircleCounterText.text = Player2_RedCar.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
    //        Player2_RedSpeedText.text = Player2_RedCar.GetComponent<Player_Controller>().PlayerSpeedLimit;

    //        switch (Player2_RedCar.GetComponent<Player_Controller>().HowManyDamagePlayerHas)
    //        {
    //            case 1:
    //                SpeedSticksPlayer2_Car[0].SetActive(false);
    //                break;
    //            case 2:
    //                SpeedSticksPlayer2_Car[1].SetActive(false);
    //                break;
    //            case 3:
    //                SpeedSticksPlayer2_Car[2].SetActive(false);
    //                break;
    //            case 4:
    //                SpeedSticksPlayer2_Car[3].SetActive(false);
    //                break;
    //            case 5:
    //                SpeedSticksPlayer2_Car[4].SetActive(false);
    //                break;
    //            default:
    //                break;
    //        }
    //        switch (Player2_RedCar.GetComponent<Player_Controller>().crushesCounter)
    //        {
    //            case 1:
    //                DurabilitySticksPlayer2_Car[0].SetActive(false);
    //                break;
    //            case 2:
    //                DurabilitySticksPlayer2_Car[1].SetActive(false);
    //                break;
    //            default:
    //                DurabilitySticksPlayer2_Car[0].SetActive(true);
    //                DurabilitySticksPlayer2_Car[1].SetActive(true);
    //                break;

    //        }
    //        if (Player2_RedCar.GetComponent<Player_Controller>().PlayerHasGotAnOil)
    //        {
    //            BarrelPlayer2_RedCar_FULL.SetActive(true);
    //        }
    //        else
    //        {
    //            BarrelPlayer2_RedCar_FULL.SetActive(false);
    //        }

    //    }
    //    #endregion
    //    #region[blue moto 1]
    //    if (Player2_RedMoto.gameObject.activeSelf)
    //    {
    //        int numberOfCircle;
    //        for (int i = 0; i < SpeedometerArrowsPlayer2_Red.Length; i++)
    //        {
    //            numberOfCircle = Player2_RedMoto.GetComponent<CircleCounter>().PlayerCircleCounter - 1;

    //            for (int j = 0; j < SpeedometerArrowsPlayer2_Red.Length; j++)
    //            {
    //                SpeedometerArrowsPlayer2_Red[j].SetActive(false);
    //            }
    //            if (numberOfCircle >= 0 && numberOfCircle < 10)
    //            {
    //                SpeedometerArrowsPlayer2_Red[numberOfCircle].SetActive(true);
    //                if (numberOfCircle == 9)
    //                {
    //                    VictoryPanel.SetActive(true);
    //                    Player2_RedWinPanel.SetActive(true);
    //                }
    //            }
    //        }

    //        Player2_RedCircleCounterText.text = Player2_RedMoto.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
    //        Player2_RedSpeedText.text = Player2_RedMoto.GetComponent<Player_Controller>().PlayerSpeedLimit;

    //        switch (Player2_RedMoto.GetComponent<Player_Controller>().HowManyDamagePlayerHas)
    //        {
    //            case 1:
    //                SpeedSticksPlayer2_Moto[0].SetActive(false);
    //                break;
    //            case 2:
    //                SpeedSticksPlayer2_Moto[1].SetActive(false);
    //                break;
    //            case 3:
    //                SpeedSticksPlayer2_Moto[2].SetActive(false);
    //                break;
    //            case 4:
    //                SpeedSticksPlayer2_Moto[3].SetActive(false);
    //                break;
    //            case 5:
    //                SpeedSticksPlayer2_Moto[4].SetActive(false);
    //                break;
    //            case 6:
    //                SpeedSticksPlayer2_Moto[5].SetActive(false);
    //                break;
    //            case 7:
    //                SpeedSticksPlayer2_Moto[6].SetActive(false);
    //                break;
    //            default:
    //                break;
    //        }
    //        switch (Player2_RedMoto.GetComponent<Player_Controller>().crushesCounter)
    //        {
    //            case 1:
    //                DurabilitySticksPlayer2_Moto[0].SetActive(false);
    //                break;
    //            default:
    //                DurabilitySticksPlayer2_Moto[0].SetActive(true);
    //                break;

    //        }
    //        if (Player2_RedMoto.GetComponent<Player_Controller>().PlayerHasGotAnOil)
    //        {
    //            BarrelPlayer2_RedMoto_FULL.SetActive(true);
    //        }
    //        else
    //        {
    //            BarrelPlayer2_RedMoto_FULL.SetActive(false);
    //        }
    //    }
    //    #endregion
    //    #region[red car 2]
    //    if (Player1_BlueCar.gameObject.activeSelf)
    //    {
    //        int numberOfCircle;
    //        for(int i = 0; i < SpeedometerArrowsPlayer1_Blue.Length; i++)
    //        {
    //            numberOfCircle = Player1_BlueCar.GetComponent<CircleCounter>().PlayerCircleCounter - 1;

    //            for(int j = 0; j < SpeedometerArrowsPlayer1_Blue.Length; j++)
    //            {
    //                SpeedometerArrowsPlayer1_Blue[j].SetActive(false);
    //            }
    //            if(numberOfCircle >= 0 && numberOfCircle < 10)
    //            {
    //                SpeedometerArrowsPlayer1_Blue[numberOfCircle].SetActive(true);
    //                if (numberOfCircle == 9)
    //                {
    //                    VictoryPanel.SetActive(true);
    //                    Player1_BlueWinPanel.SetActive(true);
    //                }
    //            }
    //        }

    //        Player1_BlueCircleCounterText.text = Player1_BlueCar.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
    //        Player1_BlueSpeedText.text = Player1_BlueCar.GetComponent<Player_Controller>().PlayerSpeedLimit;

    //        switch (Player1_BlueCar.GetComponent<Player_Controller>().HowManyDamagePlayerHas)
    //        {
    //            case 1:
    //                SpeedSticksPlayer1_Car[0].SetActive(false);
    //                break;
    //            case 2:
    //                SpeedSticksPlayer1_Car[1].SetActive(false);
    //                break;
    //            case 3:
    //                SpeedSticksPlayer1_Car[2].SetActive(false);
    //                break;
    //            case 4:
    //                SpeedSticksPlayer1_Car[3].SetActive(false);
    //                break;
    //            case 5:
    //                SpeedSticksPlayer1_Car[4].SetActive(false);
    //                break;
    //            default:
    //                break;
    //        }
    //        switch (Player1_BlueCar.GetComponent<Player_Controller>().crushesCounter)
    //        {
    //            case 1:
    //                DurabilitySticksPlayer1_Car[0].SetActive(false);
    //                break;
    //            case 2:
    //                DurabilitySticksPlayer1_Car[1].SetActive(false);
    //                break;
    //            default:
    //                DurabilitySticksPlayer1_Car[0].SetActive(true);
    //                DurabilitySticksPlayer1_Car[1].SetActive(true);
    //                break;

    //        }
    //        if (Player1_BlueCar.GetComponent<Player_Controller>().PlayerHasGotAnOil)
    //        {
    //            BarrelPlayer2_RedCar_FULL.SetActive(true);
    //        }
    //        else
    //        {
    //            BarrelPlayer2_RedCar_FULL.SetActive(false);
    //        }

    //    }
    //    #endregion
    //    #region[red moto 2]
    //    if (Player1_BlueMoto.gameObject.activeSelf)
    //    {
    //        int numberOfCircle;
    //        for (int i = 0; i < SpeedometerArrowsPlayer1_Blue.Length; i++)
    //        {
    //            numberOfCircle = Player1_BlueMoto.GetComponent<CircleCounter>().PlayerCircleCounter - 1;

    //            for (int j = 0; j < SpeedometerArrowsPlayer1_Blue.Length; j++)
    //            {
    //                SpeedometerArrowsPlayer1_Blue[j].SetActive(false);
    //            }
    //            if (numberOfCircle >= 0 && numberOfCircle < 10)
    //            {
    //                SpeedometerArrowsPlayer1_Blue[numberOfCircle].SetActive(true);
    //                if (numberOfCircle == 9)
    //                {
    //                    VictoryPanel.SetActive(true);
    //                    Player1_BlueWinPanel.SetActive(true);
    //                }
    //            }
    //        }


    //        Player1_BlueCircleCounterText.text = Player1_BlueMoto.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
    //        Player1_BlueSpeedText.text = Player1_BlueMoto.GetComponent<Player_Controller>().PlayerSpeedLimit;

    //        switch (Player1_BlueMoto.GetComponent<Player_Controller>().HowManyDamagePlayerHas)
    //        {
    //            case 1:
    //                SpeedSticksPlayer1_Moto[0].SetActive(false);
    //                break;
    //            case 2:
    //                SpeedSticksPlayer1_Moto[1].SetActive(false);
    //                break;
    //            case 3:
    //                SpeedSticksPlayer1_Moto[2].SetActive(false);
    //                break;
    //            case 4:
    //                SpeedSticksPlayer1_Moto[3].SetActive(false);
    //                break;
    //            case 5:
    //                SpeedSticksPlayer1_Moto[4].SetActive(false);
    //                break;
    //            case 6:
    //                SpeedSticksPlayer1_Moto[5].SetActive(false);
    //                break;
    //            case 7:
    //                SpeedSticksPlayer1_Moto[6].SetActive(false);
    //                break;
    //            default:
    //                break;
    //        }
    //        switch (Player1_BlueMoto.GetComponent<Player_Controller>().crushesCounter)
    //        {
    //            case 1:
    //                DurabilitySticksPlayer1_Moto[0].SetActive(false);
    //                break;
    //            default:
    //                DurabilitySticksPlayer1_Moto[0].SetActive(true);
    //                break;

    //        }
    //        if (Player1_BlueMoto.GetComponent<Player_Controller>().PlayerHasGotAnOil)
    //        {
    //            BarrelPlayer1_BlueMoto_FULL.SetActive(true);
    //        }
    //        else
    //        {
    //            BarrelPlayer1_BlueMoto_FULL.SetActive(false);
    //        }
    //    }
    //    #endregion
    //}
}
