using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class MultiplayerMenuController : MonoBehaviourPunCallbacks
{
    [SerializeField] private string SceneName;
    [SerializeField] private Text ServerStatus = null;
    [SerializeField] private GameObject JoinGameButton;
    [SerializeField] private byte MaxPlayers = 2;


    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        JoinGameButton.SetActive(false);
        Status("Connecting to server");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.AutomaticallySyncScene = true;
        JoinGameButton.SetActive(true);
        Status("Connected to " + PhotonNetwork.ServerAddress);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        SceneManager.LoadScene(SceneName);
    }

    public void JoinGame_OnClick()
    {
        string roomName = "Room 1";
        Photon.Realtime.RoomOptions roomOptions = new Photon.Realtime.RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = MaxPlayers;
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, Photon.Realtime.TypedLobby.Default);
        JoinGameButton.SetActive(false);
        Status("Joining " + roomName);
    }

    private void Status(string msg)
    {
        Debug.Log(msg);
        ServerStatus.text = msg;
    }
}