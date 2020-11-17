using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    [SerializeField] int tickTimer = 2;
    [SerializeField] float dragFactor = 1;
    private float defaultDragFactor;
    private bool flag = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flag)
        {
            defaultDragFactor = collision.gameObject.GetComponent<Rigidbody2D>().angularDrag;
            Debug.Log("defaultDragFactor = " + defaultDragFactor);
        }
        flag = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().angularDrag = dragFactor;
            Debug.Log("dragFactor = " + dragFactor);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("вышел из коллизии");
            StartCoroutine(SetDefaultForPlayer(collision));
        }
    }
   


    private IEnumerator SetDefaultForPlayer(Collider2D collision)
    {
        yield return new WaitForSeconds(tickTimer);
        collision.gameObject.GetComponent<Rigidbody2D>().angularDrag = defaultDragFactor;
        Debug.Log("отработал метод сетфедаулт");
        flag = true;
    }





}
