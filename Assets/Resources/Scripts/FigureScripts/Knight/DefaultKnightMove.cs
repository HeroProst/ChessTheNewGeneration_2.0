using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultKnightMove : IMoveBehaiver
{
	public List<Cell> traceTypeMove(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove = new List<Cell>();
		for (int i = 0; i < 5; i++)
		{
			if (i % 2 != 0)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos - 2, currentFigure.XPos + i - 2) != null)
				{
					if (gameField.FindCellByCoordinates(currentFigure.YPos - 2, currentFigure.XPos + i - 2).CurrentFigure == null)
						pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - 2, currentFigure.XPos + i - 2));
					else
						if (gameField.FindCellByCoordinates(currentFigure.YPos - 2, currentFigure.XPos + i - 2).CurrentFigure.FigureSide == currentFigure.FigureSide)
						pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - 2, currentFigure.XPos + i - 2));
				}

				if (gameField.FindCellByCoordinates(currentFigure.YPos + 2, currentFigure.XPos + i - 2) != null)
				{
					if (gameField.FindCellByCoordinates(currentFigure.YPos + 2, currentFigure.XPos + i - 2).CurrentFigure == null)
						pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + 2, currentFigure.XPos + i - 2));
					else
						if (gameField.FindCellByCoordinates(currentFigure.YPos + 2, currentFigure.XPos + i - 2).CurrentFigure.FigureSide == currentFigure.FigureSide)
						pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + 2, currentFigure.XPos + i - 2));
				}

			}
		}
		for (int i = 0; i < 5; i++)
		{
			if (i % 2 != 0)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos - 2) != null)
				{
					if (gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos - 2).CurrentFigure == null)
						pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos - 2));
					else
						if (gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos - 2).CurrentFigure.FigureSide == currentFigure.FigureSide)
						pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos - 2));
				}
				if (gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos + 2) != null)
				{
					if (gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos + 2).CurrentFigure == null)
						pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos + 2));
					else
						if (gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos + 2).CurrentFigure.FigureSide == currentFigure.FigureSide)
						pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos + 2));
				}

			}
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
		List<Cell> pathToMove = new List<Cell>();
		for(int i = 0; i < 5;i++)
		{
			if(i % 2 != 0)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos - 2, currentFigure.XPos + i - 2) != null)
				{
					if (gameField.FindCellByCoordinates(currentFigure.YPos - 2, currentFigure.XPos + i - 2).CurrentFigure == null)
						gameField.FindCellByCoordinates(currentFigure.YPos - 2, currentFigure.XPos + i - 2).AllowCellToMove(pathToMove);
					else
						if (gameField.FindCellByCoordinates(currentFigure.YPos - 2, currentFigure.XPos + i - 2).CurrentFigure.FigureSide != currentFigure.FigureSide)
							gameField.FindCellByCoordinates(currentFigure.YPos - 2, currentFigure.XPos + i - 2).AllowCellToMove(pathToMove);
				}

				if (gameField.FindCellByCoordinates(currentFigure.YPos + 2, currentFigure.XPos + i - 2) != null)
				{
					if (gameField.FindCellByCoordinates(currentFigure.YPos + 2, currentFigure.XPos + i - 2).CurrentFigure == null)
						gameField.FindCellByCoordinates(currentFigure.YPos + 2, currentFigure.XPos + i - 2).AllowCellToMove(pathToMove);
					else
						if (gameField.FindCellByCoordinates(currentFigure.YPos + 2, currentFigure.XPos + i - 2).CurrentFigure.FigureSide != currentFigure.FigureSide)
						gameField.FindCellByCoordinates(currentFigure.YPos + 2, currentFigure.XPos + i - 2).AllowCellToMove(pathToMove);
				}

			}
		}
		for (int i = 0; i < 5; i++)
		{
			if (i % 2 != 0)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos - 2) != null)
				{
					if (gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos - 2).CurrentFigure == null)
						gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos - 2).AllowCellToMove(pathToMove);
					else
						if (gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos - 2).CurrentFigure.FigureSide != currentFigure.FigureSide)
							gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos - 2).AllowCellToMove(pathToMove);
				}
				if (gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos + 2) != null)
				{
					if (gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos + 2).CurrentFigure == null)
						gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos + 2).AllowCellToMove(pathToMove);
					else
						if (gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos + 2).CurrentFigure.FigureSide != currentFigure.FigureSide)
						gameField.FindCellByCoordinates(currentFigure.YPos + i - 2, currentFigure.XPos + 2).AllowCellToMove(pathToMove);
				}

			}
		}
		return pathToMove;
	}

	public List<Cell> typeMoveToSaveKing(GameField gameField, List<Cell> dangerPath)
	{
		throw new System.NotImplementedException();
	}
}
