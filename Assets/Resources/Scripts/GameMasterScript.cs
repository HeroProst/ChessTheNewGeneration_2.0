using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;


public class GameMasterScript : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] GameObject currentGameBorder;
    [SerializeField] GameField currentGameField;
    [SerializeField] Figure.Side currentPlayer = Figure.Side.Bottom;
    [SerializeField] GameObject whitePlayerTextBox;
    [SerializeField] GameObject blackPlayerTextBox;
    [SerializeField] GameObject boardMarks;
    public GameObject EndGameMenu;
    string lastFigureMove = "";
    Cell lastFigureMoveCell;

    GameHistory game;

    bool turnIsEnd = false;


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

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + $"/UserName.dat", FileMode.Open);

        UserDataAndSettings userData = (UserDataAndSettings)bf.Deserialize(file);

        boardMarks.SetActive(userData.EnableBoardMarking);

        file.Close();

        currentGameField.ResetCells();

        game = new GameHistory(currentGameBorder);

    }

    private void OnDestroy()
    {
        WriteGameHistory();
    }

    void SetUpOnlineGame()
    {

        PhotonView pv = GetComponent<PhotonView>();

        if (pv)
            pv.ObservedComponents.Add(this);

        currentGameField = new GameField(currentGameBorder, EndGameAction);
        //OnlyForTest();
        if ((string)PhotonNetwork.PlayerList[0].CustomProperties["PS"] == "Bottom")
        {
            whitePlayerTextBox.GetComponent<TMP_Text>().text = PhotonNetwork.PlayerList[0].NickName;

            blackPlayerTextBox.GetComponent<TMP_Text>().text = PhotonNetwork.PlayerList[1].NickName;
        }
        else
        {
            whitePlayerTextBox.GetComponent<TMP_Text>().text = PhotonNetwork.PlayerList[1].NickName;

            blackPlayerTextBox.GetComponent<TMP_Text>().text = PhotonNetwork.PlayerList[0].NickName;
        }

        if ((string) PhotonNetwork.LocalPlayer.CustomProperties["PS"] == "Bottom")
        {
            SetBlackFigure(currentGameField, MatrixAction.ReverseMatrix(StaticDataContainer.EnemyFigureBoard));
            SetWhiteFigure(currentGameField, StaticDataContainer.YourFigureBoard);
        }
        else
        {
            SetBlackFigure(currentGameField, MatrixAction.ReverseMatrix(StaticDataContainer.YourFigureBoard));
            SetWhiteFigure(currentGameField, StaticDataContainer.EnemyFigureBoard);
        }

        Debug.Log((int)PhotonNetwork.LocalPlayer.CustomProperties.Count);
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
        ISetFactory defaultSetBottom = ISetFactory.CreateSetFactory(Figure.CollectionType.Default);
        defaultSetBottom.SetFigureOnField(5, 5, currentGameField, Figure.TypesOfFigure.King, Figure.Side.Upper, Figure.SpriteModel.Alternative);
        defaultSetBottom.SetFigureOnField(1, 1, currentGameField, Figure.TypesOfFigure.Rook, Figure.Side.Upper, Figure.SpriteModel.Alternative);

        ISetFactory defaultSeUpper = ISetFactory.CreateSetFactory(Figure.CollectionType.Default);
        defaultSeUpper.SetFigureOnField(2, 2, currentGameField, Figure.TypesOfFigure.Rook, Figure.Side.Bottom, Figure.SpriteModel.Origin);
        defaultSeUpper.SetFigureOnField(2, 5, currentGameField,Figure.TypesOfFigure.Rook, Figure.Side.Bottom, Figure.SpriteModel.Origin);
    }

    public void onClick()
    {
        if(StaticDataContainer.currentGameMode == StaticDataContainer.GameMode.Multiplayer)
            photonView.RPC("ButtonAction", RpcTarget.All, 1);
        else
            currentPlayer = currentGameField.ClickActionSelecter(currentPlayer);

        if(lastFigureMove != currentGameField.lastFigureMoves)
        {
            string[] figureArr = currentGameField.lastFigureMoves.Split(',');
            string[] figureMoves;
            string[] movesFromYX;
            string[] movesToYX;
            for (int i = 0; i < figureArr.Length; i++)
            {
                figureMoves = figureArr[i].Split(' ');
                movesFromYX = figureMoves[0].Split('_');
                movesToYX = figureMoves[1].Split('_');
                gameObject.GetComponent<MoveHistoryGenerator>().GenerateNewMoveHistoryObject(movesFromYX[0] + movesFromYX[1], movesToYX[0] + movesToYX[1]);
                if(currentGameField[int.Parse(movesToYX[0]), int.Parse(movesToYX[1])].CurrentFigure.FigureType == Figure.TypesOfFigure.Pawn)
                {
                    if (int.Parse(movesToYX[0]) == 1 || int.Parse(movesToYX[0]) == currentGameField.GetGameField().GetLength(1) - 2)
                    {
                        Debug.Log("LOLOLO");
                        var prefab = Resources.Load($"Prefabs/FigureScrollView/FigureScrollView");

                        GameObject replaysPawnMenu = Instantiate(prefab, whitePlayerTextBox.transform.parent) as GameObject;

                        replaysPawnMenu.GetComponent<ScrollViewGenerator>().fieldType = GameField.FieldType.All;

                        if(currentPlayer == Figure.Side.Bottom)
                            replaysPawnMenu.GetComponent<ScrollViewGenerator>().spriteModel = Figure.SpriteModel.Alternative;
                        else
                            replaysPawnMenu.GetComponent<ScrollViewGenerator>().spriteModel = Figure.SpriteModel.Origin;

                        replaysPawnMenu.GetComponent<ScrollViewGenerator>().ReCreateScrollView(ChangeFigureOnBoard);

                        lastFigureMoveCell = currentGameField[int.Parse(movesToYX[0]), int.Parse(movesToYX[1])];

                        turnIsEnd = false;
                    }
                }
                lastFigureMoveCell = currentGameField[int.Parse(movesToYX[0]), int.Parse(movesToYX[1])];
            }

            lastFigureMove = currentGameField.lastFigureMoves;
        }
    }

    [PunRPC]
    public void ButtonAction(int i)
    {        
        if(Figure.GetFigureSideByName(PhotonNetwork.LocalPlayer.CustomProperties["PS"].ToString()) == currentPlayer)
        {
            Figure.Side tempCurrentPlayer = currentGameField.ClickActionSelecter(currentPlayer);
            if (tempCurrentPlayer != currentPlayer)
            {
                currentPlayer = tempCurrentPlayer;
                turnIsEnd = true;
            }            
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            if(turnIsEnd)
            {
                stream.SendNext(currentGameField.lastFigureMoves);
                if (lastFigureMoveCell.CurrentFigure != null)
                {
                    stream.SendNext(Figure.GetStringNameOfFigure(lastFigureMoveCell.CurrentFigure.FigureType));
                    stream.SendNext(Figure.GetStringNameOfCollection(lastFigureMoveCell.CurrentFigure.FigureCollection));
                    stream.SendNext(Figure.GetStringNameByFigureSprite(lastFigureMoveCell.CurrentFigure.FigureSprite));
                }
                if (currentPlayer == Figure.Side.Bottom)
                    stream.SendNext("Bottom");
                else
                    stream.SendNext("Upper");
                photonView.TransferOwnership(PhotonNetwork.PlayerListOthers[0]);

                turnIsEnd = false;
            }
        }

        else if (stream.IsReading)
        {
            if (stream.Count > 2)
            {
                string lastMove = (string)stream.ReceiveNext();
                currentPlayer = currentGameField.PlaceFigureOnByXY(lastMove, currentPlayer, Figure.GetFigureTypeByName((string)stream.ReceiveNext()),
                    Figure.GetCollectionTypeByName((string)stream.ReceiveNext()), Figure.GetFigureSpriteByName((string)stream.ReceiveNext()));
                currentPlayer = Figure.GetFigureSideByName((string)stream.ReceiveNext());
                game.AddMove(lastMove, currentPlayer);
                string[] figureArr = lastMove.Split(',');
                string[] figureMoves;
                string[] movesFromYX;
                string[] movesToYX;
                for (int i = 0; i < figureArr.Length; i++)
                {
                    figureMoves = figureArr[i].Split(' ');
                    movesFromYX = figureMoves[0].Split('_');
                    movesToYX = figureMoves[1].Split('_');
                    gameObject.GetComponent<MoveHistoryGenerator>().GenerateNewMoveHistoryObject(movesFromYX[0] + movesFromYX[1], movesToYX[0] + movesToYX[1]);
                }
                Debug.Log(lastMove);
            }
        }
    }

    void SetBlackFigure(GameField gameField, string[,] blackFigureBoard)
    {
        ISetFactory figureFactory;
        for(int i = 0; i < gameField.GetGameField().GetLength(0);i++)
        {
            for (int j = 0; j < gameField.GetGameField().GetLength(1); j++)
            {
                if (gameField.GetGameField()[j, i].GetLinckedCell() == null)
                    continue;
                if (i - 1 >= blackFigureBoard.GetLength(0) || j - 1 >= blackFigureBoard.GetLength(1))
                    continue;
                Cell currentCell = gameField.GetGameField()[j, i];
                string currentFigure = blackFigureBoard[i - 1, j - 1];
                if (currentFigure.Split(" ")[0] == "None" || currentFigure.Split(" ")[1] == "None")
                {
                    continue;
                }
                Figure.CollectionType collectionType = Figure.GetCollectionTypeByName(currentFigure.Split(" ")[0]);
                Figure.TypesOfFigure typesOfFigure = Figure.GetFigureTypeByName(currentFigure.Split(" ")[1]);
                Color cellColor = currentCell.GetLinckedCell().GetComponent<Image>().color;
                cellColor.a = 1;
                currentCell.GetLinckedCell().GetComponent<Image>().color = cellColor;
                figureFactory = ISetFactory.CreateSetFactory(collectionType);
                figureFactory.SetFigureOnField(j, i, currentGameField, typesOfFigure,Figure.Side.Upper,Figure.SpriteModel.Alternative);
            }
        }
    }

    void SetWhiteFigure(GameField gameField, string[,] whiteFigureBoard)
    {
        ISetFactory figureFactory;
        int counter = whiteFigureBoard.GetLength(0) - 1;
        for (int i = gameField.GetGameField().GetLength(0) - 2; i >= 1; i--)
        {
            for (int j = 0; j < gameField.GetGameField().GetLength(1); j++)
            {
                if (gameField.GetGameField()[j, i].GetLinckedCell() == null)
                    continue;
                if (j - 1 >= whiteFigureBoard.GetLength(1))
                    continue;
                Cell currentCell = gameField.GetGameField()[j, i];
                string currentFigure = whiteFigureBoard[counter, j - 1];
                if (currentFigure.Split(" ")[0] == "None" || currentFigure.Split(" ")[1] == "None")
                {
                    continue;
                }
                Figure.CollectionType collectionType = Figure.GetCollectionTypeByName(currentFigure.Split(" ")[0]);
                Figure.TypesOfFigure typesOfFigure = Figure.GetFigureTypeByName(currentFigure.Split(" ")[1]);
                Color cellColor = currentCell.GetLinckedCell().GetComponent<Image>().color;
                cellColor.a = 1;
                currentCell.GetLinckedCell().GetComponent<Image>().color = cellColor;
                figureFactory = ISetFactory.CreateSetFactory(collectionType);
                figureFactory.SetFigureOnField(j, i, currentGameField, typesOfFigure, Figure.Side.Bottom, Figure.SpriteModel.Origin);
            }
            counter--;
            if (counter < 0)
                return;
        }
    }

    void EndGameAction(string gameResult)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        if (StaticDataContainer.currentGameMode == StaticDataContainer.GameMode.Multiplayer)
        {


            file = File.Open(Application.persistentDataPath + $"/UserName.dat", FileMode.Open);

            UserDataAndSettings userData = (UserDataAndSettings)bf.Deserialize(file);

            file.Close();

            userData.countOfGames++;

            string[] gameResultStringParts = gameResult.Split(' ');
            switch (gameResultStringParts[0])
            {
                case "Ничья.":
                    userData.countOfPatAndDraw++;
                    break;
                case "ПАТ.":
                    userData.countOfPatAndDraw++;
                    break;
                case "Мат.":
                    if(gameResultStringParts[2] == "Черные")
                    {
                        if ((string)PhotonNetwork.LocalPlayer.CustomProperties["PS"] == "Upper")
                            userData.countOfWins++;
                        else
                            userData.countOfLose++;
                    }
                    else
                    {
                        if ((string)PhotonNetwork.LocalPlayer.CustomProperties["PS"] == "Bottom")
                            userData.countOfWins++;
                        else
                            userData.countOfLose++;
                    }
                    break;
            }

            file = File.Create(Application.persistentDataPath + $"/UserName.dat");

            bf.Serialize(file, userData);

            file.Close();

            PhotonNetwork.Disconnect();
        }

        

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

    void WriteGameHistory()
    {

        int countOfSaves = Directory.GetFiles(Application.persistentDataPath + @"/GameHistory").Length;

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + @"/GameHistory" + $"/GameHistory_{countOfSaves + 1}.dat");

        game.GameNumber = countOfSaves + 1;

        game.typeOfMap = StaticDataContainer.currentMap;

        bf.Serialize(file, game);

        file.Close();
    }

    void ChangeFigureOnBoard(Figure.TypesOfFigure type, Figure.CollectionType collection, Figure.SpriteModel sprite)
    {
        Figure.Side side;
        if (currentPlayer == Figure.Side.Bottom)
        {
            side = Figure.Side.Upper; 
        }
        else
        {
            side = Figure.Side.Bottom;
        }

        ISetFactory setFactory = ISetFactory.CreateSetFactory(collection);

        lastFigureMoveCell.CurrentFigure = setFactory.CreateFigure(type, side, sprite);

        lastFigureMoveCell.GetLinckedCell().GetComponent<Image>().sprite = ObjectSpritesChooser.GetFigureSprite(type, collection, sprite);

        turnIsEnd = true;
    }
}
