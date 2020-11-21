﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D PlayerRigidbody;
    private Transform PlayerTransform;
    [SerializeField] private float PlayerSpeed = 30f;
    [SerializeField] private float PlayerFirstSpeed = 50f;
    [SerializeField] private float FirstSpeedLimit = 8;
    [SerializeField] private float PlayerSecondSpeed = 80f;
    [SerializeField] private float SecondSpeedLimit = 13;
    [SerializeField] private float PlayerThirdSpeed = 100f;
    [SerializeField] private float ThirdSpeedLimit = 22;

    [SerializeField] private float PlayerTorgueForce = 45f;
    [SerializeField] private int PlayerSlowDown = 5;
    [SerializeField] private float PlayerDriftFactor = 0.93f;
    [SerializeField] private float PlayerSpeed_for_torgue = 3f;
    [SerializeField] private float PlayerCenterOfMass = 1f;

    public string PlayerSpeedLimit;
    [SerializeField] private GameObject OilPrefab;

    private bool PlayerHasGotAnOil = true;
    [SerializeField] float SpeedToCollectBarrel = 10;
    [SerializeField] GameObject OilDropPlaceFrom;

    [SerializeField] private Buttons PlayerForwardButton;
    [SerializeField] private Buttons PlayerHorizontalButton;
    [SerializeField] private Buttons PlayerDropOilButton;

    [SerializeField] private GameObject RaceMap;
    public enum Buttons
    {
        P1_forward,
        P2_forward,
        P1_horizontal,
        P2_horizontal,
        P1_back,
        P2_back
    }


    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        PlayerTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        PlayerRigidbody.GetComponent<ShowCenterOfMass>().CenterOfMass.y = PlayerCenterOfMass;
        PlayerSpeedLimit = PlayerRigidbody.velocity.magnitude.ToString("0.0");
        
    }

    void FixedUpdate()
    {
        #region [Player]

        #region[Основное управление]
        if (Input.GetButton(PlayerForwardButton.ToString()))
        {
            PlayerRigidbody.AddForce(PlayerTransform.up * PlayerSpeed);
        }

        PlayerRigidbody.AddTorque(Input.GetAxis(PlayerHorizontalButton.ToString()) * PlayerTorgueForce);

        #endregion

        // чтобы регулировать занос
        PlayerRigidbody.velocity = ForwardVelocity(PlayerTransform, PlayerRigidbody) + RightVelocity(PlayerTransform, PlayerRigidbody) * PlayerDriftFactor;

        #region[Логика разгона и ускорения]
        if (PlayerRigidbody.velocity.magnitude > FirstSpeedLimit)
        {
            PlayerSpeed = PlayerFirstSpeed;
        }
        if (PlayerRigidbody.velocity.magnitude > SecondSpeedLimit)
        {
            PlayerSpeed = PlayerSecondSpeed;
        }
        if (PlayerRigidbody.velocity.magnitude > ThirdSpeedLimit)
        {
            PlayerSpeed = PlayerThirdSpeed;
        }
        #endregion

        DropOil(OilPrefab);

        #endregion
    }
    /// <summary>
    /// выливаем масло
    /// </summary>
    /// <param name="Oil">префаб лужи масла</param>
    private void DropOil(GameObject Oil)
    {
        if (Input.GetButton(PlayerDropOilButton.ToString()) && PlayerHasGotAnOil)
        {
            PlayerHasGotAnOil = false;
            
            Vector3 oilPosition = new Vector3(OilDropPlaceFrom.transform.position.x, OilDropPlaceFrom.transform.position.y, 0);
            Instantiate(Oil, oilPosition, Quaternion.Euler(0,0,0));
            RaceMap.GetComponent<Barrel_controller>().CurrentBarrelsOnMap--;
        }
    }
    /// <summary>
    /// Собираем канистры с маслом
    /// </summary>
    /// <param name="collision">масло</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrel_Oil") && PlayerRigidbody.velocity.magnitude < SpeedToCollectBarrel
            && !PlayerHasGotAnOil)
        {
            PlayerHasGotAnOil = true;
            
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
