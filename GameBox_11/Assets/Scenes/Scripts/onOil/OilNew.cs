using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilNew : MonoBehaviour
{
    [SerializeField] float ForwardForce = 50f;
    [SerializeField] float TorgueForce = 1000f;
    [SerializeField] float TimeToDisappear = 10;
    [SerializeField] private float TimeBeforeColliderActive = 0.5f;
    void Start()
    {
        StartCoroutine(DisappearOil());
        StartCoroutine(DelayBeforeColliderActive());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float rand = Random.Range(-1,2);
        Vector2 v2 = collision.GetComponent<Rigidbody2D>().velocity;
        collision.GetComponent<Rigidbody2D>().AddForce(v2 * ForwardForce);
        collision.GetComponent<Rigidbody2D>().AddTorque(rand * TorgueForce, ForceMode2D.Impulse);
    }

    private IEnumerator DisappearOil()
    {
        yield return new WaitForSeconds(TimeToDisappear);
        Destroy(gameObject.GetComponent<Collider2D>());
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    private IEnumerator DelayBeforeColliderActive()
    {
        yield return new WaitForSeconds(TimeBeforeColliderActive);
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
