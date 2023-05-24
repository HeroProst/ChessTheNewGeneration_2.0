using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class InLobbySceneManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject lobbyName;
    [SerializeField] GameObject lobbyMapType;
    [SerializeField] GameObject HostName;
    [SerializeField] GameObject joinedPlayerName;
    [SerializeField] GameObject errorMessage;
    void Start()
    {
        lobbyName.GetComponent<TMP_Text>().text = PhotonNetwork.CurrentRoom.Name;
        lobbyMapType.GetComponent< TMP_Text>().text = PhotonNetwork.CurrentRoom.CustomProperties["m"].ToString();
        HostName.GetComponent<TMP_Text>().text = PhotonNetwork.CurrentRoom.GetPlayer(1).NickName;
        if(PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            joinedPlayerName.GetComponent<TMP_Text>().text = PhotonNetwork.LocalPlayer.NickName;
        }
        else
        {
            joinedPlayerName.GetComponent<TMP_Text>().text = "Нет игрока";
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        joinedPlayerName.GetComponent<TMP_Text>().text = PhotonNetwork.PlayerListOthers[0].NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(PhotonNetwork.LocalPlayer.NickName == HostName.GetComponent<TMP_Text>().text)
        {
            joinedPlayerName.GetComponent<TMP_Text>().text = "Нет игрока";
        }
        else
        {
            ExitButtonClick();
        }
    }

    public void StartGame()
    {
        StaticDataContainer.currentMap = StaticDataContainer.ConvertStringToTypeOfMaps(PhotonNetwork.CurrentRoom.CustomProperties["m"].ToString());
        Debug.Log(PhotonNetwork.CurrentRoom.CustomProperties["m"].ToString());
        Debug.Log(StaticDataContainer.ConvertStringToTypeOfMaps(PhotonNetwork.CurrentRoom.CustomProperties["m"].ToString()));
        
        if (photonView.IsMine)
        {
            if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                errorMessage.GetComponent<TMP_Text>().text = "Для начала игры необходим второй игрок.";
                return;
            }
            switch (StaticDataContainer.currentMap)
            {
                case StaticDataContainer.TypeOfMaps.Map8x8:
                    PhotonNetwork.LoadLevel("InGameSetMaker8x8Scene");
                    break;
                case StaticDataContainer.TypeOfMaps.Map5x5:
                    PhotonNetwork.LoadLevel("InGameSetMaker5x5Scene");
                    break;
                case StaticDataContainer.TypeOfMaps.Map10x10:
                    PhotonNetwork.LoadLevel("InGameSetMaker10x10Scene");
                    break;
            }
        }
        else
        {
            errorMessage.GetComponent<TMP_Text>().text = "Только создатель лобби может начинать игру.";
        }
    }

    public void ExitButtonClick()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("ChoiseGameModeScene");
    }

    public override void OnLeftRoom()
    {
        Debug.Log("RoomLeft");
    }
}
