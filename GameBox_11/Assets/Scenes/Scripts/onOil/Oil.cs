using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    [SerializeField] private int TimeToCleanUpFromOil = 2;
    [SerializeField] private float AngularDragFactor = 1;
    [SerializeField] private float LinerDragFactor = 1;
    private float DefaultAngularDragFactor;
    private float DefaultLinerDragFactor;
    public bool Flag = true;
    [SerializeField] private float TimeToDisappear = 2;
    [SerializeField] private AudioSource OilDrugSound;

    private void Awake()
    {
        StartCoroutine(DisappearOil());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Flag)
        {
            DefaultAngularDragFactor = collision.gameObject.GetComponent<Rigidbody2D>().angularDrag;
            DefaultLinerDragFactor = collision.gameObject.GetComponent<Rigidbody2D>().drag;
            Flag = false;
            OilDrugSound.Play();
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().angularDrag = AngularDragFactor;
            collision.gameObject.GetComponent<Rigidbody2D>().drag = LinerDragFactor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SetDefaultForPlayer(collision));
        }
    }


    private IEnumerator SetDefaultForPlayer(Collider2D collision)
    {
        yield return new WaitForSeconds(TimeToCleanUpFromOil);
        collision.gameObject.GetComponent<Rigidbody2D>().angularDrag = DefaultAngularDragFactor;
        collision.gameObject.GetComponent<Rigidbody2D>().drag = DefaultLinerDragFactor;
        Flag = true;
    }

    private IEnumerator DisappearOil()
    {
        yield return new WaitForSeconds(TimeToDisappear);
        Destroy(this);

    }





}
