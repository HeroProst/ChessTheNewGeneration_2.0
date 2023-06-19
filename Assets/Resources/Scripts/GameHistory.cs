using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[Serializable]

public class GameHistory
{
    public string[,] primaryGameBoard;

    public List<string> gameMoves = new List<string>();

    public StaticDataContainer.TypeOfMaps typeOfMap;

    public int GameNumber;

    public GameHistory(GameObject primaryGameBoard)
    {
        Transform[] rowsInGameBoarder = new Transform[primaryGameBoard.transform.childCount];
        for (int i = 0; i < primaryGameBoard.transform.childCount; i++)
        {
            rowsInGameBoarder[i] = primaryGameBoard.transform.GetChild(i);
        }
        this.primaryGameBoard = new string[rowsInGameBoarder.Length, rowsInGameBoarder[0].childCount];
        for (int i = 0; i < rowsInGameBoarder.Length; i++)
        {
            for (int j = 0; j < rowsInGameBoarder[i].childCount; j++)
            {
                this.primaryGameBoard[i, j] = $"{rowsInGameBoarder[i].GetChild(j).GetComponent<Image>().sprite}";
            }
        }
    }

    public void AddMove(string figureMove, Figure.Side side)
    {
        string[] figureArr = figureMove.Split(',');
        string[] figureMoves;
        string[] movesFromYX;
        string[] movesToYX;
        StringBuilder move = new StringBuilder();
        for (int i = 0; i < figureArr.Length; i++)
        {
            figureMoves = figureArr[i].Split(' ');
            movesFromYX = figureMoves[0].Split('_');
            movesToYX = figureMoves[1].Split('_');
            if (side == Figure.Side.Upper)
                gameMoves.Add(movesFromYX[0] + movesFromYX[1] + " " + movesToYX[0] + movesToYX[1] + " " + "черные");
            else
                gameMoves.Add(movesFromYX[0] + movesFromYX[1] + " " + movesToYX[0] + movesToYX[1] + " " + "белые");
        }
    }
}
