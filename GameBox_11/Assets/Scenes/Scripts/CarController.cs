using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public CarController[] players;
    [SerializeField] private Rigidbody2D rb1;
    [SerializeField] private Rigidbody2D rb2;
    [SerializeField] private Transform tr1;
    [SerializeField] private Transform tr2;

    [SerializeField] private float p1Speed = 110f;
    [SerializeField] private float p1TorqueForce = 45f;
    [SerializeField] private int p1SlowDown = 5;
    [SerializeField] private float p2Speed = 110f;
    [SerializeField] private float p2TorqueForce = 45f;
    [SerializeField] private int p2SlowDown = 5;
    [SerializeField] private float p1DriftFactor = 0.93f;
    [SerializeField] private float p2DriftFactor = 0.93f;
    


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

        rb1.velocity = ForwardVelocity(tr1, rb1) + RightVelocity(tr1, rb1) * p1DriftFactor;

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

        
        // math.lerp
        rb2.AddTorque(Input.GetAxis("P2_horizontal") * p2TorqueForce);

        rb2.velocity = ForwardVelocity(tr2, rb2) + RightVelocity(tr2, rb2) * p1DriftFactor;

        
        #endregion

    }

    private Vector2 RightVelocity(Transform tr, Rigidbody2D rb)
    {
        return tr.right * Vector2.Dot(rb.velocity, tr.right);
    }
    private Vector2 ForwardVelocity(Transform tr, Rigidbody2D rb)
    {
        return  tr.up * Vector2.Dot(rb.velocity, tr.up);
    }

   
}
