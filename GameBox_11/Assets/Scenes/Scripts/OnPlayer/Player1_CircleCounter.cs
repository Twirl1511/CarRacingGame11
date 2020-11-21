using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_CircleCounter : MonoBehaviour
{
    [SerializeField] private Collider2D Box1_Collider;
    [SerializeField] private Collider2D Box2_Collider;
    [SerializeField] private Collider2D Box3_Collider;
    [SerializeField] private Collider2D Box4_Collider;

    private bool Playe1_Box1_Flag;
    private bool Playe1_Box2_Flag;
    private bool Playe1_Box3_Flag;
    private bool Playe1_Box4_Flag;

    [HideInInspector] public int PlayerCircleCounter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.Equals(Box1_Collider))
        {
            CircleComplete();
            Playe1_Box1_Flag = true;
        }
        if (collision.Equals(Box2_Collider))
        {
            Playe1_Box2_Flag = true;
        }
        if (collision.Equals(Box3_Collider))
        {
            Playe1_Box3_Flag = true;
        }
        if (collision.Equals(Box4_Collider))
        {
            Playe1_Box4_Flag = true;
        }
    }

    public void CircleComplete()
    {
        if(Playe1_Box1_Flag &&
           Playe1_Box2_Flag &&
           Playe1_Box3_Flag &&
           Playe1_Box4_Flag)
        {
            PlayerCircleCounter++;
            Playe1_Box1_Flag = false;
            Playe1_Box2_Flag = false;
            Playe1_Box3_Flag = false;
            Playe1_Box4_Flag = false;
        }
        
    }


}
