using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] float speed = 10f;
    [SerializeField] float torqueForce = 10f;
    [SerializeField] float driftFactor = 0.5f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Accelerate"))
        {
            Debug.Log("нажата Accelerate");
            //rb.AddRelativeForce(Vector2.up * speed);
            rb.AddForce(transform.up * speed);
        }
        if (Input.GetButton("Brakes"))
        {
            Debug.Log("нажата Brakes");
            rb.AddForce(transform.up * -speed/5);
        }

        //transform.Rotate(Input.GetAxis("Left") * new Vector3(0, 0, 1) * Time.deltaTime * torqueForce);

        rb.AddTorque(Input.GetAxis("Left") * torqueForce);


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
