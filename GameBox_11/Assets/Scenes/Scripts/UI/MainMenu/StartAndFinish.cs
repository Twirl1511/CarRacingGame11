using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAndFinish : MonoBehaviour
{
    [SerializeField] private AudioSource CountdownSound;
    [SerializeField] private AudioSource GameSound;
    [SerializeField] private AudioSource MenuSound;

    [SerializeField] private GameObject Player1_CarBlue;
    [SerializeField] private GameObject Player1_MotoBlue;
    [SerializeField] private GameObject Player2_CarRed;
    [SerializeField] private GameObject Player2_MotoRed;

    public void OnClickStartButton()
    {
        MenuSound.Stop();
        CountdownSound.Play();
        StartCoroutine(StartTheGame());

    }
    private IEnumerator StartTheGame()
    {
        yield return new WaitForSeconds(CountdownSound.clip.length);
        Player1_CarBlue.GetComponent<Player_Controller>().enabled = true;
        Player1_MotoBlue.GetComponent<Player_Controller>().enabled = true;
        Player2_CarRed.GetComponent<Player_Controller>().enabled = true;
        Player2_MotoRed.GetComponent<Player_Controller>().enabled = true;
        GameSound.Play();
    }


}
