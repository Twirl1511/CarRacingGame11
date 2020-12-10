using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleCounterBar : MonoBehaviour
{
    [SerializeField] private GameObject TopLeftCornerObject;
    [SerializeField] private GameObject TopRightCornerObject;
    [SerializeField] private GameObject DownRightCornerObject;
    [SerializeField] private GameObject DownLeftCornerObject;

    [SerializeField] private Image[] BlueLineBars;
    [SerializeField] private Image[] RedLineBars;

    private bool FlagForTopLeftCorner = false;
    private bool FlagForTopRightCorner = false;
    private bool FlagForDownRightCorner = false;
    private bool FlagForDownLeftCorner = false;

    private float MagnitudeVertical;
    private float MagnitudeHorizontal;

    Vector2 TopLeftVector2;
    Vector2 TopRightVector2;
    Vector2 DownRightVector2;
    Vector2 DownLeftVector2;

    void Start()
    {
        TopLeftVector2 = new Vector2(TopLeftCornerObject.GetComponent<Transform>().position.x, TopLeftCornerObject.GetComponent<Transform>().position.y);
        TopRightVector2 = new Vector2(TopRightCornerObject.GetComponent<Transform>().position.x, TopRightCornerObject.GetComponent<Transform>().position.y);
        DownRightVector2 = new Vector2(DownRightCornerObject.GetComponent<Transform>().position.x, DownRightCornerObject.GetComponent<Transform>().position.y);
        DownLeftVector2 = new Vector2(DownLeftCornerObject.GetComponent<Transform>().position.x, DownLeftCornerObject.GetComponent<Transform>().position.y);
       

        MagnitudeVertical = (TopLeftVector2 - DownLeftVector2).magnitude;
        MagnitudeHorizontal = (TopRightVector2 - TopLeftVector2).magnitude;
       
    }
    private int barCounter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.GetComponent<Player_Controller>().Player.ToString().Equals("Player1") && collision.gameObject.Equals(TopLeftCornerObject))
        {
            FlagForTopLeftCorner = true;
        }
    }
    void Update()
    {
        if (this.GetComponent<Player_Controller>().Player.ToString().Equals("Player1") && FlagForTopLeftCorner)
        {
            float distancePlayerMoved = (this.GetComponent<Rigidbody2D>().position - TopLeftVector2).magnitude;
            
            BlueLineBars[barCounter].fillAmount = distancePlayerMoved / MagnitudeHorizontal;
            
            if (BlueLineBars[barCounter].fillAmount > 0.99f)
            {
                BlueLineBars[barCounter].fillAmount = 1;
                FlagForTopLeftCorner = false;
                barCounter++;
                BlueLineBars[barCounter].gameObject.SetActive(true);
                FlagForTopRightCorner = true;
            }
        }
       
        

    }
}
