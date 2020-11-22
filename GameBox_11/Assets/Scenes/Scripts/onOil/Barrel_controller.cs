using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_controller : MonoBehaviour
{
    [SerializeField] private float TimeBeforeSpawn = 2f;
    [SerializeField] private GameObject BarrelPrefab;
    private bool BarrelDelayFlag = true;
    private const int MAX_BARRELS_ON_MAP = 2;
    [HideInInspector] public int CurrentBarrelsOnMap = 2;

    [SerializeField] private Transform TopLeftOuterCorner;
    [SerializeField] private Transform TopRightOuterCorner;
    [SerializeField] private Transform DownLeftOuterCorner;

    [SerializeField] private Transform TopLeftInnerCorner;
    [SerializeField] private Transform TopRightInnerCorner;
    [SerializeField] private Transform DownLeftInnerCorner;

    private float LeftOuterX;
    private float RightOuterX;
    private float TopOuterY;
    private float DownOuterY;

    private float LeftInnerX;
    private float RightInnerX;
    private float TopInnerY;
    private float DownInnerY;



    private void Start()
    {
        LeftOuterX = TopLeftOuterCorner.position.x; // -766
        RightOuterX = TopRightOuterCorner.position.x; // 842
        TopOuterY = TopLeftOuterCorner.position.y; //371
        DownOuterY = DownLeftOuterCorner.position.y; // -346

        LeftInnerX = TopLeftInnerCorner.position.x; // -611
        RightInnerX = TopRightInnerCorner.position.x; // 691
        TopInnerY = TopLeftInnerCorner.position.y; // 213
        DownInnerY = DownLeftInnerCorner.position.y; // -191
    }
    private void FixedUpdate()
    {
        if (BarrelDelayFlag && CurrentBarrelsOnMap < MAX_BARRELS_ON_MAP)
        {
            StartCoroutine(SpawnBarrel());
            CurrentBarrelsOnMap++;
            BarrelDelayFlag = false;
        }
        
    }
    // убрать хардкод когда появится карта, брать координаты боксов границ минус 1 или 2 юнита
    private Vector3 FindPosition()
    {

        float x;
        float y;
        do
        {
            x = Random.Range(LeftOuterX, RightOuterX);
            y = Random.Range(DownOuterY, TopOuterY);
        }
        while ((x > LeftInnerX && x < RightInnerX) && (y > DownInnerY && y < TopInnerY));
        return new Vector3(x,y,0);
    }

    private IEnumerator SpawnBarrel()
    {
        yield return new WaitForSeconds(TimeBeforeSpawn);
        Instantiate(BarrelPrefab, FindPosition(), Quaternion.identity);
        BarrelDelayFlag = true;
    }


}
