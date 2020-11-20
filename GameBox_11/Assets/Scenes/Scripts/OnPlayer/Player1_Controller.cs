using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Controller : MonoBehaviour
{
    private Rigidbody2D Player1_Rigidbody;
    private Transform Player1_Transform;
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

    public string Player1_SpeedLimit;
    [SerializeField] private GameObject Oil;

    private int OilCounter = 1;
    [SerializeField] float SpeedToCollectOil = 10;
    [SerializeField] GameObject OilDropPlace;


    private void Awake()
    {
        Player1_Rigidbody = GetComponent<Rigidbody2D>();
        Player1_Transform = GetComponent<Transform>();
    }
    private void Update()
    {
        Player1_Rigidbody.GetComponent<ShowCenterOfMass>().CenterOfMass.y = Player1_CenterOfMass;
        Player1_SpeedLimit = Player1_Rigidbody.velocity.magnitude.ToString("0.0");
        
    }

    void FixedUpdate()
    {
        #region [Player_1]

        #region[Основное управление]
        if (Input.GetButton("P1_forward"))
        {
            Player1_Rigidbody.AddForce(Player1_Transform.up * Player1_Speed);
        }
        //if (Input.GetButton("P1_back"))
        //{
        //    Player1_Rigidbody.AddForce(Player1_Transform.up * -Player1_Speed / Player1_SlowDown);
        //}

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

        DropOil(Oil);

        #endregion
    }

    private void DropOil(GameObject Oil)
    {
        if (Input.GetButton("P1_back") && OilCounter > 0)
        {
            OilCounter--;
            
            Vector3 oilPosition = new Vector3(OilDropPlace.transform.position.x, OilDropPlace.transform.position.y, 0);
            Instantiate(Oil, oilPosition, Quaternion.Euler(0,0,0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrel_Oil") && Player1_Rigidbody.velocity.magnitude < SpeedToCollectOil)
        {
            OilCounter++;
            Destroy(collision.gameObject);
        }
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
