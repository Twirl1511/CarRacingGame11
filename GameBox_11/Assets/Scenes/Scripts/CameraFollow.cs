using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject PlayerToFollow;
    void Update()
    {
        Vector3 v3 = new Vector3(PlayerToFollow.GetComponent<Transform>().position.x, PlayerToFollow.GetComponent<Transform>().position.y, transform.position.z);
        transform.position = v3;
    }
}
