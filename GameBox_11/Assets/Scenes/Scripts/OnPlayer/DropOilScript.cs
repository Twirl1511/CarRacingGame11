using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOilScript : MonoBehaviour
{
    [SerializeField] private AudioSource DropOlidSound;
    [SerializeField] private GameObject Oil;


    private void DropOil()
    {
        if (Input.GetButton(gameObject.GetComponent<Player_Controller>().PlayerDropOilButton.ToString()) 
            && gameObject.GetComponent<Player_Controller>().PlayerHasGotAnOil)
        {
            DropOlidSound.Play();
            gameObject.GetComponent<Player_Controller>().PlayerHasGotAnOil = false;

            float x = gameObject.GetComponent<Player_Controller>().OilDropPlaceFrom.transform.position.x;
            float y = gameObject.GetComponent<Player_Controller>().OilDropPlaceFrom.transform.position.y;

            Vector3 oilPosition = new Vector3(x, y, 0);
            Instantiate(Oil, oilPosition, Quaternion.Euler(0, 0, Random.Range(-180,180)));
            Barrel_controller.CurrentBarrelsOnMap--;
        }
    }
    private void FixedUpdate()
    {
        DropOil();
    }


}
