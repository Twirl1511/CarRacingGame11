using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_panel : MonoBehaviour
{
    public GameObject Player1_car;
    public GameObject Player1_moto;
    public GameObject Player2_car;
    public GameObject Player2_moto;
    public Text Player1_Speed;
    public Text Player2_Speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1_car.gameObject.activeSelf)
        {
            Player1_Speed.text = Player1_car.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
        if (Player1_moto.gameObject.activeSelf)
        {
            Player1_Speed.text = Player1_moto.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
        if (Player2_car.gameObject.activeSelf)
        {
            Player2_Speed.text = Player2_car.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
        if (Player2_moto.gameObject.activeSelf)
        {
            Player2_Speed.text = Player2_moto.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
    }
}
