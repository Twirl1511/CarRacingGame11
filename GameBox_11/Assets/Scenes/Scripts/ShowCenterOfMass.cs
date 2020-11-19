using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCenterOfMass : MonoBehaviour
{
    public Vector2 CenterOfMass;
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetComponent<Rigidbody2D>().centerOfMass, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().centerOfMass = CenterOfMass;
    }
}
