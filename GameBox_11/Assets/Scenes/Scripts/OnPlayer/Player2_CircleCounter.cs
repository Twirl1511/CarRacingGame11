using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_CircleCounter : MonoBehaviour
{
    public Collider2D Player2_Collider;

    public Collider2D Box1_Collider;
    public Collider2D Box2_Collider;
    public Collider2D Box3_Collider;
    public Collider2D Box4_Collider;

    private bool Player2_Box1_Flag;
    private bool Player2_Box2_Flag;
    private bool Player2_Box3_Flag;
    private bool Player2_Box4_Flag;

    public int PlayerCircleCounter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.Equals(Box3_Collider))
        {
            CircleComplete();
            Player2_Box3_Flag = true;
        }
        if (collision.Equals(Box4_Collider))
        {
            Player2_Box4_Flag = true;
        }
        if (collision.Equals(Box1_Collider))
        {
            Player2_Box1_Flag = true;
        }
        if (collision.Equals(Box2_Collider))
        {
            Player2_Box2_Flag = true;
        }
    }

    public void CircleComplete()
    {
        if(Player2_Box1_Flag &&
           Player2_Box2_Flag &&
           Player2_Box3_Flag &&
           Player2_Box4_Flag)
        {
            PlayerCircleCounter++;
            Player2_Box1_Flag = false;
            Player2_Box2_Flag = false;
            Player2_Box3_Flag = false;
            Player2_Box4_Flag = false;
        }
        
    }


}
