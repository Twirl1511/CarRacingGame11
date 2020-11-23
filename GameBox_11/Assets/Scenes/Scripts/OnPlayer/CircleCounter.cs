using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCounter : MonoBehaviour
{
    [SerializeField] private Collider2D Box1_Collider;
    [SerializeField] private Collider2D Box2_Collider;
    [SerializeField] private Collider2D Box3_Collider;
    [SerializeField] private Collider2D Box4_Collider;
    [SerializeField] private AudioSource CircleCompleteSound;
    private const int HOW_MANY_CIRCLES_TO_WIN = 10;
    [SerializeField] private AudioSource VictorySound;
    [SerializeField] private AudioSource HearBeatingSound;

    private bool Box1_Flag;
    private bool Box2_Flag;
    private bool Box3_Flag;
    private bool Box4_Flag;

    [HideInInspector] public int PlayerCircleCounter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.Equals(Box1_Collider))
        {
            CircleComplete();
            Box1_Flag = true;
        }
        if (collision.Equals(Box2_Collider))
        {
            Box2_Flag = true;
        }
        if (collision.Equals(Box3_Collider))
        {
            Box3_Flag = true;
        }
        if (collision.Equals(Box4_Collider))
        {
            Box4_Flag = true;
        }
    }

    public void CircleComplete()
    {
        if(Box1_Flag &&
           Box2_Flag &&
           Box3_Flag &&
           Box4_Flag)
        {
            PlayerCircleCounter++;
            if (PlayerCircleCounter >= HOW_MANY_CIRCLES_TO_WIN - 1)
            {
                HearBeatingSound.Play();
            }
            if (PlayerCircleCounter >= HOW_MANY_CIRCLES_TO_WIN)
            {
                VictorySound.Play();
                Time.timeScale = 0;
            }
            
            Box1_Flag = false;
            Box2_Flag = false;
            Box3_Flag = false;
            Box4_Flag = false;
            CircleCompleteSound.Play();
        }
        
    }


}
