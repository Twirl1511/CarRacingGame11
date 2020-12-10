using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject Player1_CarBlueButton;
    [SerializeField] private GameObject Player1_MotoBlueButton;
    [SerializeField] private GameObject Player2_CarRedButton;
    [SerializeField] private GameObject Player2_MotoRedButton;

    [SerializeField] private GameObject GamePanel;
    [SerializeField] private Button Start;
    [SerializeField] private Image MusicOn;
    [SerializeField] private Image MusicOff;
    [SerializeField] private Button Exit;

    [SerializeField] private GameObject Player1_CarBlueGameobject;
    [SerializeField] private GameObject Player1_MotoBlueGameobject;
    [SerializeField] private GameObject Player2_CarRedGameobject;
    [SerializeField] private GameObject Player2_MotoRedGameobject;

    private bool SoundSwitch = false;
   

    public void OnStartButtonClick()
    {
        if (Player2_CarRedButton.gameObject.activeSelf == true)
        {
            Player2_CarRedGameobject.SetActive(true);
            //Player2_CarRedPanel.SetActive(true);
        }
            
        if (Player2_MotoRedButton.gameObject.activeSelf == true)
        {
            Player2_MotoRedGameobject.SetActive(true);
            //Player2_MotoRedPanel.SetActive(true);
        }
            
        if (Player1_CarBlueButton.gameObject.activeSelf == true)
        {
            Player1_CarBlueGameobject.SetActive(true);
            //Player1_CarBluePanel.SetActive(true);
        }
            
        if (Player1_MotoBlueButton.gameObject.activeSelf == true)
        {
            Player1_MotoBlueGameobject.SetActive(true);
            //Player1_MotoBluePanel.SetActive(true);
        }
            
        /// выключаем эту панель и включаем интерфейс игры
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
