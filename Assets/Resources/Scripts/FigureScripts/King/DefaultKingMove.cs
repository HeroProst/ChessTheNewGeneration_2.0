using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultKingMove : IMoveBehaiver
{
	public List<Cell> traceTypeMove(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove = new List<Cell>();
		for (int i = 0; i < 3; i++)
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + i - 1) != null)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + i - 1).CurrentFigure == null)
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + i - 1));
				else
					if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + i - 1).CurrentFigure.FigureSide == currentFigure.FigureSide)
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + i - 1));
			}

			if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + i - 1) != null)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + i - 1).CurrentFigure == null)
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + i - 1));
				else
					if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + i - 1).CurrentFigure.FigureSide == currentFigure.FigureSide)
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + i - 1));
			}
		}
		//<<<
		if (gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos - 1).CurrentFigure == null)
			pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos - 1));
		else
			if (gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos - 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
			pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos - 1));
		//>>>
		if (gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos + 1).CurrentFigure == null)
			pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos + 1));
		else
			if (gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos + 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
			pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos + 1));
		return pathToMove;
	}

	public List<Cell> typeMove(GameField gameField, Figure currentFigure)
	{
		CastleMoveCheck(gameField, currentFigure);
		List<Cell> pathToMove = new List<Cell>();
		for (int i = 0; i < 3; i++)
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + i - 1) != null)
			{
				if (!gameField.GetDangerCellsForKing(currentFigure.FigureSide).Contains(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + i - 1)))
				{
					if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + i - 1).CurrentFigure == null)
						gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + i - 1).AllowCellToMoveAnyway(pathToMove);
					else
						if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + i - 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
							gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + i - 1).AllowCellToMoveAnyway(pathToMove);
				}
			}

			if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + i - 1) != null)
			{
				if (!gameField.GetDangerCellsForKing(currentFigure.FigureSide).Contains(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + i - 1)))
				{
					if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + i - 1).CurrentFigure == null)
						gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + i - 1).AllowCellToMoveAnyway(pathToMove);
					else
						if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + i - 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
							gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + i - 1).AllowCellToMoveAnyway(pathToMove);
				}
			}
		}
		//<<<
		if (!gameField.GetDangerCellsForKing(currentFigure.FigureSide).Contains(gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos - 1)))
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos - 1).CurrentFigure == null)
				gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos - 1).AllowCellToMoveAnyway(pathToMove);
			else
				if (gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos - 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
					gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos - 1).AllowCellToMoveAnyway(pathToMove);
		}
		//>>>
		if (!gameField.GetDangerCellsForKing(currentFigure.FigureSide).Contains(gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos + 1)))
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos + 1).CurrentFigure == null)
				gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos + 1).AllowCellToMoveAnyway(pathToMove);
			else
				if (gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos + 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
					gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos + 1).AllowCellToMoveAnyway(pathToMove);
		}
		return pathToMove;
	}

	void CastleMoveCheck(GameField gameField, Figure currentFigure)
	{
		if (currentFigure.moveCount != 0)
			return;
		if (gameField.GetDangerCellsForKing(currentFigure.FigureSide).Contains(gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos)))
			return;
		for (int i = currentFigure.XPos + 1;i < gameField.GetGameField().GetLength(1);i++)
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i) == null)
				break;
			if (gameField.GetDangerCellsForKing(currentFigure.FigureSide).Contains(gameField.FindCellByCoordinates(currentFigure.YPos, i)))
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure == null)
				continue;
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureSide != currentFigure.FigureSide)
				break;
			if(gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureType == Figure.TypesOfFigure.Rook && gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.moveCount == 0)
			{
				gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell().tag = "CastelRook";
				gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell().GetComponent<Image>().color = Color.green;
				break;
			}

		}
		for (int i = currentFigure.XPos - 1; i > 0; i--)
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i) == null)
				break;
			if (gameField.GetDangerCellsForKing(currentFigure.FigureSide).Contains(gameField.FindCellByCoordinates(currentFigure.YPos, i)))
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure == null)
				continue;
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureSide != currentFigure.FigureSide)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureType == Figure.TypesOfFigure.Rook && gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.moveCount == 0)
			{
				gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell().tag = "CastelRook";
				gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell().GetComponent<Image>().color = Color.green;
				break;
			}
		}
	}
	
	public List<Cell> typeMoveToSaveKing(GameField gameField, List<Cell> dangerPath)
	{
		throw new System.NotImplementedException();
	}

	public List<Cell> traceTypeMoveToKing(GameField gameField, Figure currentFigure)
	{
		throw new System.NotImplementedException();
	}
}
