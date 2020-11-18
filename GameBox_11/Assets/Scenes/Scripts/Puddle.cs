﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    [SerializeField] private int TickTimer = 2;
    [SerializeField] private float DragFactor = 1;
    private float DefaultDragFactor;
    public bool Flag = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Flag)
        {
            DefaultDragFactor = collision.gameObject.GetComponent<Rigidbody2D>().angularDrag;
            Debug.Log("defaultDragFactor = " + DefaultDragFactor);
            Flag = false;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().angularDrag = DragFactor;
            Debug.Log("dragFactor = " + DragFactor);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("вышел из коллизии");
            Debug.Log("поворот = "+ collision.gameObject.GetComponent<Rigidbody2D>().angularDrag);
            StartCoroutine(SetDefaultForPlayer(collision));
        }
    }


    private IEnumerator SetDefaultForPlayer(Collider2D collision)
    {
        yield return new WaitForSeconds(TickTimer);
        collision.gameObject.GetComponent<Rigidbody2D>().angularDrag = DefaultDragFactor;
        Debug.Log("отработал метод сетфедаулт = " + DefaultDragFactor);
        Flag = true;
    }





}
