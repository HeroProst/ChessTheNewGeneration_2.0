using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SetSave
{
    public string[,] savedBoard;
    public int currentSetPrice;

    public SetSave(GameObject board, Figure.Side side)
    {
        int offset;
        if (side == Figure.Side.Bottom)
        {
            offset = 0;
        }
        else
        {
            offset = -1;
        }
        Transform[] rowsInGameBoarder = new Transform[board.transform.childCount];
		for (int i = 0; i < board.transform.childCount; i++)
		{
			rowsInGameBoarder[i] = board.transform.GetChild(i);
		}
		savedBoard = new string[rowsInGameBoarder.Length, rowsInGameBoarder[0].childCount];
        for (int i = 1 + offset; i < rowsInGameBoarder.Length + offset; i++)
        {
            for (int j = 0; j < rowsInGameBoarder[i].childCount; j++)
            {
				BoardCellContainer cellContainer = rowsInGameBoarder[i].GetChild(j).GetComponent<BoardCellContainer>();
				savedBoard[i, j] = $"{cellContainer.figureCollection} {cellContainer.figureType} {cellContainer.price}";
			}
		}
        if (side == Figure.Side.Upper)
            savedBoard = MatrixAction.ReverseMatrix(savedBoard);
	}

    public void LoadGameBoard(GameObject board, string[,] savedBoard, Figure.Side side)
    {
        Transform[] rowsInGameBoarder = new Transform[board.transform.childCount];

        int offset;

        string[,] currentSavedBoard = savedBoard;
        Figure.SpriteModel spriteModel;

        for (int i = 0; i < board.transform.childCount; i++)
        {
            rowsInGameBoarder[i] = board.transform.GetChild(i);
        }
        if(side == Figure.Side.Bottom)
        {
            offset = 0;
            spriteModel = Figure.SpriteModel.Origin;
        }
        else
        {
            spriteModel = Figure.SpriteModel.Alternative;
            currentSavedBoard = MatrixAction.ReverseMatrix(savedBoard);
        }

        for (int i = 0; i < rowsInGameBoarder.Length; i++)
        {
            for (int j = 0; j < rowsInGameBoarder[i].childCount; j++)
            {
                if (currentSavedBoard[i, j] == null)
                    continue;
                string currentfigure = currentSavedBoard[i, j];
                GameObject cell = rowsInGameBoarder[i].GetChild(j).gameObject;
                Figure.CollectionType collectionType = Figure.GetCollectionTypeByName(currentfigure.Split(" ")[0]);
                Figure.TypesOfFigure typesOfFigure = Figure.GetFigureTypeByName(currentfigure.Split(" ")[1]);
                int price = int.Parse(currentfigure.Split(" ")[2]);
                Color cellColor = cell.GetComponent<Image>().color;

                if (currentfigure.Split(" ")[0] != "None" && currentfigure.Split(" ")[1] != "None")
                {
                    cellColor.a = 1;
                }

                ISetFactory figureFactory = ISetFactory.CreateSetFactory(collectionType);

                cell.GetComponent<BoardCellContainer>().figureCollection = collectionType;
                cell.GetComponent<BoardCellContainer>().figureType = typesOfFigure;
                cell.GetComponent<BoardCellContainer>().price = price;

                Debug.Log(figureFactory.CreateFigure(typesOfFigure, Figure.Side.Bottom, Figure.SpriteModel.Origin).price);

                if (cell.GetComponent<BoardCellContainer>().figureCollection == Figure.CollectionType.None || cell.GetComponent<BoardCellContainer>().figureType == Figure.TypesOfFigure.None)
                {
                    cell.GetComponent<Image>().sprite = null;
                    cellColor.a = 0;
                }
                else
                    cellColor.a = 1;
                cell.GetComponent<Image>().color = cellColor;
                if (cell.GetComponent<Image>().color.a == 1)
                    cell.GetComponent<Image>().sprite = ObjectSpritesChooser.GetFigureSprite(typesOfFigure, collectionType, spriteModel);
            }
        }
    }
}
