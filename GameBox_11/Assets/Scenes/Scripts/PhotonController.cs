using Photon.Pun;
using UnityEngine;

public class PhotonController : MonoBehaviourPun
{
    [SerializeField] private Transform Player1_BluePosition;
    [SerializeField] private Transform Player2_RedPosition;
    private string PlayerPrefabName;
    private Transform PlayerPosition;
    private void Awake()
    {
        ChooseRacer();
        PhotonNetwork.Instantiate(PlayerPrefabName, PlayerPosition.position, Quaternion.identity);
    }

    public void ChooseRacer()
    {
        int i = PhotonNetwork.CurrentRoom.PlayerCount;
        if( i == 1)
        {
            PlayerPosition = Player1_BluePosition;
            switch (LoopBackMenu.pointer)
            {
                case 0:
                    PlayerPrefabName = "Player1_car_blue Variant";
                    break;
                case 1:
                    PlayerPrefabName = "Player1_moto_blue Variant";
                    break;
                case 2:
                    PlayerPrefabName = "Player1_Monster_Blue Variant";
                    break;
                default:
                    break;
            }
        }
        if (i == 2)
        {
            PlayerPosition = Player2_RedPosition;
            switch (LoopBackMenu.pointer)
            {
                case 0:
                    PlayerPrefabName = "Player2_car_red Variant";
                    break;
                case 1:
                    PlayerPrefabName = "Player2_moto_red Variant";
                    break;
                case 2:
                    PlayerPrefabName = "Player2_Monster_red Variant";
                    break;
                default:
                    break;
            }
        }
    }
}
