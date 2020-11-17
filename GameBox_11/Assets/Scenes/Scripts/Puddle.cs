using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    [SerializeField] private int tickTimer = 2;
    [SerializeField] private float dragFactor = 1;
    private float defaultDragFactor;
    public bool flag = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flag)
        {
            defaultDragFactor = collision.gameObject.GetComponent<Rigidbody2D>().angularDrag;
            Debug.Log("defaultDragFactor = " + defaultDragFactor);
            flag = false;
        }
        
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
            Debug.Log("поворот = "+ collision.gameObject.GetComponent<Rigidbody2D>().angularDrag);
            StartCoroutine(SetDefaultForPlayer(collision));
        }
    }


    private IEnumerator SetDefaultForPlayer(Collider2D collision)
    {
        yield return new WaitForSeconds(tickTimer);
        collision.gameObject.GetComponent<Rigidbody2D>().angularDrag = defaultDragFactor;
        Debug.Log("отработал метод сетфедаулт = " + defaultDragFactor);
        flag = true;
    }





}
