using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPieces_Player1_BlueCar : MonoBehaviour
{
    [SerializeField] private GameObject Player1_BlueCar;
    [SerializeField] private GameObject Player1_BlueCar_180;
    [SerializeField] private GameObject Player1_BlueCar_170;
    [SerializeField] private GameObject Player1_BlueCar_160;
    [SerializeField] private GameObject Player1_BlueCar_150;
    [SerializeField] private GameObject Player1_BlueCar_140;
    [SerializeField] private float GravityScale;
    [SerializeField] private float BrokeForce;

    void Start()
    {
        
    }

    void Update()
    {
        DropBrokenPieces();
    }

    

    private void DropBrokenPieces()
    {
        switch (Player1_BlueCar.GetComponent<Player_Controller>().TotalDamagePlayerHas)
        {
            case 1:
                if (Player1_BlueCar_180!= null &&
                    Player1_BlueCar_180.GetComponent<Rigidbody2D>().gravityScale == 0)
                {
                    Player1_BlueCar_180.GetComponent<Rigidbody2D>().gravityScale = GravityScale;
                    Player1_BlueCar_180.GetComponent<Rigidbody2D>().AddForce(RandomDirection() * BrokeForce, ForceMode2D.Impulse);
                    Player1_BlueCar_180.GetComponent<Rigidbody2D>().AddTorque(RandomDirectionForTorgue() * BrokeForce);
                }
                break;
            default:
                break;
        }
    }

    private Vector2 RandomDirection()
    {
        Vector2 direction = Random.insideUnitCircle.normalized;
        return direction;
    }
    private int RandomDirectionForTorgue()
    {
        int rand = Random.Range(-1, 2);
        if (rand == 0)
        {
            rand = RandomDirectionForTorgue();
        }
        return rand;
    }
}
