using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacersLightController : MonoBehaviour
{
    private GameObject Player1_Blue;
    [SerializeField] private GameObject Player1_BlueCar;
    [SerializeField] private GameObject Player1_BlueCarMoto;
    [SerializeField] private GameObject Player1_BlueMonster;
    private GameObject Player2_Red;
    [SerializeField] private GameObject Player2_RedCar;
    [SerializeField] private GameObject Player2_RedMoto;
    [SerializeField] private GameObject Player2_RedMonster;

    void Start()
    {
        WhichPlayerIsActive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WhichPlayerIsActive()
    {
        if (Player1_BlueCar.activeSelf) Player1_Blue = Player1_BlueCar;
        if (Player1_BlueCarMoto.activeSelf) Player1_Blue = Player1_BlueCarMoto;
        if (Player1_BlueMonster.activeSelf) Player1_Blue = Player1_BlueMonster;

        if (Player2_RedCar.activeSelf) Player2_Red = Player2_RedCar;
        if (Player2_RedMoto.activeSelf) Player2_Red = Player2_RedMoto;
        if (Player2_RedMonster.activeSelf) Player2_Red = Player2_RedMonster;
    }
}
