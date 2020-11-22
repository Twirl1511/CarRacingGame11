using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private Text Player1_CircleCounterText;
    [SerializeField] private Text Player2_CircleCounterText;
    [SerializeField] private Text Player1_SpeedText;
    [SerializeField] private Text Player2_SpeedText;

    [SerializeField] private GameObject Player1_car;
    [SerializeField] private GameObject Player1_moto;
    [SerializeField] private GameObject Player2_car;
    [SerializeField] private GameObject Player2_moto;
    
    void Update()
    {
        if (Player1_car.gameObject.activeSelf)
        {
            Player1_CircleCounterText.text = Player1_car.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
            Player1_SpeedText.text = Player1_car.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
        if (Player1_moto.gameObject.activeSelf)
        {
            Player1_CircleCounterText.text = Player1_moto.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
            Player1_SpeedText.text = Player1_moto.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
        if (Player2_car.gameObject.activeSelf)
        {
            Player2_CircleCounterText.text = Player2_car.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
            Player2_SpeedText.text = Player2_car.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
        if (Player2_moto.gameObject.activeSelf)
        {
            Player2_CircleCounterText.text = Player2_moto.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
            Player2_SpeedText.text = Player2_moto.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
    }
}
