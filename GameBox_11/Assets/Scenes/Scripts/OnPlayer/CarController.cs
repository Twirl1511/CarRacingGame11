using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Player1_Rigidbody;
    [SerializeField] private Transform Player1_Transform;
    [SerializeField] private float Player1_Speed = 30f;
    [SerializeField] private float Player1_FirstSpeed = 50f;
    [SerializeField] private float Player1_SecondSpeed = 80f;
    [SerializeField] private float Player1_ThirdSpeed = 100f;
    [SerializeField] private float Player1_FirstSpeedLimit = 8;
    [SerializeField] private float Player1_SecondSpeedLimit = 13;
    [SerializeField] private float Player1_ThirdSpeedLimit = 22;

    [SerializeField] private float Player1_TorgueForce = 45f;
    [SerializeField] private int Player1_SlowDown = 5;
    [SerializeField] private float Player1_DriftFactor = 0.93f;
    [SerializeField] private float Player1_Speed_for_torgue = 3f;
    [SerializeField] private float Player1_CenterOfMass = 1f;


    [SerializeField] private Rigidbody2D Player2_Rigidbody;
    [SerializeField] private Transform Player2_Transform;
    [SerializeField] private float Player2_Speed = 20f;
    [SerializeField] private float Player2_FirstSpeed = 30f;
    [SerializeField] private float Player2_SecondSpeed = 50f;
    [SerializeField] private float Player2_ThirdSpeed = 80f;
    [SerializeField] private float Player2_FirstSpeedLimit = 8;
    [SerializeField] private float Player2_SecondSpeedLimit = 13;
    [SerializeField] private float Player2_ThirdSpeedLimit = 22;

    [SerializeField] private float Player2_TorqueForce = 45f;
    [SerializeField] private int Player2_SlowDown = 5;
    [SerializeField] private float Player2_DriftFactor = 0.93f;
    [SerializeField] private float Player2_Speed_for_torgue = 3f;
    [SerializeField] private float Player2_CenterOfMass = 1f;

    public string Player1_SpeedLimit;
    public string Player2_SpeedLimit;

    private void Update()
    {
        Player1_Rigidbody.GetComponent<ShowCenterOfMass>().CenterOfMass.y = Player1_CenterOfMass;
        Player2_Rigidbody.GetComponent<ShowCenterOfMass>().CenterOfMass.y = Player2_CenterOfMass;

        Player1_SpeedLimit = Player1_Rigidbody.velocity.magnitude.ToString("0.0");
        Player2_SpeedLimit = Player2_Rigidbody.velocity.magnitude.ToString("0.0");
    }

    void FixedUpdate()
    {
        #region [Player_1_MOTO]

        #region[Основное управление]
        if (Input.GetButton("P1_forward"))
        {
            Player1_Rigidbody.AddForce(Player1_Transform.up * Player1_Speed);
        }
        if (Input.GetButton("P1_back"))
        {
            Player1_Rigidbody.AddForce(Player1_Transform.up * -Player1_Speed / Player1_SlowDown);
        }

        Player1_Rigidbody.AddTorque(Input.GetAxis("P1_horizontal") * Player1_TorgueForce);

        #endregion

        // чтобы регулировать занос
        Player1_Rigidbody.velocity = ForwardVelocity(Player1_Transform, Player1_Rigidbody) + RightVelocity(Player1_Transform, Player1_Rigidbody) * Player1_DriftFactor;

        #region[Логика разгона и ускорения мотоцикла]
        if (Player1_Rigidbody.velocity.magnitude > Player1_FirstSpeedLimit)
        {
            Player1_Speed = Player1_FirstSpeed;
        }
        if (Player1_Rigidbody.velocity.magnitude > Player1_SecondSpeedLimit)
        {
            Player1_Speed = Player1_SecondSpeed;
        }
        if (Player1_Rigidbody.velocity.magnitude > Player1_ThirdSpeedLimit)
        {
            Player1_Speed = Player1_ThirdSpeed;
        }
        #endregion



        #endregion

        #region [Player_2_CAR]

        #region[Основное управление машинки]
        if (Input.GetButton("P2_forward"))
        {
            Player2_Rigidbody.AddForce(Player2_Transform.up * Player2_Speed);
        }
        if (Input.GetButton("P2_back"))
        {
            Player2_Rigidbody.AddForce(Player2_Transform.up * -Player2_Speed / Player2_SlowDown);
        }
        Player2_Rigidbody.AddTorque(Input.GetAxis("P2_horizontal") * Player2_TorqueForce);
        #endregion

        // контроль заноса
        Player2_Rigidbody.velocity = ForwardVelocity(Player2_Transform, Player2_Rigidbody) + RightVelocity(Player2_Transform, Player2_Rigidbody) * Player1_DriftFactor;


        #region[Логика разгона и ускорения машинки]
        if (Player2_Rigidbody.velocity.magnitude > Player2_FirstSpeedLimit)
        {
            Player2_Speed = Player2_FirstSpeed;
        }
        if (Player2_Rigidbody.velocity.magnitude > Player2_SecondSpeedLimit)
        {
            Player2_Speed = Player2_SecondSpeed;
        }
        if (Player2_Rigidbody.velocity.magnitude > Player2_ThirdSpeedLimit)
        {
            Player2_Speed = Player2_ThirdSpeed;
        }
        #endregion

        

        
        #endregion

    }

    private Vector2 RightVelocity(Transform transform, Rigidbody2D rigidbody)
    {
        return transform.right * Vector2.Dot(rigidbody.velocity, transform.right);
    }
    private Vector2 ForwardVelocity(Transform transform, Rigidbody2D rigidbody)
    {
        return transform.up * Vector2.Dot(rigidbody.velocity, transform.up);
    }

   
}
