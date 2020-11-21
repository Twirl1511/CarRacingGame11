using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RacerModel", menuName = "Racer")]
public class RacerModels : ScriptableObject
{
    public string Name;
    public string MaxSpeed;
    public string HP;
    public string Modbility;
    public GameObject Racer;
}
