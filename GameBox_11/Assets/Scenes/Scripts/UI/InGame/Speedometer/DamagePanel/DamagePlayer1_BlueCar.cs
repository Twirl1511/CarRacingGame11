using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class DamagePlayer1_BlueCar : MonoBehaviour
{
    [SerializeField] private GameObject Player1_BlueCar;
    
    [SerializeField] private Image Player1_DamageBar1;
    [SerializeField] private Image Player1_DamageBar2;
    [SerializeField] private Image Player1_DamageBar3;

    void Update()
    {
        DamageDone();
    }

    private void DamageDone()
    {
        int crushesCounter = Player1_BlueCar.GetComponent<Player_Controller>().crushesCounter;
        int maxNumberOfDegradations = Player1_BlueCar.GetComponent<Player_Controller>().MaxNumberOfDegradations;
        int totalDamagePlayerHas = Player1_BlueCar.GetComponent<Player_Controller>().TotalDamagePlayerHas;



        if (crushesCounter == 0 && totalDamagePlayerHas <= maxNumberOfDegradations)
        {
            Player1_DamageBar1.fillAmount = 1;
            Player1_DamageBar2.fillAmount = 1;
            Player1_DamageBar3.fillAmount = 1;
        }
        if (crushesCounter > 0) Player1_DamageBar1.fillAmount -= Time.deltaTime;
        if (crushesCounter > 1) Player1_DamageBar2.fillAmount -= Time.deltaTime;
        if (crushesCounter > 2) Player1_DamageBar3.fillAmount -= Time.deltaTime * 8;
    }
}
