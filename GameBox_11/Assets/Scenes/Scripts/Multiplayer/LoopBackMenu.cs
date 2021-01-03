using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackMenu : MonoBehaviour
{
    
    public GameObject[] Racers;
    public static int pointer = 0;

    public void SwitchLeft()
    {
        pointer--;
        if (pointer < 0) pointer = 2;
        for(int i = 0; i < Racers.Length; i++)
        {
            Racers[i].SetActive(false);
        }
        Racers[pointer].SetActive(true);
    }
    public void SwitchRight()
    {
        pointer++;
        if (pointer > 2) pointer = 0;
        for (int i = 0; i < Racers.Length; i++)
        {
            Racers[i].SetActive(false);
        }
        Racers[pointer].SetActive(true);
    }
}
