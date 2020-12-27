using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class DamagePlayer2_RedCar : MonoBehaviour
{
    [SerializeField] private GameObject Player2_RedCar;
    
    [SerializeField] private Image Player2_DamageBar1;
    [SerializeField] private Image Player2_DamageBar2;
    [SerializeField] private Image Player2_DamageBar3;

    void Update()
    {
        DamageDone();
    }

    private void DamageDone()
    {
        int crushesCounter = Player2_RedCar.GetComponent<Player_Controller>().crushesCounter;
        int maxNumberOfDegradations = Player2_RedCar.GetComponent<Player_Controller>().MaxNumberOfDegradations;
        int totalDamagePlayerHas = Player2_RedCar.GetComponent<Player_Controller>().TotalDamagePlayerHas;

        if (crushesCounter == 0 && totalDamagePlayerHas <= maxNumberOfDegradations)
        {
            Player2_DamageBar1.fillAmount = 1;
            Player2_DamageBar2.fillAmount = 1;
            Player2_DamageBar3.fillAmount = 1;
        }
        if (crushesCounter > 0) Player2_DamageBar1.fillAmount -= Time.deltaTime;
        if (crushesCounter > 1) Player2_DamageBar2.fillAmount -= Time.deltaTime;
        if (crushesCounter > 2) Player2_DamageBar3.fillAmount -= Time.deltaTime * 8;
    }
}
