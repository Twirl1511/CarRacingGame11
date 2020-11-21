using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWayIndicator : MonoBehaviour
{
    private Rigidbody2D PlayerRigidbody;
    [SerializeField] private GameObject WrongWaySign;

    [SerializeField] private float TimeBeforeSignShowedUp = 1.5f;

    public Collider2D LeftWayBoxCollider;
    public Collider2D UpWayBoxCollider;
    public Collider2D RightWayBoxCollider;
    public Collider2D DownWayBoxCollider;

    private bool WrongWayFlag = true;

    private void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        #region [WayBox1]
        if (collision.Equals(LeftWayBoxCollider))
        {
            if (Vector2.Dot(PlayerRigidbody.velocity, Vector2.left) < 0)
            {
                if (WrongWayFlag)
                {
                    WrongWayFlag = false;
                    StartCoroutine(ShowSign());
                }
            }
            else
            {
                WrongWayFlag = true;
                WrongWaySign.SetActive(false);
            }
        }
        #endregion
        #region [WayBox2]
        if (collision.Equals(UpWayBoxCollider))
        {
            if (Vector2.Dot(PlayerRigidbody.velocity, Vector2.up) < 0)
            {
                if (WrongWayFlag)
                {
                    WrongWayFlag = false;
                    StartCoroutine(ShowSign());
                }
            }
            else
            {
                WrongWaySign.SetActive(false);
            }
        }
        #endregion
        #region [WayBox3]
        if (collision.Equals(RightWayBoxCollider))
        {
            if (Vector2.Dot(PlayerRigidbody.velocity, Vector2.right) < 0)
            {
                if (WrongWayFlag)
                {
                    WrongWayFlag = false;
                    StartCoroutine(ShowSign());
                }
            }
            else
            {
                WrongWaySign.SetActive(false);
            }
        }
        #endregion
        #region [WayBox4]
        if (collision.Equals(DownWayBoxCollider))
        {
            if (Vector2.Dot(PlayerRigidbody.velocity, Vector2.down) < 0)
            {
                if (WrongWayFlag)
                {
                    WrongWayFlag = false;
                    StartCoroutine(ShowSign());
                }
            }
            else
            {
                WrongWaySign.SetActive(false);
            }
        }
        #endregion
    }

    private IEnumerator ShowSign()
    {
        yield return new WaitForSeconds(TimeBeforeSignShowedUp);
        if (!WrongWayFlag)
        {
            WrongWaySign.SetActive(true);
        }
        WrongWayFlag = true;
    }


}
