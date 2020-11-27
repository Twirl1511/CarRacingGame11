using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleCounter : MonoBehaviour
{
    [SerializeField] private Collider2D BoxCollider1;
    [SerializeField] private Collider2D BoxCollider2;
    private float DistanceFor01Bar;
    private float DistanceFor1Bar;
    [SerializeField] private AudioSource CircleCompleteSound;
    private const int HOW_MANY_CIRCLES_TO_WIN = 10;
    [SerializeField] private AudioSource VictorySound;
    [SerializeField] private AudioSource HearBeatingSound;
    [SerializeField] private AudioSource GameSound;

    [SerializeField] private Image[] BlueLineBars;
    [SerializeField] private Image[] RedLineBars;


    private bool BoxCollider1Flag;
    private bool BoxCollider2Flag;
  

    [HideInInspector] public int PlayerCircleCounter = 0;
    

    public float Test = 0;
    private void Start()
    {
        //DistanceFor01Bar = (new Vector2(BoxCollider1.GetComponent<Transform>().position.x, BoxCollider1.GetComponent<Transform>().position.y)
        //    - new Vector2(BoxCollider2.GetComponent<Transform>().position.x, BoxCollider2.GetComponent<Transform>().position.y)).magnitude/10;
        DistanceFor1Bar = (new Vector2(BoxCollider1.GetComponent<Transform>().position.x, BoxCollider1.GetComponent<Transform>().position.y)
            - new Vector2(BoxCollider2.GetComponent<Transform>().position.x, BoxCollider2.GetComponent<Transform>().position.y)).magnitude;
        Debug.Log(DistanceFor1Bar);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.Equals(BoxCollider1))
        {
            CircleComplete();
            BoxCollider1Flag = true;
            

        }
        if (collision.Equals(BoxCollider2))
        {
            BoxCollider2Flag = true;
        }
        
    }

    public void CircleComplete()
    {
        if(BoxCollider1Flag && BoxCollider2Flag)
        {
            PlayerCircleCounter++;
            if (PlayerCircleCounter >= HOW_MANY_CIRCLES_TO_WIN - 1)
            {
                HearBeatingSound.Play();
            }
            if (PlayerCircleCounter >= HOW_MANY_CIRCLES_TO_WIN)
            {
                VictorySound.Play();
                GameSound.Stop();
                Time.timeScale = 0;
            }

            BoxCollider1Flag = false;
            BoxCollider2Flag = false;
            CircleCompleteSound.Play();
        }
        
    }
    private void Update()
    {

        float test = (this.GetComponent<Rigidbody2D>().position - new Vector2(BoxCollider1.GetComponent<Transform>().position.x,
            BoxCollider1.GetComponent<Transform>().position.y)).magnitude;
        if (BoxCollider1Flag)
        {
            
            BlueLineBars[0].fillAmount = test/ 1350;
            
        }
        
    }


}
