﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil_Player1 : MonoBehaviour
{
    [SerializeField] private AudioSource OilDriftSound;
    [SerializeField] float ForwardForce = 50f;
    [SerializeField] float TorgueForce = 3000f;
    [SerializeField] float TimeToDisappear = 10;
    [SerializeField] private float TimeBeforeColliderActive = 2f;
    private bool ActivateColliderFlag = true;
    void Start()
    {
        StartCoroutine(DisappearOil());
        StartCoroutine(DelayForHostPlayerActive());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ActivateColliderFlag && collision.GetComponent<Player_Controller>().Player.ToString().Equals("Player1"))
        {
            
        }
        else
        {
            Vector2 v2 = collision.GetComponent<Rigidbody2D>().velocity;
            collision.GetComponent<Rigidbody2D>().AddForce(v2 * ForwardForce);
            collision.GetComponent<Rigidbody2D>().AddTorque(RandomDirection() * TorgueForce, ForceMode2D.Impulse);
            OilDriftSound.Play();
        }

    }

    private IEnumerator DisappearOil()
    {
        yield return new WaitForSeconds(TimeToDisappear);
        Destroy(gameObject.GetComponent<Collider2D>());
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    private IEnumerator DelayForHostPlayerActive()
    {
        yield return new WaitForSeconds(TimeBeforeColliderActive);
        ActivateColliderFlag = false;
    }

    /// <summary>
    /// возвращает -1 или 1 для выбора направления заноса
    /// </summary>
    /// <returns></returns>
    private int RandomDirection()
    {
        int rand = Random.Range(-1, 2);
        if (rand == 0)
        {
            rand = RandomDirection();
        }
        return rand;
    }
}