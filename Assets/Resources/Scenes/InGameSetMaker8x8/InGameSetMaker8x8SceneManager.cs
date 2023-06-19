using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class InGameSetMaker8x8SceneManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject board;
    public GameObject PlayerReadinnesMenu;
    public Figure.Side side;
    public int maxCurrancy;
    bool player1Ready;
    bool player2Ready;
    public void AcceptButton()
    {
        StaticDataContainer.SetFigureBoard(board, side);

        switch (StaticDataContainer.currentGameMode)
        {
            case StaticDataContainer.GameMode.Ai:
                SceneManager.LoadScene("MainMenu");
                return;
            case StaticDataContainer.GameMode.Multiplayer:
                if(PhotonNetwork.CurrentRoom.PlayerCount > 1)
                {
                    if (PhotonNetwork.CurrentRoom.GetPlayer(1) == PhotonNetwork.LocalPlayer)
                        player1Ready = true;
                    else
                        player2Ready = true;
                }
                PlayerReadinnesMenu.SetActive(true);
                return;
            case StaticDataContainer.GameMode.SinglePlayer:
                SceneManager.LoadScene($"InGameSetMaker{StaticDataContainer.ConvertTypeOfMapsToString(StaticDataContainer.currentMap)}SceneForBlack");
                return;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Debug.Log($"p1 - {player1Ready} p2 - {player2Ready}");
        if (stream.IsWriting)
        {
            if (PhotonNetwork.CurrentRoom.GetPlayer(1) == PhotonNetwork.LocalPlayer)
                stream.SendNext(player1Ready);
            else
                stream.SendNext(player2Ready);
            photonView.TransferOwnership(PhotonNetwork.PlayerListOthers[0]);
            if (player1Ready && player2Ready)
                PhotonNetwork.LoadLevel("GameLoadScene");
        }

        else if (stream.IsReading)
        {
            if(PhotonNetwork.CurrentRoom.GetPlayer(1) == PhotonNetwork.LocalPlayer)
                player2Ready = (bool)stream.ReceiveNext();
            else
                player1Ready = (bool)stream.ReceiveNext();
        }
    }

    public void ChangePlayerReadinnes()
    {
        PlayerReadinnesMenu.SetActive(false);
        if(PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            if (PhotonNetwork.CurrentRoom.GetPlayer(1) == PhotonNetwork.LocalPlayer)
                player1Ready = false;
            else
                player2Ready = false;
        }
    }

    public void BackButtonClick()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }
}
