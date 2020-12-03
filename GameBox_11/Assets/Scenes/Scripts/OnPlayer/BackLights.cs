using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLights : MonoBehaviour
{
    [SerializeField] private GameObject BackLightsObject;
    [SerializeField] private Buttons PlayerForwardButton;
    private Rigidbody2D PlayerRb;
    [SerializeField] private float MagnitudeToTurnOffLights = 10f;

    private void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
    }
    private enum Buttons
    {
        P1_forward,
        P2_forward
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonUp(PlayerForwardButton.ToString()) && PlayerRb.velocity.magnitude > MagnitudeToTurnOffLights)
        {
            BackLightsObject.SetActive(true);
            Debug.Log("Тормозим");
        }
        if (Input.GetButton(PlayerForwardButton.ToString()) || PlayerRb.velocity.magnitude < MagnitudeToTurnOffLights)
        {
            BackLightsObject.SetActive(false);
            
        }
    }
}
