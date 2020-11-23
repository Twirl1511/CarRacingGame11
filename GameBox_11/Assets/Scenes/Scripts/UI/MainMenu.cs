using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button Player2_CarBlue;
    [SerializeField] private Button Player2_MotoBlue;
    [SerializeField] private Button Player1_CarRed;
    [SerializeField] private Button Player1_MotoRed;
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private Button Start;
    [SerializeField] private Image MusicOn;
    [SerializeField] private Image MusicOff;
    [SerializeField] private Button Exit;

    [SerializeField] private GameObject Player2_CarBlueGameobject;
    [SerializeField] private GameObject Player2_MotoBlueGameobject;
    [SerializeField] private GameObject Player1_CarRedGameobject;
    [SerializeField] private GameObject Player1_MotoRedGameobject;

    private bool Player1_Flag = true;
    private bool Player2_Flag = true;
    private bool SoundSwitch = false;
    private void Update()
    {
        if (Input.GetButtonDown("P1_horizontal"))
        {
            Player1_Flag = !Player1_Flag;
            Player1_CarRed.gameObject.SetActive(Player1_Flag);
            Player1_MotoRed.gameObject.SetActive(!Player1_Flag);
        }
        if (Input.GetButtonDown("P2_horizontal"))
        {
            Player2_Flag = !Player2_Flag;
            Player2_CarBlue.gameObject.SetActive(Player2_Flag);
            Player2_MotoBlue.gameObject.SetActive(!Player2_Flag);
        }
    }

    public void OnStartButtonClick()
    {
        if (Player1_CarRed.gameObject.activeSelf == true) Player1_CarRedGameobject.SetActive(true);
        if (Player1_MotoRed.gameObject.activeSelf == true) Player1_MotoRedGameobject.SetActive(true);
        if (Player2_CarBlue.gameObject.activeSelf == true) Player2_CarBlueGameobject.SetActive(true);
        if (Player2_MotoBlue.gameObject.activeSelf == true) Player2_MotoBlueGameobject.SetActive(true);
        gameObject.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void OnExitClick()
    {
        
        Application.Quit();
        
    }
    public void OnSoundClick()
    {
        SoundSwitch = !SoundSwitch;
        MusicOn.gameObject.SetActive(!SoundSwitch);
        MusicOff.gameObject.SetActive(SoundSwitch);
        AudioListener.pause = SoundSwitch;

    }
}
