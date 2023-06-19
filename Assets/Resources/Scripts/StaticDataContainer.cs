using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticDataContainer
{
    public static string[,] YourFigureBoard;

	public static string[,] EnemyFigureBoard;

	public static GameMode currentGameMode;

	public static string UserName;

	public static string LobbyNameSearch = "";

	public static TypeOfMaps currentMap;

	public static bool HintEnabled = true;

	public static GameHistory choisenGameHistory;

	public enum GameMode
    {
		Ai,
		Multiplayer,
        SinglePlayer
    }

    public enum TypeOfMaps
    {
		Map8x8,
		Map5x5,
		Map10x10
	}

	public static string ConvertTypeOfMapsToString(TypeOfMaps typeOfMaps)
	{
		switch (typeOfMaps)
		{
			case TypeOfMaps.Map8x8:
				return "8x8";
			case TypeOfMaps.Map5x5:
				return "5x5";
			case TypeOfMaps.Map10x10:
				return "10x10";
			default:
				return "error";
		}
	}
	public static TypeOfMaps ConvertStringToTypeOfMaps(string typeOfMaps)
	{
		switch (typeOfMaps)
		{
			case "8x8":
				return TypeOfMaps.Map8x8;
			case "5x5":
				return TypeOfMaps.Map5x5;
			case "10x10":
				return TypeOfMaps.Map10x10;
			case "Map8x8":
				return TypeOfMaps.Map8x8;
			case "Map5x5":
				return TypeOfMaps.Map5x5;
			case "Map10x10":
				return TypeOfMaps.Map10x10;
			default:
				return TypeOfMaps.Map8x8;
		}
	}

	public static void SetFigureBoard(GameObject board, Figure.Side side)
	{
		string[,] figureBoard;
		Transform[] rowsInGameBoarder = new Transform[board.transform.childCount];
		for (int i = 0; i < board.transform.childCount; i++)
		{
			rowsInGameBoarder[i] = board.transform.GetChild(i);
		}
		figureBoard = new string[rowsInGameBoarder.Length, rowsInGameBoarder[0].childCount];
		for (int i = 0; i < rowsInGameBoarder.Length; i++)
		{
			for (int j = 0; j < rowsInGameBoarder[i].childCount; j++)
			{
				BoardCellContainer cellContainer = rowsInGameBoarder[i].GetChild(j).GetComponent<BoardCellContainer>();
				figureBoard[i, j] = $"{cellContainer.figureCollection} {cellContainer.figureType}";
			}
		}
		if(side == Figure.Side.Bottom)
			YourFigureBoard = figureBoard;
		if (side == Figure.Side.Upper)
			EnemyFigureBoard = figureBoard;
	}
}
