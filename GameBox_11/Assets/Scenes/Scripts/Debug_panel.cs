using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_panel : MonoBehaviour
{
    public GameObject CarController;
    public Text CarSpeedLimit;
    public Text MotoSpeedLimit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CarSpeedLimit.text = CarController.GetComponent<CarController>().Player2_SpeedLimit;
        MotoSpeedLimit.text = CarController.GetComponent<CarController>().Player1_SpeedLimit;
    }
}
