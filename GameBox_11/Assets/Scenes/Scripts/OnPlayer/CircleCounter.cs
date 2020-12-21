using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleCounter : MonoBehaviour
{
    private Vector2 CenterVector;
    [SerializeField] private Text BlueTextForInt;
    [SerializeField] private Text BlueTextForFloat;

    [SerializeField] private Collider2D BoxCollider1;
    [SerializeField] private Collider2D BoxCollider2;

    [SerializeField] private AudioSource CircleCompleteSound;
    [HideInInspector] public int HOW_MANY_CIRCLES_TO_WIN = 10;
    [SerializeField] private AudioSource VictorySound;
    [SerializeField] private AudioSource HearBeatingSound;
    [SerializeField] private AudioSource GameSound;

    private bool BoxCollider1Flag;
    private bool BoxCollider2Flag;


    [HideInInspector] public int PlayerCircleCounter = 0;

    private void Awake()
    {
        CenterVector = BoxCollider1.gameObject.transform.position.normalized;
    }
    private void Update()
    {
        if (BoxCollider1Flag)
        {
            CenterVector = BoxCollider1.gameObject.transform.position.normalized;
            float degrees = Vector2.Angle(CenterVector, transform.position);
            float floats = degrees / 36;
            BlueTextForFloat.text = Mathf.Floor(floats).ToString();

        }
        if(BoxCollider1Flag && BoxCollider2Flag)
        {
            CenterVector = BoxCollider2.gameObject.transform.position.normalized;
            float degrees = Vector2.Angle(CenterVector, transform.position);
            float floats = (degrees / 36) + 5;
            BlueTextForFloat.text = Mathf.Floor(floats).ToString();
        }
        if (BlueTextForFloat.text.Equals("0"))
        {
            BlueTextForFloat.gameObject.SetActive(false);
            BlueTextForInt.text = PlayerCircleCounter.ToString();
        }
        else
        {
            BlueTextForFloat.gameObject.SetActive(true);
            BlueTextForInt.text = PlayerCircleCounter.ToString() + '.'; 
        }
        
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
                StartCoroutine(DelayForPauseAfterFinish(1f));
            }

            BoxCollider1Flag = false;
            BoxCollider2Flag = false;
            CircleCompleteSound.Play();
        }
    }

    IEnumerator DelayForPauseAfterFinish(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        Time.timeScale = 0;
    }
 
    




}
