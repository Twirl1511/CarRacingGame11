using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FrontLightsDegradation : MonoBehaviour
{
    [SerializeField] private GameObject LeftLight;
    [SerializeField] private GameObject RightLight;
    private GameObject _lightToTurnOff;
    private float _defaultPointLightOuterRadius;
    [SerializeField] private float FirstDegradation = 0.9f;
    [SerializeField] private float SecondDegradation = 0.8f;
    [SerializeField] private float ThirdDegradation = 0.7f;
    [SerializeField] private float FourthDegradation = 0.5f;
    [SerializeField] private float FifthDegradation = 0.4f;
    [SerializeField] private float SixthDegradation = 0.3f;
    [SerializeField] private int CrushesToTurnOffLight = 3;
    private void Start()
    {
        _defaultPointLightOuterRadius = LeftLight.GetComponent<Light2D>().pointLightOuterRadius;
        ChooseLightToTurnOff();
    }
    private void Update()
    {
        LightsDecreasing();
        TurnOffLight();
        
    }
    private void LightsDegradation(float degradationValue)
    {
        LeftLight.GetComponent<Light2D>().pointLightOuterRadius = _defaultPointLightOuterRadius * degradationValue;
        RightLight.GetComponent<Light2D>().pointLightOuterRadius = _defaultPointLightOuterRadius * degradationValue;
    }
    private void LightsDecreasing()
    {
        switch (gameObject.GetComponent<Player_Controller>().TotalDamagePlayerHas)
        {
            case 1:
                LightsDegradation(FirstDegradation);
                break;
            case 2:
                LightsDegradation(SecondDegradation);
                break;
            case 3:
                LightsDegradation(ThirdDegradation);
                break;
            case 4:
                LightsDegradation(FourthDegradation);
                break;
            case 5:
                LightsDegradation(FifthDegradation);
                break;
            case 6:
                LightsDegradation(SixthDegradation);
                break;
            default:
                break;
        }
    }
    private void ChooseLightToTurnOff()
    {
        if (Random.Range(0,2) == 0)
        {
            _lightToTurnOff = LeftLight;
            Debug.Log("left");
        }
        else
        {
            _lightToTurnOff = RightLight;
            Debug.Log("right");
        }
        
    }
    private void TurnOffLight()
    {
        int crushNumber = GetComponent<Player_Controller>().TotalDamagePlayerHas;
        if (crushNumber == CrushesToTurnOffLight-1)
        {
            FlickeringLight();
        }
        if (crushNumber >= CrushesToTurnOffLight)
        {
            _lightToTurnOff.SetActive(false);
        }
    }
    /// <summary>
    /// контроль мигания фары
    /// </summary>
    private bool _flag = true;
    private void FlickeringLight()
    {
        if (_flag)
        {
            StartCoroutine(FlickeringLightWait(_lightToTurnOff));
            _flag = false;
        }
    }
    private IEnumerator FlickeringLightWait(GameObject light)
    {
        float randIntesity = (float)Random.Range(0, 200) / 100;
        yield return new WaitForSeconds((float)Random.Range(0, 30) / 100);
        light.GetComponent<Light2D>().intensity = randIntesity;
        _flag = true;
    }
}
