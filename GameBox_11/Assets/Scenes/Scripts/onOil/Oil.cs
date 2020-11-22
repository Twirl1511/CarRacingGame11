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
    private enum PlayerStates
    {
        stayOnOil,
        cleanedFromOil
    }
    private PlayerStates State = PlayerStates.cleanedFromOil;

    private void Awake()
    {
        StartCoroutine(DisappearOil());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (State.Equals(PlayerStates.cleanedFromOil))
        {
            DefaultAngularDragFactor = collision.gameObject.GetComponent<Rigidbody2D>().angularDrag;
            DefaultLinerDragFactor = collision.gameObject.GetComponent<Rigidbody2D>().drag;
        }
        collision.gameObject.GetComponent<Rigidbody2D>().angularDrag = AngularDragFactor;
        collision.gameObject.GetComponent<Rigidbody2D>().drag = LinerDragFactor;
        State = PlayerStates.stayOnOil;
        StartCoroutine(SetDefaultForPlayer(collision));
    }

    private IEnumerator SetDefaultForPlayer(Collider2D collision)
    {
        yield return new WaitForSeconds(TimeToCleanUpFromOil);
        collision.gameObject.GetComponent<Rigidbody2D>().angularDrag = DefaultAngularDragFactor;
        collision.gameObject.GetComponent<Rigidbody2D>().drag = DefaultLinerDragFactor;
        State = PlayerStates.cleanedFromOil;
        
    }

    private IEnumerator DisappearOil()
    {
        yield return new WaitForSeconds(TimeToDisappear);
        Destroy(gameObject.GetComponent<Collider2D>());
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }





}
