using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class DamagePlayer1_BlueMoto : MonoBehaviour
{
    [SerializeField] private GameObject Player1_BlueMoto;
    
    [SerializeField] private Image Player1_DamageBar1;
    [SerializeField] private Image Player1_DamageBar2;

    void Update()
    {
        DamageDone();
    }

    private void DamageDone()
    {
        int crushesCounter = Player1_BlueMoto.GetComponent<Player_Controller>().crushesCounter;

        if (crushesCounter == 0)
        {
            Player1_DamageBar1.fillAmount = 1;
            Player1_DamageBar2.fillAmount = 1;
        }
        if (crushesCounter > 0) Player1_DamageBar1.fillAmount -= Time.deltaTime;
        if (crushesCounter > 1) Player1_DamageBar2.fillAmount -= Time.deltaTime * 8;
    }

}
