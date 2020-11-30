using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleCounter : MonoBehaviour
{
    [SerializeField] private Collider2D BoxCollider1;
    [SerializeField] private Collider2D BoxCollider2;

    [SerializeField] private Collider2D BoxCollider1ForBar;
    [SerializeField] private Collider2D BoxCollider2ForBar;

    [SerializeField] private float DistanceFor1Bar;
    [SerializeField] private AudioSource CircleCompleteSound;
    private const int HOW_MANY_CIRCLES_TO_WIN = 10;
    [SerializeField] private AudioSource VictorySound;
    [SerializeField] private AudioSource HearBeatingSound;
    [SerializeField] private AudioSource GameSound;

    [SerializeField] private Image[] BlueLineBars;
    [SerializeField] private Image[] RedLineBars;


    private bool BoxCollider1Flag;
    private bool BoxCollider2Flag;

    private bool BoxCollider1FlagForBar = true;
    private bool BoxCollider2FlagForBar = false;


    [HideInInspector] public int PlayerCircleCounter = 0;
    

    public float Test = 0;
    private void Start()
    {
        //DistanceFor01Bar = (new Vector2(BoxCollider1.GetComponent<Transform>().position.x, BoxCollider1.GetComponent<Transform>().position.y)
        //    - new Vector2(BoxCollider2.GetComponent<Transform>().position.x, BoxCollider2.GetComponent<Transform>().position.y)).magnitude/10;
        DistanceFor1Bar = (new Vector2(BoxCollider1ForBar.GetComponent<Transform>().position.x, BoxCollider1ForBar.GetComponent<Transform>().position.y)
            - new Vector2(BoxCollider2ForBar.GetComponent<Transform>().position.x, BoxCollider2ForBar.GetComponent<Transform>().position.y)).magnitude * 1.2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.Equals(BoxCollider1))
        {
            CircleComplete();
            BoxCollider1Flag = true;
            //BoxCollider1FlagForBar = true;

        }
        if (collision.Equals(BoxCollider2))
        {
            BoxCollider2Flag = true;
            //BoxCollider2FlagForBar = true;
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
    private float distancePlayerMoved = 0f;
    private int barCounter = 0;
    private void Update()
    {

        if (this.GetComponent<Player_Controller>().Player.ToString().Equals("Player1"))
        {   
            if (BoxCollider1FlagForBar)
            {
                float distancePlayerMoved = (this.GetComponent<Rigidbody2D>().position - new Vector2(BoxCollider1ForBar.GetComponent<Transform>().position.x,
                BoxCollider1ForBar.GetComponent<Transform>().position.y)).magnitude;
                BlueLineBars[barCounter].fillAmount = distancePlayerMoved / DistanceFor1Bar;
                if (BlueLineBars[barCounter].fillAmount > 0.9f)
                {
                    BlueLineBars[barCounter].fillAmount = 1;
                    BoxCollider1FlagForBar = false;
                    barCounter++;
                    BlueLineBars[barCounter].gameObject.SetActive(true);
                    BoxCollider2FlagForBar = true;
                }
            }

            if (BoxCollider2FlagForBar)
            {
                float distancePlayerMoved = (this.GetComponent<Rigidbody2D>().position - new Vector2(BoxCollider2ForBar.GetComponent<Transform>().position.x,
                BoxCollider2ForBar.GetComponent<Transform>().position.y)).magnitude;
                BlueLineBars[barCounter].fillAmount = distancePlayerMoved / DistanceFor1Bar;
                if (BlueLineBars[barCounter].fillAmount > 0.9f)
                {
                    BlueLineBars[barCounter].fillAmount = 1;
                    BoxCollider2FlagForBar = false;
                    barCounter++;
                    BlueLineBars[barCounter].gameObject.SetActive(true);
                    BoxCollider1FlagForBar = true;


                }
            }
        }

        if (this.GetComponent<Player_Controller>().Player.ToString().Equals("Player2"))
        {
            if (BoxCollider1FlagForBar)
            {
                float distancePlayerMoved = (this.GetComponent<Rigidbody2D>().position - new Vector2(BoxCollider1ForBar.GetComponent<Transform>().position.x,
                BoxCollider1ForBar.GetComponent<Transform>().position.y)).magnitude;
                RedLineBars[barCounter].fillAmount = distancePlayerMoved / DistanceFor1Bar;
                if (RedLineBars[barCounter].fillAmount > 0.9f)
                {
                    RedLineBars[barCounter].fillAmount = 1;
                    BoxCollider1FlagForBar = false;
                    barCounter++;
                    RedLineBars[barCounter].gameObject.SetActive(true);
                    BoxCollider2FlagForBar = true;
                }
            }

            if (BoxCollider2FlagForBar)
            {
                float distancePlayerMoved = (this.GetComponent<Rigidbody2D>().position - new Vector2(BoxCollider2ForBar.GetComponent<Transform>().position.x,
                BoxCollider2ForBar.GetComponent<Transform>().position.y)).magnitude;
                RedLineBars[barCounter].fillAmount = distancePlayerMoved / DistanceFor1Bar;
                if (RedLineBars[barCounter].fillAmount > 0.9f)
                {
                    RedLineBars[barCounter].fillAmount = 1;
                    BoxCollider2FlagForBar = false;
                    barCounter++;
                    RedLineBars[barCounter].gameObject.SetActive(true);
                    BoxCollider1FlagForBar = true;


                }
            }
        }
    }




}
