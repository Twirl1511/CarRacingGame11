using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWayIndicator : MonoBehaviour
{
    private Rigidbody2D PlayerRigidbody;
    public GameObject CarSprite;
    public GameObject Arrow;

    [SerializeField] private float TimeBeforeArrowShowedUp = 1.5f;

    public Collider2D WayBox1_Collider;
    public Collider2D WayBox2_Collider;
    public Collider2D WayBox3_Collider;
    public Collider2D WayBox4_Collider;

    public Transform box;
    private bool Flag = false;
    private void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();

        
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.Equals(WayBox1_Collider))
        {
            if (Vector2.Dot(PlayerRigidbody.velocity, Vector2.left) < 0)
            {

                    StartCoroutine(ShowArrow());

            }
            else
            {
                Arrow.SetActive(false);
            }
        }
    }

    private IEnumerator ShowArrow()
    {
        yield return new WaitForSeconds(TimeBeforeArrowShowedUp);
        Debug.Log("Wrong WAY!!!!");
        Arrow.SetActive(true);
        //Flag = true;
    }


}
