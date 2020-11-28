using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button Player1_CarBlueButton;
    [SerializeField] private Button Player1_MotoBlueButton;
    [SerializeField] private Button Player2_CarRedButton;
    [SerializeField] private Button Player2_MotoRedButton;
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private Button Start;
    [SerializeField] private Image MusicOn;
    [SerializeField] private Image MusicOff;
    [SerializeField] private Button Exit;

    [SerializeField] private GameObject Player1_CarBlueGameobject;
    [SerializeField] private GameObject Player1_MotoBlueGameobject;
    [SerializeField] private GameObject Player2_CarRedGameobject;
    [SerializeField] private GameObject Player2_MotoRedGameobject;

    [SerializeField] private GameObject Player1_CarBluePanel;
    [SerializeField] private GameObject Player1_MotoBluePanel;
    [SerializeField] private GameObject Player2_CarRedPanel;
    [SerializeField] private GameObject Player2_MotoRedPanel;

    private bool Player1_Flag = true;
    private bool Player2_Flag = true;
    private bool SoundSwitch = false;
    private void Update()
    {
        if (Input.GetButtonDown("P1_horizontal"))
        {
            Player1_Flag = !Player1_Flag;
            Player1_CarBlueButton.gameObject.SetActive(Player1_Flag);
            Player1_MotoBlueButton.gameObject.SetActive(!Player1_Flag);
        }
        if (Input.GetButtonDown("P2_horizontal"))
        {
            Player2_Flag = !Player2_Flag;
            Player2_CarRedButton.gameObject.SetActive(Player2_Flag);
            Player2_MotoRedButton.gameObject.SetActive(!Player2_Flag);
        }
    }

    public void OnStartButtonClick()
    {
        if (Player2_CarRedButton.gameObject.activeSelf == true)
        {
            Player2_CarRedGameobject.SetActive(true);
            Player2_CarRedPanel.SetActive(true);
        }
            
        if (Player2_MotoRedButton.gameObject.activeSelf == true)
        {
            Player2_MotoRedGameobject.SetActive(true);
            Player2_MotoRedPanel.SetActive(true);
        }
            
        if (Player1_CarBlueButton.gameObject.activeSelf == true)
        {
            Player1_CarBlueGameobject.SetActive(true);
            Player1_CarBluePanel.SetActive(true);
        }
            
        if (Player1_MotoBlueButton.gameObject.activeSelf == true)
        {
            Player1_MotoBlueGameobject.SetActive(true);
            Player1_MotoBluePanel.SetActive(true);
        }
            
        gameObject.SetActive(false);
        GamePanel.SetActive(true);
    }
    public void OnExitClick()
    {
        Debug.Log("!!!!!!!!!!");
        Application.Quit();
        
    }
    public void OnSoundClick()
    {
        SoundSwitch = !SoundSwitch;
        //MusicOn.gameObject.SetActive(!SoundSwitch);
        //MusicOff.gameObject.SetActive(SoundSwitch);
        AudioListener.pause = SoundSwitch;

    }
}
