using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool _isPaused = false;
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private AudioSource CountdownSound;
    [SerializeField] private AudioSource GameSound;
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !MainMenuUI.activeSelf)
        {
            PauseUI.SetActive(!_isPaused);
            Time.timeScale = System.Convert.ToInt32(_isPaused);
            CountdownSound.pitch = System.Convert.ToInt32(_isPaused);
            GameSound.pitch = System.Convert.ToInt32(_isPaused);
            _isPaused = !_isPaused; 
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
}
