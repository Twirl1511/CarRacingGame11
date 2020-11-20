using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_From_Walls : MonoBehaviour
{
    [SerializeField] private Vector2 BounceDicertion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("!!");
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(BounceDicertion);
    }
}
