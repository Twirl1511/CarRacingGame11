using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb1;
    [SerializeField] Rigidbody2D rb2;
    [SerializeField] Transform tr1;
    [SerializeField] Transform tr2;

    [SerializeField] float p1Speed = 110f;
    [SerializeField] float p1TorqueForce = 45f;
    [SerializeField] int p1SlowDown = 5;
    [SerializeField] float p2Speed = 110f;
    [SerializeField] float p2TorqueForce = 45f;
    [SerializeField] int p2SlowDown = 5;
    //[SerializeField] float driftFactor = 0.5f;


    void Start()
    {
        
    }

    void FixedUpdate()
    {

        #region [Player_1]

        if (Input.GetButton("P1_forward"))
        {
            Debug.Log("нажата P1_forward");
            rb1.AddForce(tr1.up * p1Speed);
        }
        if (Input.GetButton("P1_back"))
        {
            Debug.Log("нажата P1_back");
            rb1.AddForce(tr1.up * -p1Speed / p1SlowDown);
        }

        rb1.AddTorque(Input.GetAxis("P1_horizontal") * p1TorqueForce);

        rb1.velocity = Vector2.Dot(rb1.velocity, tr1.up) * tr1.up;
        #endregion

        #region [Player_2]

        if (Input.GetButton("P2_forward"))
        {
            Debug.Log("нажата P2_forward");
            rb2.AddForce(tr2.up * p2Speed);
        }
        if (Input.GetButton("P2_back"))
        {
            Debug.Log("нажата P2_back");
            rb2.AddForce(tr2.up * -p2Speed / p2SlowDown);
        }

        rb2.AddTorque(Input.GetAxis("P2_horizontal") * p2TorqueForce);

        rb2.velocity = Vector2.Dot(rb2.velocity, tr2.up) * tr2.up;
        #endregion

    }

    private Vector2 RightVelocity()
    {
        return transform.right * Vector2.Dot(rb1.velocity, transform.right);
    }
    private Vector2 ForwardVelocity()
    {
        return  transform.up * Vector2.Dot(rb1.velocity, transform.up);
    }

   
}
