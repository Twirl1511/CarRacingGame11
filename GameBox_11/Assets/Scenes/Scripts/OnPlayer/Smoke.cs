using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    [SerializeField] private GameObject SmokeObj;
    [SerializeField] private GameObject SmokePosition;
    [SerializeField] private Buttons PlayerForwardButton;
    [SerializeField] private ParticleSystem SmokeParticalSystem;
    private enum Buttons
    {
        P1_forward,
        P2_forward
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown(PlayerForwardButton.ToString()))
        {
            SmokeParticalSystem.Play();
        }
        if (Input.GetButtonUp(PlayerForwardButton.ToString()))
        {
            SmokeParticalSystem.Stop();
        }
    }
    void Update()
    {
        SmokeObj.transform.position = new Vector2(SmokePosition.transform.position.x, SmokePosition.transform.position.y);
        SmokeObj.transform.rotation = Quaternion.Euler(transform.rotation.x,
            transform.rotation.y,
            transform.rotation.z);
    }
    
}
