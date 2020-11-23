using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Image PauseImage;
    private bool Flag = true;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Flag = !Flag;
            PauseImage.gameObject.SetActive(!Flag);
            Time.timeScale = System.Convert.ToInt32(Flag);
        }
    }
}
