using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private GameObject Player1_ArrowBlue;
    [SerializeField] private GameObject Player2_ArrowRed;
    [SerializeField] private GameObject Player1_CarBlue;
    [SerializeField] private GameObject Player1_MotoBlue;
    [SerializeField] private GameObject Player2_CarRed;
    [SerializeField] private GameObject Player2_MotoRed;
    private float Player1_BlueSpeed;
    private float Player2_RedSpeed;
    public float test;

    void Start()
    {
        
    }

    void Update()
    {
        ShowSpeed();
        BlueArrowMove();
        RedArrowMove();
    }

    private void ShowSpeed()
    {
        if (Player1_CarBlue.activeSelf)
        {
            Player1_BlueSpeed = Player1_CarBlue.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
        if (Player1_MotoBlue.activeSelf)
        {
            Player1_BlueSpeed = Player1_MotoBlue.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
        if (Player2_CarRed.activeSelf)
        {
            Player2_RedSpeed = Player2_CarRed.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
        if (Player2_MotoRed.activeSelf)
        {
            Player2_RedSpeed = Player2_MotoRed.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
    }
    private void BlueArrowMove()
    {

        Player1_ArrowBlue.transform.rotation = Quaternion.Euler(0,0,-1 * Player1_BlueSpeed/test);
    }
    private void RedArrowMove()
    {

        Player2_ArrowRed.transform.rotation = Quaternion.Euler(0, 0, -1 * Player2_RedSpeed / test);
    }

}
