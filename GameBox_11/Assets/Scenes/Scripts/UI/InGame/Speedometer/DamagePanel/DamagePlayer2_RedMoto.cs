using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class DamagePlayer2_RedMoto : MonoBehaviour
{
    [SerializeField] private GameObject Player2_RedMoto;
    
    [SerializeField] private Image Player2_DamageBar1;
    [SerializeField] private Image Player2_DamageBar2;

    void Update()
    {
        DamageDone();
    }

    private void DamageDone()
    {
        int crushesCounter = Player2_RedMoto.GetComponent<Player_Controller>().crushesCounter;
        int maxNumberOfDegradations = Player2_RedMoto.GetComponent<Player_Controller>().MaxNumberOfDegradations;
        int totalDamagePlayerHas = Player2_RedMoto.GetComponent<Player_Controller>().TotalDamagePlayerHas;

        if (crushesCounter == 0 && totalDamagePlayerHas <= maxNumberOfDegradations)
        {
            Player2_DamageBar1.fillAmount = 1;
            Player2_DamageBar2.fillAmount = 1;
        }
        if (crushesCounter > 0) Player2_DamageBar1.fillAmount -= Time.deltaTime;
        if (crushesCounter > 1) Player2_DamageBar2.fillAmount -= Time.deltaTime * 8;
    }

}
