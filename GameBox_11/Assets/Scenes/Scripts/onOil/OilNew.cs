using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilNew : MonoBehaviour
{
    [SerializeField] float ForwardForce = 50f;
    [SerializeField] float TorgueForce = 1000f;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float rand = Random.Range(-1,2);
        
        Vector2 v2 = collision.GetComponent<Rigidbody2D>().velocity;
        collision.GetComponent<Rigidbody2D>().AddForce(v2 * ForwardForce);
        collision.GetComponent<Rigidbody2D>().AddTorque(rand * TorgueForce, ForceMode2D.Impulse);
        float randTrg = rand * TorgueForce;
        Debug.Log(randTrg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
