using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultBishopMove : IMoveBehaiver
{
	public List<Cell> traceTypeMove(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove = new List<Cell>();
		for (int i = 1; ; i++) // ^
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).CurrentFigure == null)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i));
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i));
					break;
				}
				else
				{
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i));
					continue;
				}
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i));
				continue;
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i));
			}
			break;
		}
		/**
		for (int i = 1; ; i++)
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).CurrentFigure == null)
				continue;
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).CurrentFigure.FigureSide == currentFigure.FigureSide)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				return pathToMove;
			}
		}
		pathToMove.Clear();
		**/

		for (int i = 1; ; i++) // >
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).CurrentFigure == null)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i));
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i));
					break;
				}
				else
				{
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i));
					continue;
				}
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i));
				continue;
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i));
			}
			break;
		}
		/**
		for (int i = 1; ; i++)
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).CurrentFigure == null)
				continue;
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).CurrentFigure.FigureSide == currentFigure.FigureSide)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				return pathToMove;
			}
		}
		pathToMove.Clear();
		**/

		for (int i = 1; ; i++) // V
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).CurrentFigure == null)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i));
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i));
					break;
				}
				else
				{
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i));
					continue;
				}
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i));
				continue;
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i));
			}
			break;
		}
		/**
		for (int i = 1; ; i++)
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).CurrentFigure == null)
				continue;
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).CurrentFigure.FigureSide == currentFigure.FigureSide)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				return pathToMove;
			}
		}
		pathToMove.Clear();
		**/

		for (int i = 1; ; i++) // <
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).CurrentFigure == null)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i));
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i));
					break;
				}
				else
				{
					pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i));
					continue;
				}
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i));
				continue;
			}
			else if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i));
			}
			break;
		}

		/**
		for (int i = 1; ; i++)
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).CurrentFigure == null)
				continue;
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).CurrentFigure.FigureSide == currentFigure.FigureSide)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
			{
				return pathToMove;
			}
		}
		pathToMove.Clear();
		**/

		return pathToMove;
	}

	public List<Cell> traceTypeMoveToKing(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove = new List<Cell>();
		List<Cell> tempMoveList = new List<Cell>();
		pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos, currentFigure.XPos));
		for (int i = 1; ; i++) // ^
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).CurrentFigure == null)
			{
				tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i));
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i));
					break;
				}
				else
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i));
					continue;
				}
			}
			else
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
				{
					pathToMove.AddRange(tempMoveList);
					return pathToMove;
				}
				tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i));
				continue;
			}
		}
		tempMoveList.Clear();

		for (int i = 1; ; i++) // >
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).CurrentFigure == null)
			{
				tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i));
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i));
					break;
				}
				else
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i));
					continue;
				}
			}
			else
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
				{
					pathToMove.AddRange(tempMoveList);
					return pathToMove;
				}
				tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i));
				continue;
			}
		}
		tempMoveList.Clear();

		for (int i = 1; ; i++) // V
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).CurrentFigure == null)
			{
				tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i));
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i));
					break;
				}
				else
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i));
					continue;
				}
			}
			else
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
				{
					pathToMove.AddRange(tempMoveList);
					return pathToMove;
				}
				tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i));
				continue;
			}
		}

		tempMoveList.Clear();

		for (int i = 1; ; i++) // <
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).GetLinckedCell() == null)
				break;
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).CurrentFigure == null)
			{
				tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i));
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).CurrentFigure.FigureSide == currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i));
					break;
				}
				else
				{
					tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i));
					continue;
				}
			}
			else
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).CurrentFigure.FigureType == Figure.TypesOfFigure.King)
				{
					pathToMove.AddRange(tempMoveList);
					return pathToMove;
				}
				tempMoveList.Add(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i));
				continue;
			}
		}

		tempMoveList.Clear();

		return pathToMove;
	}

	public List<Cell> typeMove(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove = new List<Cell>();
		for (int i = 1; ; i++) // ^
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).GetLinckedCell() == null)
				break;
			if (currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i)))
				continue;
			if(currentFigure.allowedCells.Count > 0)
            {
				if (!currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i)))
					continue;
            }
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).CurrentFigure == null)
			{
				gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).AllowCellToMove(pathToMove);
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).AllowCellToMove(pathToMove);
					break;
				}
				else
				{
					gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i).AllowCellToMove(pathToMove);
					continue;
				}
			}
			break;
		}
		for (int i = 1; ; i++) // >
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).GetLinckedCell() == null)
				break;
			if (currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i)))
				continue;
			if (currentFigure.allowedCells.Count > 0)
			{
				if (!currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos + i)))
					continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).CurrentFigure == null)
			{
				gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).AllowCellToMove(pathToMove);
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).AllowCellToMove(pathToMove);
					break;
				}
				else
				{
					gameField.FindCellByCoordinates(currentFigure.YPos + i, currentFigure.XPos - i).AllowCellToMove(pathToMove);
					continue;
				}
			}
			break;
		}
		for (int i = 1; ; i++) // V
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).GetLinckedCell() == null)
				break;
			if (currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i)))
				continue;
			if (currentFigure.allowedCells.Count > 0)
			{
				if (!currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i)))
					continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).CurrentFigure == null)
			{
				gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).AllowCellToMove(pathToMove);
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).AllowCellToMove(pathToMove);
					break;
				}
				else
				{
					gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos - i).AllowCellToMove(pathToMove);
					continue;
				}
			}
			break;
		}
		for (int i = 1; ; i++) // <
		{
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).GetLinckedCell() == null)
				break;
			if (currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i)))
				continue;
			if (currentFigure.allowedCells.Count > 0)
			{
				if (!currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i)))
					continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).CurrentFigure == null)
			{
				gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).AllowCellToMove(pathToMove);
				continue;
			}
			if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).CurrentFigure.FigureSide != currentFigure.FigureSide)
			{
				if (gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).AllowCellToMove(pathToMove);
					break;
				}
				else
				{
					gameField.FindCellByCoordinates(currentFigure.YPos - i, currentFigure.XPos + i).AllowCellToMove(pathToMove);
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
