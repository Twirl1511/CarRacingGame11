using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCenterOfMass : MonoBehaviour
{
    public Vector2 CenterOfMass;
    
    void Update()
    {
        GetComponent<Rigidbody2D>().centerOfMass = CenterOfMass;
    }
}
