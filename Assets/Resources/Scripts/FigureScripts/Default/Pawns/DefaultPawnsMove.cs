using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPawnsMove : IMoveBehaiver
{
	public List<Cell> traceTypeMove(GameField gameField, Figure currentFigure)
	{
		int cellToGo = 1;
		List<Cell> pathToMove = new List<Cell>();
		if (currentFigure.FigureSide == Figure.Side.Upper)
			cellToGo = -1;
		if (gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos + cellToGo).CurrentFigure == null || gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos + cellToGo).CurrentFigure.FigureSide == currentFigure.FigureSide)
		{
			pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos + cellToGo));
		}
		if (gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos - cellToGo).CurrentFigure == null || gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos - cellToGo).CurrentFigure.FigureSide == currentFigure.FigureSide)
		{
			pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos - cellToGo));
		}
		return pathToMove;
	}

	public List<Cell> traceTypeMoveToKing(GameField gameField, Figure currentFigure)
	{
		List<Cell> cells = new List<Cell>();
		cells.Add(gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos));
		return cells;
	}

	public List<Cell> typeMove(GameField gameField, Figure currentFigure)
	{
		int cellToGo = 1;
		List<Cell> pathToMove = new List<Cell>();
		if (currentFigure.FigureSide == Figure.Side.Upper)
			cellToGo = -1;
		if (gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos + cellToGo).CurrentFigure != null && gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos + cellToGo).CurrentFigure.FigureSide != currentFigure.FigureSide)
		{
			if (!currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos + cellToGo)))
				gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos + cellToGo).AllowCellToMove(pathToMove, Figure.TypesOfFigure.Pawn);
			if (currentFigure.allowedCells.Count > 0)
			{
				if (currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos + cellToGo)))
					gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos + cellToGo).AllowCellToMove(pathToMove, Figure.TypesOfFigure.Pawn);
			}
		}
		if (gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos).CurrentFigure == null)
		{
			if (!currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos)) && currentFigure.forbbidenCells.Count > 0)
				gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos).AllowCellToMove(pathToMove);
			else
            {
				if (currentFigure.allowedCells.Count > 0)
				{
					if (currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos)))
						gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos).AllowCellToMove(pathToMove);
				}
				else
                {
					gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos).AllowCellToMove(pathToMove);
				}
			}
			if (currentFigure.moveCount == 0)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo * 2, currentFigure.XPos) != null)
					if (gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo * 2, currentFigure.XPos).CurrentFigure == null)
                    {
						if (!currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo * 2, currentFigure.XPos)) && currentFigure.forbbidenCells.Count > 0)
							gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo * 2, currentFigure.XPos).AllowCellToMove(pathToMove);
						else
                        {
							if (currentFigure.allowedCells.Count > 0)
							{
								if (currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo * 2, currentFigure.XPos)))
									gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo * 2, currentFigure.XPos).AllowCellToMove(pathToMove);
							}
							else
                            {
								gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo * 2, currentFigure.XPos).AllowCellToMove(pathToMove);
							}
						}
                    }
			}
		}
		if (gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos - cellToGo).CurrentFigure != null && gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos - cellToGo).CurrentFigure.FigureSide != currentFigure.FigureSide)
		{
			if (!currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos - cellToGo)))
				gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos - cellToGo).AllowCellToMove(pathToMove, Figure.TypesOfFigure.Pawn);
			if (currentFigure.allowedCells.Count > 0)
			{
				if (currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos - cellToGo)))
					gameField.FindCellByCoordinates(currentFigure.YPos - cellToGo, currentFigure.XPos - cellToGo).AllowCellToMove(pathToMove, Figure.TypesOfFigure.Pawn);
			}
		}
		return pathToMove;
	}

	public List<Cell> typeMoveToSaveKing(GameField gameField, List<Cell> dangerPath)
	{
		throw new System.NotImplementedException();
	}
}
