using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetCode : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject PlayerDisconectMenu;
    [SerializeField] GameObject MainCanvas;
    [SerializeField] GameObject disconectFromServerMenu;
    void Start()
    {
        if (StaticDataContainer.currentGameMode != StaticDataContainer.GameMode.Multiplayer)
            return;
        if (PhotonNetwork.IsConnectedAndReady)
            return;
        PhotonNetwork.NickName = StaticDataContainer.UserName;

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = "0.1";
        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.SerializationRate = 60;
    }

    public void CreatePlayerDisconectMenu()
    {
        GameObject playerDisconectMenu = Instantiate(PlayerDisconectMenu, MainCanvas.transform);
        PhotonNetwork.Disconnect();
        playerDisconectMenu.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        if (cause == DisconnectCause.DisconnectByClientLogic)
            return;
        Instantiate(disconectFromServerMenu, MainCanvas.transform);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        CreatePlayerDisconectMenu();
    }
}
