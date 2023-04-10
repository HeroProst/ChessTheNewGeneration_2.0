using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultPawns : Figure
{
	public DefaultPawns(Side figureSide, SpriteModel figureSprite)
	{
		FigureSide = figureSide;
		FigureSprite = figureSprite;

		FigureType = TypesOfFigure.Pawn;
		FigureCollection = CollectionType.Default;

		moveBehaiver = new DefaultPawnsMove();
	}

	public override void MoveFigure(Cell cellToMoveFigure, Cell cellFromMoveCell, GameField currentGameField)
	{
		Color cellColor;

		if (moveCount < 1)
		{
			int cellToGo = 1;
			if (FigureSide == Side.Upper)
			{
				cellToGo = -1;
			}
			if (Mathf.Abs(cellToMoveFigure.XPos - cellFromMoveCell.XPos) < 1)
			{
				currentGameField.GetGameField()[cellFromMoveCell.YPos - cellToGo, cellFromMoveCell.XPos].CurrentFigure = this;
				cellColor = currentGameField.GetGameField()[cellFromMoveCell.YPos - cellToGo, cellFromMoveCell.XPos].GetLinckedCell().GetComponent<Image>().color;
				cellColor.a = 0;
				currentGameField.GetGameField()[cellFromMoveCell.YPos - cellToGo, cellFromMoveCell.XPos].GetLinckedCell().GetComponent<Image>().color = cellColor;
				cellsWithClone.Add(cellToMoveFigure);
				cellsWithClone.Add(currentGameField.GetGameField()[cellFromMoveCell.YPos - cellToGo, cellFromMoveCell.XPos]);
			}
		}
		cellToMoveFigure.CurrentFigure = cellFromMoveCell.CurrentFigure;
		cellToMoveFigure.GetLinckedCell().GetComponent<Image>().sprite = cellFromMoveCell.GetLinckedCell().GetComponent<Image>().sprite;

		cellColor = cellFromMoveCell.GetLinckedCell().GetComponent<Image>().color;
		cellColor.a = 0;
		cellFromMoveCell.GetLinckedCell().GetComponent<Image>().color = cellColor;

		cellFromMoveCell.CurrentFigure = null;
		cellFromMoveCell.GetLinckedCell().GetComponent<Image>().sprite = null;

		this.moveCount++;
	}
}