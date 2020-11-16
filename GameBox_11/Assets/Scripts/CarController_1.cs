using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController_1 : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] float speed = 10f;
    [SerializeField] float torqueForce = 10f;
    [SerializeField] int slowDown = 5;
    [SerializeField] float driftFactor = 0.5f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("P1_forward"))
        {
            Debug.Log("нажата P1_forward");
            rb.AddForce(transform.up * speed);
        }
        if (Input.GetButton("P1_back"))
        {
            Debug.Log("нажата P1_back");
            rb.AddForce(transform.up * -speed/slowDown);
        }

        rb.AddTorque(Input.GetAxis("P1_horizontal") * torqueForce);

        rb.velocity = Vector2.Dot(rb.velocity, transform.up) * transform.up;
    }

    private Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(rb.velocity, transform.right);
    }
    private Vector2 ForwardVelocity()
    {
        return  transform.up * Vector2.Dot(rb.velocity, transform.up);
    }

   
}
