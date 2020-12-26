using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSensor : MonoBehaviour
{
    private GameObject Player1_Blue;
    [SerializeField] private GameObject Player1_BlueCar;
    [SerializeField] private GameObject Player1_BlueCarMoto;
    [SerializeField] private GameObject Player1_BlueMonster;
    private GameObject Player2_Red;
    [SerializeField] private GameObject Player2_RedCar;
    [SerializeField] private GameObject Player2_RedMoto;
    [SerializeField] private GameObject Player2_RedMonster;

    [SerializeField] private GameObject Player1_Oil;
    [SerializeField] private GameObject Player2_Oil;



    void Start()
    {
        WichPlayerIsActive();
    }

    // Update is called once per frame
    void Update()
    {
        OnOffOilSensor();
    }

    private void WichPlayerIsActive()
    {
        if (Player1_BlueCar.activeSelf) Player1_Blue = Player1_BlueCar;
        if (Player1_BlueCarMoto.activeSelf) Player1_Blue = Player1_BlueCarMoto;
        if (Player1_BlueMonster.activeSelf) Player1_Blue = Player1_BlueMonster;

        if (Player2_RedCar.activeSelf) Player2_Red = Player2_RedCar;
        if (Player2_RedMoto.activeSelf) Player2_Red = Player2_RedMoto;
        if (Player2_RedMonster.activeSelf) Player2_Red = Player2_RedMonster;
    }
    private void OnOffOilSensor()
    {
        if (Player1_Blue.GetComponent<Player_Controller>().PlayerHasGotAnOil)
        {
            Player1_Oil.SetActive(true);
        }
        else
        {
            Player1_Oil.SetActive(false);
        }

        if (Player2_Red.GetComponent<Player_Controller>().PlayerHasGotAnOil)
        {
            Player2_Oil.SetActive(true);
        }
        else
        {
            Player2_Oil.SetActive(false);
        }
    }
}
