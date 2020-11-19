using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Player1_Rigidbody;
    [SerializeField] private Rigidbody2D Player2_Rigidbody;
    [SerializeField] private Transform Player1_Transform;
    [SerializeField] private Transform Player2_Transform;

    [SerializeField] private float Player1_Speed = 110f;
    [SerializeField] private float Player1_SorgueForce = 45f;
    [SerializeField] private int Player1_SlowDown = 5;
    [SerializeField] private float Player2_Speed = 110f;
    [SerializeField] private float Player2_TorqueForce = 45f;
    [SerializeField] private int Player2_SlowDown = 5;
    [SerializeField] private float Player1_DriftFactor = 0.93f;
    [SerializeField] private float Player2_DriftFactor = 0.93f;

    [SerializeField] private float Player1_Speed_for_torgue = 3f;
    [SerializeField] private float Player2_Speed_for_torgue = 3f;



    void FixedUpdate()
    {
        #region [Player_1]

        if (Input.GetButton("P1_forward"))
        {
            Debug.Log("нажата P1_forward");
            Player1_Rigidbody.AddForce(Player1_Transform.up * Player1_Speed);
        }
        if (Input.GetButton("P1_back"))
        {
            Debug.Log("нажата P1_back");
            Player1_Rigidbody.AddForce(Player1_Transform.up * -Player1_Speed / Player1_SlowDown);
        }

        
        Player1_Rigidbody.AddTorque(Input.GetAxis("P1_horizontal") * Player1_SorgueForce);
        
            
        
        

        Player1_Rigidbody.velocity = ForwardVelocity(Player1_Transform, Player1_Rigidbody) + RightVelocity(Player1_Transform, Player1_Rigidbody) * Player1_DriftFactor;

        #endregion

        #region [Player_2]

        if (Input.GetButton("P2_forward"))
        {
            Debug.Log("нажата P2_forward");
            Player2_Rigidbody.AddForce(Player2_Transform.up * Player2_Speed);
        }
        if (Input.GetButton("P2_back"))
        {
            Debug.Log("нажата P2_back");
            Player2_Rigidbody.AddForce(Player2_Transform.up * -Player2_Speed / Player2_SlowDown);
        }


        
        Player2_Rigidbody.AddTorque(Input.GetAxis("P2_horizontal") * Player2_TorqueForce);
        

        Player2_Rigidbody.velocity = ForwardVelocity(Player2_Transform, Player2_Rigidbody) + RightVelocity(Player2_Transform, Player2_Rigidbody) * Player1_DriftFactor;

        
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
