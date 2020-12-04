using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

public class CameraShaker : MonoBehaviour
{
    public Shaker MyShaker;
    public ShakePreset ShakePreset;
    [SerializeField] private float CameraShakeDelay = 2f;
    private bool FlagToControlShake = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && FlagToControlShake)
        {
            MyShaker.Shake(ShakePreset);
            FlagToControlShake = false;
            StartCoroutine(DelayBeforeNextCameraShake(CameraShakeDelay));
        }
    }
    IEnumerator DelayBeforeNextCameraShake(float CameraShakeDelay)
    {
        
        yield return new WaitForSeconds(CameraShakeDelay);
        FlagToControlShake = true;
    }
}
