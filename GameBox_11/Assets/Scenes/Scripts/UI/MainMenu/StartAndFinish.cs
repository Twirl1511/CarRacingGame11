using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAndFinish : MonoBehaviour
{
    [SerializeField] private AudioSource CountdownSound;
    [SerializeField] private AudioSource GameSound;
    [SerializeField] private AudioSource MenuSound;

    [SerializeField] private GameObject Player1_Car;
    [SerializeField] private GameObject Player1_Moto;
    [SerializeField] private GameObject Player2_Car;
    [SerializeField] private GameObject Player2_Moto;

    public void OnClickStartButton()
    {
        MenuSound.Stop();
        CountdownSound.Play();
        StartCoroutine(StartTheGame());

    }
    private IEnumerator StartTheGame()
    {
        yield return new WaitForSeconds(CountdownSound.clip.length);
        Player1_Car.GetComponent<Player_Controller>().enabled = true;
        Player1_Moto.GetComponent<Player_Controller>().enabled = true;
        Player2_Car.GetComponent<Player_Controller>().enabled = true;
        Player2_Moto.GetComponent<Player_Controller>().enabled = true;
        GameSound.Play();
    }


}
