using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
     private GameObject PlayerToFollow;
    [SerializeField] private Button RedCar;
    [SerializeField] private Button RedMoto;
    [SerializeField] private Button BlueCar;
    [SerializeField] private Button BlueMoto;
    [SerializeField] private Button RedMonster;
    [SerializeField] private Button BlueMonster;

    [SerializeField] private GameObject RedCarObj;
    [SerializeField] private GameObject RedMotoObj;
    [SerializeField] private GameObject BlueCarObj;
    [SerializeField] private GameObject BlueMotoObj;
    [SerializeField] private GameObject RedMonsterObj;
    [SerializeField] private GameObject BlueMonsterObj;


    private void Start()
    {
        

    }

    private void ShowButtons()
    {
        if (RedCarObj.activeSelf)
        {
            RedCar.gameObject.SetActive(true);
        }
        else
        {
            RedCar.gameObject.SetActive(false);
        }

        if (RedMotoObj.activeSelf)
        {
            RedMoto.gameObject.SetActive(true);
        }
        else
        {
            RedMoto.gameObject.SetActive(false);
        }

        if (BlueCarObj.activeSelf)
        {
            BlueCar.gameObject.SetActive(true);
        }
        else
        {
            BlueCar.gameObject.SetActive(false);
        }

        if (BlueMotoObj.activeSelf)
        {
            BlueMoto.gameObject.SetActive(true);
        }
        else
        {
            BlueMoto.gameObject.SetActive(false);
        }

        if (RedMonsterObj.activeSelf)
        {
            RedMonster.gameObject.SetActive(true);
        }
        else
        {
            RedMonster.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        ShowButtons();
        Vector3 v3 = new Vector3(PlayerToFollow.GetComponent<Transform>().position.x, PlayerToFollow.GetComponent<Transform>().position.y, transform.position.z);
        transform.position = v3;
    }

    public void OnClickRedCar()
    {
        PlayerToFollow = RedCarObj;
    }
    public void OnClickRedMoto()
    {
        PlayerToFollow = RedMotoObj;
    }
    public void OnClickBlueCar()
    {
        PlayerToFollow = BlueCarObj;
    }
    public void OnClickBlueMoto()
    {
        PlayerToFollow = BlueMotoObj;
    }
    public void OnClickRedMonster()
    {
        PlayerToFollow = RedMonsterObj;
    }
    public void OnClickBlueMonster()
    {
        PlayerToFollow = BlueMonsterObj;
    }


}
