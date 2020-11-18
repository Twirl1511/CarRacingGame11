using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Panel : MonoBehaviour
{
    public Text Player1_CircleCounter;
    public Text Player2_CircleCounter;

    public Rigidbody2D Player1_Rigidbody;
    public Rigidbody2D Player2_Rigidbody;

    void Start()
    {
        
    }

    void Update()
    {
        Player1_CircleCounter.text = Player1_Rigidbody.GetComponent<Player1_CircleCounter>().PlayerCircleCounter.ToString();
        Player2_CircleCounter.text = Player2_Rigidbody.GetComponent<Player2_CircleCounter>().PlayerCircleCounter.ToString();
    }
}
