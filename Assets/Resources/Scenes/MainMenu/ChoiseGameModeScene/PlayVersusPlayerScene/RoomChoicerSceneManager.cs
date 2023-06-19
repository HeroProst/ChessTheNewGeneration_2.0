using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class RoomChoicerSceneManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject dropDownObject;
    [SerializeField] GameObject lobbyNameInputField;
    [SerializeField] GameObject lobbyPreviewPrefab;
    [SerializeField] GameObject lobbyScrollViewContent;
    [SerializeField] GameObject lobbyNameSearchInputField;
    public GameObject CreateLobbyMenu;

    string lobbyNameOption;

    void Start()
    {
        List<TMP_Dropdown.OptionData> dropDownOption = new List<TMP_Dropdown.OptionData>();
        foreach (string maps in Enum.GetNames(typeof(StaticDataContainer.TypeOfMaps)))
            dropDownOption.Add(new TMP_Dropdown.OptionData(maps));
        dropDownObject.GetComponent<TMP_Dropdown>().options = dropDownOption;
        lobbyNameOption = StaticDataContainer.LobbyNameSearch;
        lobbyNameSearchInputField.GetComponent<TMP_InputField>().text = lobbyNameOption;
    }

    public void CreateLobby()
    {
        ExitGames.Client.Photon.Hashtable roomMapType = new ExitGames.Client.Photon.Hashtable();
        string mapType = dropDownObject.GetComponent<TMP_Dropdown>().options[dropDownObject.GetComponent<TMP_Dropdown>().value].text;

        roomMapType["m"] = mapType;

        RoomOptions roomOptions = new RoomOptions();

        roomOptions.CustomRoomProperties = roomMapType;
        roomOptions.CustomRoomPropertiesForLobby = new string[] { "m" };

        roomOptions.MaxPlayers = 2;

        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(lobbyNameInputField.GetComponent<TMP_InputField>().text, roomOptions);
    }

    public void JoinRoom()
    {
        GameObject pressedLobbyPreview = EventSystem.current.currentSelectedGameObject;
        PhotonNetwork.JoinRoom(pressedLobbyPreview.transform.parent.GetChild(1).GetComponent<TMP_Text>().text);
    }

    public void CloseLobbyCreateMenu()
    {
        CreateLobbyMenu.SetActive(false);
    }
    public void OpenLobbyCreateMenu()
    {
        CreateLobbyMenu.SetActive(true);
    }

    public void SearchLobbyByName()
    {
        StaticDataContainer.LobbyNameSearch = lobbyNameSearchInputField.GetComponent<TMP_InputField>().text;
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackButtonClick()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("ChoiseGameModeScene");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform lobbyPreviewItem in lobbyScrollViewContent.transform)
        {
            Destroy(lobbyPreviewItem.gameObject);
        }

        GameObject lobbyPreview;
        ExitGames.Client.Photon.Hashtable roomMapType;
        lobbyScrollViewContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 150 * roomList.Count);
        int i = 0;
        foreach (RoomInfo roomInfo in roomList)
        {
            if (roomInfo.RemovedFromList)
                continue;
            if(lobbyNameOption == "" || roomInfo.Name.Contains(lobbyNameOption))
            {
                lobbyPreview = Instantiate(lobbyPreviewPrefab, lobbyScrollViewContent.transform);
                lobbyPreview.transform.localPosition = new Vector3(385, -(80 + (150 * i)));
                Transform lobbyPreviewPanel = lobbyPreview.transform.GetChild(0);
                lobbyPreviewPanel.GetChild(1).GetComponent<TMP_Text>().text = roomInfo.Name;
                roomMapType = roomInfo.CustomProperties;
                lobbyPreviewPanel.GetChild(2).GetComponent<TMP_Text>().text = roomMapType["m"].ToString();
                lobbyPreviewPanel.GetChild(3).GetComponent<Button>().onClick.AddListener(JoinRoom);
                i++;
            }
        }
    }



    public override void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        PhotonNetwork.LoadLevel("InLobbyScene");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log(cause.ToString());
    }

}
