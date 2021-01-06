using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneForBrokenPieces : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BrokenPieces"))
        {
            collision.gameObject.SetActive(false);
            collision.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

}
