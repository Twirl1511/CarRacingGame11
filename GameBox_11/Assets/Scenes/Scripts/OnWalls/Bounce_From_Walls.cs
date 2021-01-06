﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_From_Walls : MonoBehaviour
{
    [SerializeField] private Vector2 BounceDirection;
    [SerializeField] private float Force = 1000f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(BounceDirection * Force);
    }
}
