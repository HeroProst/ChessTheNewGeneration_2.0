using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameLoadSceneManager : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] string[,] Player1FigureBoard, Player2FigureBoard;

    void Start()
    {
        if (PhotonNetwork.CurrentRoom.GetPlayer(1) == PhotonNetwork.LocalPlayer)
        {
            Player1FigureBoard = StaticDataContainer.YourFigureBoard;
        }
        else
        {
            Player2FigureBoard = StaticDataContainer.YourFigureBoard;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            if (Player2FigureBoard == null)
            {
                SendYourFigureBoard(stream);
            }
            else if (StaticDataContainer.EnemyFigureBoard == null)
            {
                if (PhotonNetwork.PlayerList[0] == PhotonNetwork.LocalPlayer)
                    StaticDataContainer.EnemyFigureBoard = Player2FigureBoard;
                else
                    StaticDataContainer.EnemyFigureBoard = Player1FigureBoard;
                SendYourFigureBoard(stream);
            }

            if(Player1FigureBoard != null && Player2FigureBoard != null && StaticDataContainer.EnemyFigureBoard != null)
                PhotonNetwork.LoadLevel($"{StaticDataContainer.ConvertTypeOfMapsToString(StaticDataContainer.currentMap)}_GameScreen");

            photonView.TransferOwnership(PhotonNetwork.PlayerListOthers[0]);
        }

        else if (stream.IsReading)
        {
            if (Player1FigureBoard == null)
            {
                Player1FigureBoard = ReadSendedFigureBoard(stream);
                Debug.Log("p1");
            }
            else if (Player2FigureBoard == null)
            {
                Player2FigureBoard = ReadSendedFigureBoard(stream);
                Debug.Log("p2");
            }
        }
    }

    void SendYourFigureBoard(PhotonStream stream)
    {
        string[,] figureBoardToSend = StaticDataContainer.YourFigureBoard;
        for (int i = 0; i < figureBoardToSend.GetLength(0); i++)
        {
            for (int j = 0; j < figureBoardToSend.GetLength(1); j++)
            {
                stream.SendNext(figureBoardToSend[i, j]);
            }
        }
    }

    string[,] ReadSendedFigureBoard(PhotonStream stream)
    {
        string[,] figureBoardToSend = new string[StaticDataContainer.YourFigureBoard.GetLength(0), StaticDataContainer.YourFigureBoard.GetLength(1)];
        for (int i = 0; i < figureBoardToSend.GetLength(0); i++)
        {
            for (int j = 0; j < figureBoardToSend.GetLength(1); j++)
            {
                figureBoardToSend[i, j] = (string)stream.ReceiveNext();
            }
        }
        return figureBoardToSend;
    }
}
