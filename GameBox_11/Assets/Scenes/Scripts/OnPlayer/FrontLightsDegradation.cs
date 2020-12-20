using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FrontLightsDegradation : MonoBehaviour
{
    [SerializeField] private GameObject LeftLight;
    [SerializeField] private GameObject RightLight;

    private void Update()
    {
        switch (gameObject.GetComponent<Player_Controller>().TotalDamagePlayerHas)
        {
            case 1:
                LeftLight.GetComponent<Light2D>().pointLightOuterRadius = 100;
                break;
            default:
                break;
        }
    }
}
