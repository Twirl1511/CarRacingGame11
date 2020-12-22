using System.Collections;
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
    [SerializeField] private float PlayerThirdSpeed = 80f;
    [SerializeField] private float ThirdSpeedLimit = 13;
    [SerializeField] private float PlayerFourthSpeed = 80f;
    [SerializeField] private float FourthSpeedLimit = 13;
    [SerializeField] public float PlayerFinalSpeed = 100f;
    [SerializeField] private float FinalSpeedLimit = 22;

    [SerializeField] private float PlayerTorgueForce = 45f;
    [SerializeField] private float PlayerDriftFactor = 0.93f;
    [SerializeField] private float PlayerCenterOfMass = 1f;

    [HideInInspector] public string PlayerSpeedLimit;

    public bool PlayerHasGotAnOil = true;
    [SerializeField] float SpeedToCollectBarrel = 10;
    public GameObject OilDropPlaceFrom;

    [SerializeField] public TypeOfRacer Racer;
    [SerializeField] private Buttons PlayerForwardButton;
    [SerializeField] private Buttons PlayerHorizontalButton;
    public Buttons PlayerDropOilButton;

    [SerializeField] private GameObject RaceMap;
    [SerializeField] private float TimeBeforeNextDamageFromPlayers;
    

    [SerializeField] private AudioSource DropOlidSound;
    [SerializeField] private AudioSource PickUpBarrelSound;
    [SerializeField] private AudioSource CrushSound;
    [SerializeField] private AudioSource DamageSound;

    ///на сколько уменьшается скорость при уменьшении дюрабилити в ноль 
    [SerializeField] private float SpeedDegradation;
    /// <summary>
    /// предотвращаем многократное получение демага при врезании в другого игрока
    /// </summary>
    private bool flagToControlDamageFromPlayers = true;
    /// <summary>
    /// сколько демага получил игрок, когда набирается максимум, счетчик сбрасывается в ноль
    /// </summary>
    public int crushesCounter = 0;
    /// <summary>
    ///  максимум урона прежде чем уменьшить скорость
    /// </summary>
    public int HowManyCrushesBeforeTakeDamage;
    /// <summary>
    /// сколько степеней даградации есть у плеера
    /// </summary>
    public int MaxNumberOfDegradations;
    /// <summary>
    /// сколько степеней деградации уже получил плеер
    /// </summary>
    public int TotalDamagePlayerHas;

    public Players Player;
    public enum Players
    {
        Player1,
        Player2
    }
    public enum Buttons
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
        Car,
        Monster
    }

    private float speedToTorgue = 25f;


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
        #region [Player movement]

        #region[Основное управление]
        if (Input.GetButton(PlayerForwardButton.ToString()))
        {
            PlayerRigidbody.AddForce(PlayerTransform.up * CurrentPlayerSpeed);
        }
        /// поворот активен если только скорость больше значения
        if(PlayerRigidbody.velocity.magnitude > speedToTorgue)
        {
            PlayerRigidbody.AddTorque(Input.GetAxis(PlayerHorizontalButton.ToString()) * PlayerTorgueForce);
        }
        

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
        if (PlayerRigidbody.velocity.magnitude > FourthSpeedLimit)
        {
            CurrentPlayerSpeed = PlayerFourthSpeed;
        }


        if (PlayerRigidbody.velocity.magnitude > FinalSpeedLimit)
        {
            CurrentPlayerSpeed = PlayerFinalSpeed;
        }
        #endregion

     

        #endregion
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrel_Oil") && PlayerRigidbody.velocity.magnitude < SpeedToCollectBarrel
            && !PlayerHasGotAnOil)
        {
            PlayerHasGotAnOil = true;
            PickUpBarrelSound.Play();
            Destroy(collision.gameObject);
        }
    }
    
    
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
                PlayerFinalSpeed -= SpeedDegradation;
                TotalDamagePlayerHas++;
                //if (Racer == TypeOfRacer.Moto) PlayerThirdSpeed -= 50;
                //if (Racer == TypeOfRacer.Car) PlayerThirdSpeed -= 30;
                //if (Racer == TypeOfRacer.Monster) PlayerThirdSpeed -= 15;
                StartCoroutine(WaitUntillRefreshDurability());
            }
                
                StartCoroutine(DelayBeforeNextDemageFromPlayers(TimeBeforeNextDamageFromPlayers));
        } 
        // если ударяемся с любым другим объектом
        else if(!collision.gameObject.CompareTag("Player"))
        {
            crushesCounter++;
            CrushSound.Play();
            if (crushesCounter >= HowManyCrushesBeforeTakeDamage)
            {
                PlayerFinalSpeed -= SpeedDegradation;
                TotalDamagePlayerHas++;
                //if (Racer == TypeOfRacer.Moto) PlayerThirdSpeed -= 50;
                //    if (Racer == TypeOfRacer.Car) PlayerThirdSpeed -= 30;
                //    if (Racer == TypeOfRacer.Monster) PlayerThirdSpeed -= 15;
                StartCoroutine(WaitUntillRefreshDurability());
                DamageSound.Play();
            }
        }
    }
    private IEnumerator DelayBeforeNextDemageFromPlayers(float TimeBeforeNextDamageFromPlayers)
    {
        yield return new WaitForSeconds(TimeBeforeNextDamageFromPlayers);
        flagToControlDamageFromPlayers = true;
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

    private IEnumerator WaitUntillRefreshDurability()
    {
        yield return new WaitForSeconds(0.2f);
        crushesCounter = 0;
    }
}
