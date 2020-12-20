using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceRight : MonoBehaviour
{
    [SerializeField] private float TorgueForceForMoto = 1500f;
    [SerializeField] private float TorgueForceForCar = 1500f;
    [SerializeField] private float TaranForceForMoto = 20000f;
    [SerializeField] private float TaranForceForCar = 10000f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_Controller>().Racer.ToString().Equals("Moto"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(transform.right * TaranForceForMoto);
            collision.GetComponent<Rigidbody2D>().AddTorque(RandomDirection() * TorgueForceForMoto, ForceMode2D.Impulse);
        }
        if (collision.GetComponent<Player_Controller>().Racer.ToString().Equals("Car"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(transform.right * TaranForceForCar);
            collision.GetComponent<Rigidbody2D>().AddTorque(RandomDirection() * TorgueForceForCar, ForceMode2D.Impulse);
        }
    }
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
