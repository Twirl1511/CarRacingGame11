using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerSelection : MonoBehaviour
{
    public GameObject[] Player1_Racers;
    public GameObject[] Player2_Racers;

    public Transform Player1_Spot;
    public Transform Player2_Spot;

    private void Awake()
    {
        Instantiate(Player1_Racers[1], Player1_Spot.position, Quaternion.Euler(0,0,90));
        Instantiate(Player2_Racers[0], Player2_Spot.position, Quaternion.Euler(0, 0, -90));
    }
}
