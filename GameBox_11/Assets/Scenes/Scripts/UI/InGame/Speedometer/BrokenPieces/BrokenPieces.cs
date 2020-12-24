using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPieces : MonoBehaviour
{
    [SerializeField] private GameObject PlayerObject;
    [SerializeField] private GameObject[] SpeedPieces;
    
    [SerializeField] private float GravityScale;
    [SerializeField] private float BrokeForce;

    void Update()
    {
        DropBrokenPieces();
    }

    private void DropBrokenPieces()
    {
        int playersCurrentDamage = PlayerObject.GetComponent<Player_Controller>().TotalDamagePlayerHas - 1;
        if (playersCurrentDamage >= 0 && playersCurrentDamage < SpeedPieces.Length)
        {
            for (int i = 0; i < SpeedPieces.Length; i++)
            {
                if (SpeedPieces[playersCurrentDamage] != null &&
                    SpeedPieces[playersCurrentDamage].activeSelf &&
                        SpeedPieces[playersCurrentDamage].GetComponent<Rigidbody2D>().gravityScale == 0)
                {
                    SpeedPieces[playersCurrentDamage].GetComponent<Rigidbody2D>().gravityScale = GravityScale;
                    SpeedPieces[playersCurrentDamage].GetComponent<Rigidbody2D>().AddForce(RandomDirection() * BrokeForce, ForceMode2D.Impulse);
                    SpeedPieces[playersCurrentDamage].GetComponent<Rigidbody2D>().AddTorque(RandomDirectionForTorgue() * BrokeForce);
                }
            }
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
