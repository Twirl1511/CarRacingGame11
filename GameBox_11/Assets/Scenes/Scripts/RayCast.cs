using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private GameObject Player1_Blue;
    //[SerializeField] private GameObject Player2_Red;

    [SerializeField] private GameObject Player1_BlueStartPosition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray2D ray2D = new Ray2D(transform.position, Player1_Blue.transform.position);
        
        Debug.DrawRay(ray2D.origin, Player1_Blue.transform.position);

        float test = Vector2.Angle(Player1_BlueStartPosition.transform.position, Player1_Blue.transform.position);
        Debug.Log(test);
    }
}
