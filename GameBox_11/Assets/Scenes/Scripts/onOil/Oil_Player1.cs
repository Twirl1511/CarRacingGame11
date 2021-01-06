using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil_Player1 : MonoBehaviour
{
    [SerializeField] private AudioSource OilDriftSound;
    [SerializeField] float ForwardForce = 50f;
    [SerializeField] float TorgueForceForCar = 3000f;
    [SerializeField] float TorgueForceForMoto = 1500f;
    [SerializeField] float TorgueForceForMonster = 4000f;
    [SerializeField] float TimeToDisappear = 10;
    [SerializeField] private float TimeBeforeColliderActive = 2f;
    [SerializeField] private float TimeBeforeNextDebuff = 1f;
    /// <summary>
    /// флаг чтобы игрок разливший масло сам же на нем на скользил какое-то время
    /// </summary>
    private bool ActivateColliderFlag = true;
    /// <summary>
    /// флаг чтобы у игрока была задержка перед следующим дебафом от лужи
    /// </summary>
    private bool NotDebuffedFlag = true;
    void Start()
    {
        StartCoroutine(DisappearOil());
        StartCoroutine(DelayForHostPlayerActive());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ActivateColliderFlag && collision.GetComponent<Player_Controller>().Player.ToString().Equals("Player1"))
        {
            
        }
        else if (NotDebuffedFlag)
        {
            float TorgueForce = 0;
            switch (collision.GetComponent<Player_Controller>().Racer.ToString())
            {
                case "Car": TorgueForce = TorgueForceForCar;
                    break;
                case "Moto":
                    TorgueForce = TorgueForceForMoto;
                    break;
                case "Monster":
                    TorgueForce = TorgueForceForMonster;
                    break;
                default:
                    break;
            }
     
            Vector2 v2 = collision.GetComponent<Rigidbody2D>().velocity;
            collision.GetComponent<Rigidbody2D>().AddForce(v2 * ForwardForce);
            collision.GetComponent<Rigidbody2D>().AddTorque(RandomDirection() * TorgueForce, ForceMode2D.Impulse);
            OilDriftSound.Play();
            NotDebuffedFlag = false;
            StartCoroutine(DelayForNextDebuffFromOil());
        }

    }

    private IEnumerator DisappearOil()
    {
        yield return new WaitForSeconds(TimeToDisappear);
        Destroy(gameObject.GetComponent<Collider2D>());
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private IEnumerator DelayForNextDebuffFromOil()
    {
        yield return new WaitForSeconds(TimeBeforeNextDebuff);
        NotDebuffedFlag = true;
    }
    private IEnumerator DelayForHostPlayerActive()
    {
        yield return new WaitForSeconds(TimeBeforeColliderActive);
        ActivateColliderFlag = false;
    }

    /// <summary>
    /// возвращает -1 или 1 для выбора направления заноса
    /// </summary>
    /// <returns></returns>
    private int RandomDirection()
    {
        int rand = Random.Range(-1, 2);
        if (rand == 0)
        {
            rand = RandomDirection();
        }
        return rand;
    }
}
