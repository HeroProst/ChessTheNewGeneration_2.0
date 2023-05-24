using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameMasterScript : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] GameObject currentGameBorder;
    [SerializeField] GameField currentGameField;
    [SerializeField] Figure.Side currentPlayer = Figure.Side.Bottom;
    [SerializeField] GameObject whitePlayerTextBox;
    [SerializeField] GameObject blackPlayerTextBox;
    public GameObject EndGameMenu;

    void Start()
    {
        currentGameField = new GameField(currentGameBorder, EndGameAction);

        switch(StaticDataContainer.currentGameMode)
        {
            case StaticDataContainer.GameMode.Multiplayer:
                SetUpOnlineGame();
                break;
            case StaticDataContainer.GameMode.SinglePlayer:
                SetUpOfflineGame();
                break;
            case StaticDataContainer.GameMode.Ai:
                break;
        }

        currentGameField.ResetCells();
    }

    void SetUpOnlineGame()
    {

        PhotonView pv = GetComponent<PhotonView>();

        if (pv)
            pv.ObservedComponents.Add(this);

        currentGameField = new GameField(currentGameBorder, EndGameAction);
        //OnlyForTest();

        ExitGames.Client.Photon.Hashtable playerSide = new ExitGames.Client.Photon.Hashtable();

        playerSide["PlayerSide"] = "Bottom";
        PhotonNetwork.PlayerList[0].SetCustomProperties(playerSide);
        whitePlayerTextBox.GetComponent<TMP_Text>().text = PhotonNetwork.PlayerList[0].NickName;

        playerSide["PlayerSide"] = "Upper";
        PhotonNetwork.PlayerList[1].SetCustomProperties(playerSide);
        blackPlayerTextBox.GetComponent<TMP_Text>().text = PhotonNetwork.PlayerList[1].NickName;


        if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[0])
        {
            SetBlackFigure(currentGameField, MatrixAction.ReverseMatrix(StaticDataContainer.EnemyFigureBoard));
            SetWhiteFigure(currentGameField, StaticDataContainer.YourFigureBoard);
        }
        else
        {
            SetBlackFigure(currentGameField, MatrixAction.ReverseMatrix(StaticDataContainer.YourFigureBoard));
            SetWhiteFigure(currentGameField, StaticDataContainer.EnemyFigureBoard);
        }
    }

    void SetUpOfflineGame()
    {
        blackPlayerTextBox.GetComponent<TMP_Text>().text  = StaticDataContainer.UserName;
        whitePlayerTextBox.GetComponent<TMP_Text>().text = StaticDataContainer.UserName;
        SetWhiteFigure(currentGameField, StaticDataContainer.YourFigureBoard);
        SetBlackFigure(currentGameField, StaticDataContainer.EnemyFigureBoard);
    }

    void OnlyForTest()
    {
        SetFactory defaultSetBottom = new DefaultFigureFactory();
        defaultSetBottom.SetFigureOnField(5, 5, currentGameField, Figure.TypesOfFigure.King, Figure.Side.Upper, Figure.SpriteModel.Alternative);
        defaultSetBottom.SetFigureOnField(1, 1, currentGameField, Figure.TypesOfFigure.Rook, Figure.Side.Upper, Figure.SpriteModel.Alternative);

        SetFactory defaultSeUpper = new DefaultFigureFactory();
        defaultSeUpper.SetFigureOnField(2, 2, currentGameField, Figure.TypesOfFigure.Rook, Figure.Side.Bottom, Figure.SpriteModel.Origin);
        defaultSeUpper.SetFigureOnField(2, 5, currentGameField,Figure.TypesOfFigure.Rook, Figure.Side.Bottom, Figure.SpriteModel.Origin);
    }

    public void onClick()
    {
        if(StaticDataContainer.currentGameMode == StaticDataContainer.GameMode.Multiplayer)
            photonView.RPC("ButtonAction", RpcTarget.All, 1);
        else
            currentPlayer = currentGameField.ClickActionSelecter(currentPlayer);
    }

    [PunRPC]
    public void ButtonAction(int i)
    {
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["PlayerSide"].ToString());
        if(Figure.GetFigureSideByName(PhotonNetwork.LocalPlayer.CustomProperties["PlayerSide"].ToString()) == currentPlayer)
            currentPlayer = currentGameField.ClickActionSelecter(currentPlayer);
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(currentGameField.lastFigureMoves);
            if(currentPlayer == Figure.Side.Bottom)
                stream.SendNext("Bottom");
            else
                stream.SendNext("Upper");
            photonView.TransferOwnership(PhotonNetwork.PlayerListOthers[0]);
        }

        else if (stream.IsReading)
        {
            currentPlayer = currentGameField.PlaceFigureOnByXY((string) stream.ReceiveNext(), currentPlayer);
            currentPlayer = Figure.GetFigureSideByName((string)stream.ReceiveNext());
        }
    }

    void SetBlackFigure(GameField gameField, string[,] blackFiureBoard)
    {
        SetFactory figureFactory;
        for(int i = 0; i < gameField.GetGameField().GetLength(0);i++)
        {
            for (int j = 0; j < gameField.GetGameField().GetLength(1); j++)
            {
                if (gameField.GetGameField()[j, i].GetLinckedCell() == null)
                    continue;
                if (i - 1 >= blackFiureBoard.GetLength(0) || j - 1 >= blackFiureBoard.GetLength(1))
                    continue;
                Cell currentCell = gameField.GetGameField()[j, i];
                string currentFigure = blackFiureBoard[i - 1, j - 1];
                if (currentFigure.Split(" ")[0] == "None" || currentFigure.Split(" ")[1] == "None")
                {
                    continue;
                }
                Figure.CollectionType collectionType = Figure.GetCollectionTypeByName(currentFigure.Split(" ")[0]);
                Figure.TypesOfFigure typesOfFigure = Figure.GetFigureTypeByName(currentFigure.Split(" ")[1]);
                Color cellColor = currentCell.GetLinckedCell().GetComponent<Image>().color;
                cellColor.a = 1;
                currentCell.GetLinckedCell().GetComponent<Image>().color = cellColor;
                figureFactory = SetFactory.CreateSetFactory(collectionType);
                figureFactory.SetFigureOnField(j, i, currentGameField, typesOfFigure,Figure.Side.Upper,Figure.SpriteModel.Alternative);
            }
        }
    }

    void SetWhiteFigure(GameField gameField, string[,] whiteFiureBoard)
    {
        SetFactory figureFactory;
        int counter = whiteFiureBoard.GetLength(0) - 1;
        for (int i = gameField.GetGameField().GetLength(0) - 2; i >= 1; i--)
        {
            for (int j = 0; j < gameField.GetGameField().GetLength(1); j++)
            {
                if (gameField.GetGameField()[j, i].GetLinckedCell() == null)
                    continue;
                if (j - 1 >= whiteFiureBoard.GetLength(1))
                    continue;
                Cell currentCell = gameField.GetGameField()[j, i];
                string currentFigure = whiteFiureBoard[counter, j - 1];
                if (currentFigure.Split(" ")[0] == "None" || currentFigure.Split(" ")[1] == "None")
                {
                    continue;
                }
                Figure.CollectionType collectionType = Figure.GetCollectionTypeByName(currentFigure.Split(" ")[0]);
                Figure.TypesOfFigure typesOfFigure = Figure.GetFigureTypeByName(currentFigure.Split(" ")[1]);
                Color cellColor = currentCell.GetLinckedCell().GetComponent<Image>().color;
                cellColor.a = 1;
                currentCell.GetLinckedCell().GetComponent<Image>().color = cellColor;
                figureFactory = SetFactory.CreateSetFactory(collectionType);
                figureFactory.SetFigureOnField(j, i, currentGameField, typesOfFigure, Figure.Side.Bottom, Figure.SpriteModel.Origin);
            }
            counter--;
            if (counter < 0)
                return;
        }
    }

    void EndGameAction(string gameResult)
    {
        EnableEndGameMenu();
        SetEndGameMenuTitle(gameResult);
    }

    void EnableEndGameMenu()
    {
        EndGameMenu.SetActive(true);
    }

    void SetEndGameMenuTitle(string gameResult)
    {
        EndGameMenu.transform.GetChild(0).GetChild(EndGameMenu.transform.GetChild(0).childCount - 1).GetComponent<TextMeshProUGUI>().text = gameResult;
    }


}
