using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForTesting : MonoBehaviour
{
    [SerializeField] private Text Player1_BlueTextSpeedMagnitude;
    [SerializeField] private Text Player2_RedTextSpeedMagnitude;
    [SerializeField] private GameObject Player1_BlueCar;
    [SerializeField] private GameObject Player1_BlueMoto;
    [SerializeField] private GameObject Player2_RedCar;
    [SerializeField] private GameObject Player2_RedMoto;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1_BlueCar.activeSelf)
        {
            Player1_BlueTextSpeedMagnitude.text = Player1_BlueCar.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
        if (Player1_BlueMoto.activeSelf)
        {
            Player1_BlueTextSpeedMagnitude.text = Player1_BlueMoto.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
        if (Player2_RedCar.activeSelf)
        {
            Player2_RedTextSpeedMagnitude.text = Player2_RedCar.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
        if (Player2_RedMoto.activeSelf)
        {
            Player2_RedTextSpeedMagnitude.text = Player2_RedMoto.GetComponent<Player_Controller>().PlayerSpeedLimit;
        }
    }
}
