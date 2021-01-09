using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCollisionSound : MonoBehaviour
{
    [SerializeField] private AudioSource WheelSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            if (WheelSound.isPlaying)
            {
                return;
            }
            Player_Controller.PlaySound(gameObject, WheelSound);
        }
        
    }

}
