﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_controller : MonoBehaviour
{
    [SerializeField] private float TimeBeforeSpawn = 2f;
    [SerializeField] private GameObject BarrelPrefab;
    private bool Flag = true;
    public float Player_Speed = 10;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (Flag)
        {
            StartCoroutine(SpawnBarrel());
            Flag = false;
        }
        
    }
    // убрать хардкод когда появится карта, брать координаты боксов границ минус 1 или 2 юнита
    private Vector3 FindPosition()
    {
        float x;
        float y;
        do
        {
            x = Random.Range(-53, 38);
            y = Random.Range(-22, 30);
        }
        while ((x > -45 && x < 31.7) && (y > -9.5 && y < 18.7));
        return new Vector3(x,y,0);
    }

    private IEnumerator SpawnBarrel()
    {
        yield return new WaitForSeconds(TimeBeforeSpawn);
        Instantiate(BarrelPrefab, FindPosition(), Quaternion.identity);
        Flag = true;
    }


}
