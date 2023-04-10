using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultRookMove : IMoveBehaiver
{
	public List<Cell> traceTypeMove(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove = new List<Cell>();
		for (int i = currentFigure.YPos - 1; ; i--) // ^
		{
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure == null)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
				continue;
			}
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(i, currentFigure.XPos).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					pathToMove.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
					break;
				}
				else
				{
					pathToMove.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
					continue;
				}
			}
			else if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
				continue;
			}
			else if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
			}
			break;
		}
		for (int i = currentFigure.XPos + 1; ; i++) // >
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure == null)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
					break;
				}
				else
				{
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
					continue;
				}
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
				continue;
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
			}
			break;

		}
		for (int i = currentFigure.YPos + 1; ; i++) // V
		{
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure == null)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
				continue;
			}
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(i, currentFigure.XPos).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					pathToMove.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
					break;
				}
				else
				{
					pathToMove.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
					continue;
				}
			}
			else if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
				continue;
			}
			else if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
			}
			break;

		}
		for (int i = currentFigure.XPos - 1; ; i--) // <
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure == null)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
					break;
				}
				else
				{
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
					continue;
				}
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
				continue;
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
			}
			break;
		}
		return pathToMove;
	}

	public List<Cell> traceTypeMoveToKing(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove = new List<Cell>();
		List<Cell> tempMoveList = new List<Cell>();
		pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos));
		for (int i = currentFigure.YPos - 1; ; i--) // ^
		{
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure == null)
			{
				tempMoveList.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
				continue;
			}
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(i, currentFigure.XPos).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					break;
				}
				else
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
					continue;
				}
			}
			else if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				pathToMove.AddRange(tempMoveList);
				break;
			}
			break;
		}
		tempMoveList.Clear();
		for (int i = currentFigure.XPos + 1; ; i++) // >
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure == null)
			{
				tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
					break;
				}
				else
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
					continue;
				}
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				pathToMove.AddRange(tempMoveList);
				break;
			}
			break;

		}
		tempMoveList.Clear();
		for (int i = currentFigure.YPos + 1; ; i++) // V
		{
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure == null)
			{
				tempMoveList.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
				continue;
			}
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(i, currentFigure.XPos).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
					break;
				}
				else
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(i, currentFigure.XPos));
					continue;
				}
			}
			else if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				pathToMove.AddRange(tempMoveList);
				break;
			}
			break;

		}
		tempMoveList.Clear();
		for (int i = currentFigure.XPos - 1; ; i--) // <
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure == null)
			{
				tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
					break;
				}
				else
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos, i));
					continue;
				}
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				pathToMove.AddRange(tempMoveList);
				break;
			}
			break;
		}
		return pathToMove;
	}

	public List<Cell> typeMove(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove = new List<Cell>();
		for (int i = currentFigure.YPos - 1;; i--) // ^
		{
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure == null)
			{
				gameField.FindCellByCoordinates(i, currentFigure.XPos).AllowCellToMove(pathToMove);
				continue;
			}
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(i, currentFigure.XPos).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					gameField.FindCellByCoordinates(i, currentFigure.XPos).AllowCellToMove(pathToMove);
					break;
				}
				else
				{
					gameField.FindCellByCoordinates(i, currentFigure.XPos).AllowCellToMove(pathToMove);
					continue;
				}
			}
			break;
		}
		for (int i = currentFigure.XPos + 1;; i++) // >
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure == null)
			{
				gameField.FindCellByCoordinates(currentFigure.YPos, i).AllowCellToMove(pathToMove);
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					gameField.FindCellByCoordinates(currentFigure.YPos, i).AllowCellToMove(pathToMove);
					break;
				}
				else
				{
					gameField.FindCellByCoordinates(currentFigure.YPos, i).AllowCellToMove(pathToMove);
					continue;
				}
			}
			break;

		}
		for (int i = currentFigure.YPos + 1;; i++) // V
		{
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure == null)
			{
				gameField.FindCellByCoordinates(i, currentFigure.XPos).AllowCellToMove(pathToMove);
				continue;
			}
			if (gameField.FindCellByCoordinates(i, currentFigure.XPos).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(i, currentFigure.XPos).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					gameField.FindCellByCoordinates(i, currentFigure.XPos).AllowCellToMove(pathToMove);
					break;
				}
				else
				{
					gameField.FindCellByCoordinates(i, currentFigure.XPos).AllowCellToMove(pathToMove);
					continue;
				}
			}
			break;

		}
		for (int i = currentFigure.XPos - 1;; i--) // <
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure == null)
			{
				gameField.FindCellByCoordinates(currentFigure.YPos, i).AllowCellToMove(pathToMove);
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos, i).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos, i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					gameField.FindCellByCoordinates(currentFigure.YPos, i).AllowCellToMove(pathToMove);
					break;
				}
				else
				{
					gameField.FindCellByCoordinates(currentFigure.YPos, i).AllowCellToMove(pathToMove);
					continue;
				}
			}
			break;
		}
		return pathToMove;
	}

	public List<Cell> typeMoveToSaveKing(GameField gameField, List<Cell> dangerPath)
	{
		throw new System.NotImplementedException();
	}
}
