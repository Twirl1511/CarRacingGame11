using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_panel : MonoBehaviour
{
    public GameObject Player1_Controller;
    public GameObject Player2_Controller;
    public Text Player1_Speed;
    public Text Player2_Speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player1_Speed.text = Player1_Controller.GetComponent<Player1_Controller>().Player1_SpeedLimit;
        //Player2_Speed.text = Player2_Controller.GetComponent<Player2_Controller>().Player2_SpeedLimit;
    }
}
