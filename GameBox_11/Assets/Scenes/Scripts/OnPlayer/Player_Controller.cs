﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D PlayerRigidbody;
    private Transform PlayerTransform;
    
    [SerializeField] private float CurrentPlayerSpeed = 30f;
    [SerializeField] private float PlayerFirstSpeed = 50f;
    [SerializeField] private float FirstSpeedLimit = 8;
    [SerializeField] private float PlayerSecondSpeed = 80f;
    [SerializeField] private float SecondSpeedLimit = 13;
    [SerializeField] public float PlayerThirdSpeed = 100f;
    [SerializeField] private float ThirdSpeedLimit = 22;

    [SerializeField] private float PlayerTorgueForce = 45f;
    [SerializeField] private float PlayerDriftFactor = 0.93f;
    [SerializeField] private float PlayerCenterOfMass = 1f;

    [HideInInspector] public string PlayerSpeedLimit;
    [SerializeField] private GameObject OilPrefab;

    public bool PlayerHasGotAnOil = true;
    [SerializeField] float SpeedToCollectBarrel = 10;
    [SerializeField] GameObject OilDropPlaceFrom;

    [SerializeField] private TypeOfRacer Racer;
    [SerializeField] private Buttons PlayerForwardButton;
    [SerializeField] private Buttons PlayerHorizontalButton;
    [SerializeField] private Buttons PlayerDropOilButton;

    [SerializeField] private GameObject RaceMap;
    [SerializeField] private float TimeBeforeNextDamageFromPlayers;
    [SerializeField] private int HowManyCrushesBeforeTakeDamage;

    [SerializeField] private AudioSource DropOlidSound;
    [SerializeField] private AudioSource PickUpBarrelSound;
    [SerializeField] private AudioSource OilDriftSound;
    [SerializeField] private AudioSource CrushSound;
    [SerializeField] private AudioSource DamageSound;

    public int HowManyDamagePlayerHas = 0;

    public Players Player;
    public enum Players
    {
        Player1,
        Playe2
    }
    private enum Buttons
    {
        P1_forward,
        P2_forward,
        P1_horizontal,
        P2_horizontal,
        P1_back,
        P2_back
    }
    public enum TypeOfRacer
    {
        Moto,
        Car
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
            PlayerRigidbody.AddForce(PlayerTransform.up * CurrentPlayerSpeed);
        }

        PlayerRigidbody.AddTorque(Input.GetAxis(PlayerHorizontalButton.ToString()) * PlayerTorgueForce);

        #endregion

        // чтобы регулировать занос
        PlayerRigidbody.velocity = ForwardVelocity(PlayerTransform, PlayerRigidbody) + RightVelocity(PlayerTransform, PlayerRigidbody) * PlayerDriftFactor;

        #region[Логика разгона и ускорения]
        if (PlayerRigidbody.velocity.magnitude > FirstSpeedLimit)
        {
            CurrentPlayerSpeed = PlayerFirstSpeed;
        }
        if (PlayerRigidbody.velocity.magnitude > SecondSpeedLimit)
        {
            CurrentPlayerSpeed = PlayerSecondSpeed;
        }
        if (PlayerRigidbody.velocity.magnitude > ThirdSpeedLimit)
        {
            CurrentPlayerSpeed = PlayerThirdSpeed;
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
            DropOlidSound.Play();
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
            PickUpBarrelSound.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Oil"))
        {
            OilDriftSound.Play();
        }
    }
    private bool flagToControlDamageFromPlayers = true;
    public int crushesCounter = 0;
    
    /// <summary>
    /// демаг и уменьшение третьей скорости от столкновений
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
            // эффект при коллизии с плеером, можно удариться не чаще определенного времени
            if (collision.gameObject.CompareTag("Player") && flagToControlDamageFromPlayers == true)
            {
                CrushSound.Play();
                crushesCounter++;
                flagToControlDamageFromPlayers = false;
                if(crushesCounter >= HowManyCrushesBeforeTakeDamage)
                {
                    if (Racer == TypeOfRacer.Moto) PlayerThirdSpeed -= 50;
                    if (Racer == TypeOfRacer.Car) PlayerThirdSpeed -= 30;
                    crushesCounter = 0;
                }
                
                StartCoroutine(DelayBeforeNextDemageFromPlayers(TimeBeforeNextDamageFromPlayers));
            } // если с любым другим объектом
            else if(!collision.gameObject.CompareTag("Player"))
            {
                crushesCounter++;
                CrushSound.Play();
            if (crushesCounter >= HowManyCrushesBeforeTakeDamage)
                {
                    if (Racer == TypeOfRacer.Moto) PlayerThirdSpeed -= 50;
                    if (Racer == TypeOfRacer.Car) PlayerThirdSpeed -= 30;
                HowManyDamagePlayerHas++;
                crushesCounter = 0;
                    DamageSound.Play();
                }
            }
    }
    private IEnumerator DelayBeforeNextDemageFromPlayers(float TimeBeforeNextDamageFromPlayers)
    {
        yield return new WaitForSeconds(TimeBeforeNextDamageFromPlayers);
        flagToControlDamageFromPlayers = true;
    }
   
    private void PlayOildDriftSound()
    {
        OilDriftSound.Play();
    }

    #region[Контроль заноса]
    private Vector2 RightVelocity(Transform transform, Rigidbody2D rigidbody)
    {
        return transform.right * Vector2.Dot(rigidbody.velocity, transform.right);
    }
    private Vector2 ForwardVelocity(Transform transform, Rigidbody2D rigidbody)
    {
        return transform.up * Vector2.Dot(rigidbody.velocity, transform.up);
    }
    #endregion

    
}
