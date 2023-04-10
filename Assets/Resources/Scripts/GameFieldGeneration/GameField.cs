using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameField
{
	Cell[,] currentGameField;
	Cell pressedCell;

	public Cell this[int indexForRow,int indexForCollumn]
	{
		get 
		{
			return currentGameField[indexForRow, indexForCollumn];
		}
		set
		{
			currentGameField[indexForRow, indexForCollumn] = value;
		}
	}

	public Cell[,] GetGameField()
	{
		return currentGameField;
	}

    public GameField(GameObject gameBorder)
    {
		Transform[] rowsInGameBoarder = new Transform[gameBorder.transform.childCount];
		for(int i = 0; i < gameBorder.transform.childCount;i++)
		{
			rowsInGameBoarder[i] = gameBorder.transform.GetChild(i);
		}
		Cell[,] gameField = new Cell[rowsInGameBoarder.Length, rowsInGameBoarder[0].childCount];
		for (int i = 0; i < rowsInGameBoarder.Length; i++)
		{
			for (int j = 0; j < rowsInGameBoarder[i].childCount; j++)
			{
				gameField[i, j] = new Cell(i + 1, j + 1, rowsInGameBoarder[i].GetChild(j));
			}
		}
		currentGameField = new Cell[gameField.GetLength(0) + 2, gameField.GetLength(1) + 2];

		for (int i = 0; i < currentGameField.GetLength(0);i++)
		{
			for (int j = 0; j < currentGameField.GetLength(1); j++)
			{
				if (i == 0 || j == 0 || i == currentGameField.GetLength(0) - 1 || j == currentGameField.GetLength(1) - 1)
				{
					currentGameField[i, j] = new Border(i, j);
				}
				else
				{
					currentGameField[i, j] = gameField[i - 1, j - 1];
					currentGameField[i, j].GetLinckedCell().tag = "DefaultCell";
				}
			}
		}
	}

	public Cell FindCellByLinckedGameObject(GameObject lickedCell)
	{
		for (int i = 0; i < currentGameField.GetLength(0); i++)
		{
			for (int j = 0; j < currentGameField.GetLength(1); j++)
			{
				if(currentGameField[i,j].GetLinckedCell() == lickedCell)
				{
					return currentGameField[i, j];
				}
			}
		}
		return null;
	}

	public Cell FindCellByCoordinates(int yPos, int xPos)
	{
		Cell targetCell = null;
		if ((yPos < currentGameField.GetLength(0) && yPos >= 0) && (xPos < currentGameField.GetLength(1) && xPos >= 0))
			targetCell = currentGameField[yPos,xPos];
		return targetCell;
	}

	public Figure.Side ClickActionSelecter(Figure.Side currentPlayer)
	{
		GameObject pressedBoardCell = EventSystem.current.currentSelectedGameObject;
		Cell currentCell = FindCellByLinckedGameObject(pressedBoardCell);
		if(true)
		{
			switch (currentCell.GetLinckedCell().tag)
			{
				case "DefaultCell":
					ActionForDefaultCell(currentCell, currentPlayer);
					break;

				case "CellsForMove":
					currentPlayer = ActionForCellForMove(currentCell, currentPlayer);
					break;
				case "CastelRook":
					currentPlayer = ActionCastle(currentCell, currentPlayer);
					break;
			}
		}
		return currentPlayer;
	}

	void ActionForDefaultCell(Cell currentCell, Figure.Side currentPlayer)
	{
		ResetCells();

		if (currentCell == null)
		{
			return;
		}
		if (currentCell.CurrentFigure == null || currentCell.CurrentFigure.FigureSide != currentPlayer)
		{
			Debug.Log(currentPlayer);
			return;
		}

		List<Cell> moveCells = currentCell.CurrentFigure.Move(this);

		foreach (Cell choisenCell in moveCells)
		{
			choisenCell.GetLinckedCell().tag = "CellsForMove";
		}
		pressedCell = currentCell;
	}

	Figure.Side ActionForCellForMove(Cell currentCell, Figure.Side currentPlayer)
	{
		ResetCells();
		pressedCell.CurrentFigure.MoveFigure(currentCell, pressedCell, this);
		DeleteAllFigureClone(currentCell.CurrentFigure);
		ResetCells();
		return ChangePlayerTurn(currentPlayer);
	}

	Figure.Side ActionCastle(Cell currentCell, Figure.Side currentPlayer)
	{
		ResetCells();
		int range = Math.Abs(pressedCell.XPos - currentCell.XPos);
		int direction;
		pressedCell.CurrentFigure.moveCount++;
		currentCell.CurrentFigure.moveCount++;
		if (pressedCell.XPos > currentCell.XPos)
		{
			direction = -1;
		}
		else
		{
			direction = 1;
		}
		if(range == 1)
		{
			pressedCell.SwapFigure(currentCell);
		}
		else
		{
			pressedCell.CurrentFigure.MoveFigure(GetGameField()[pressedCell.YPos, pressedCell.XPos + direction], currentCell, this);
			pressedCell.CurrentFigure.MoveFigure(GetGameField()[pressedCell.YPos, pressedCell.XPos + (direction * 2)], pressedCell, this);
		}
		return ChangePlayerTurn(currentPlayer);
	}

	public void ResetCells()
	{
		for (int i = 0; i < currentGameField.GetLength(0); i++)
		{
			for (int j = 0; j < currentGameField.GetLength(1); j++)
			{
				if (currentGameField[i, j].GetLinckedCell() == null)
					continue;
				Color cellColor = currentGameField[i, j].GetLinckedCell().GetComponent<Image>().color;
				if (currentGameField[i, j].CurrentFigure != null)
				{
					if(GetDangerFigureForKing(currentGameField[i, j].CurrentFigure.FigureSide).Count == 0)
						cellColor = Color.white;
				}
				else
					cellColor = Color.white;
				if (currentGameField[i, j].CurrentFigure == null || currentGameField[i, j].GetLinckedCell().GetComponent<Image>().sprite == null)
				{
					currentGameField[i, j].GetLinckedCell().GetComponent<Image>().sprite = null;
					cellColor.a = 0;
				}
				currentGameField[i, j].GetLinckedCell().GetComponent<Image>().color = cellColor;
				currentGameField[i, j].GetLinckedCell().tag = "DefaultCell";
			}
		}
	}

	public void DeleteAllFigureClone(Figure exeptFigure)
	{
		for (int i = 0; i < currentGameField.GetLength(0); i++)
		{
			for (int j = 0; j < currentGameField.GetLength(1); j++)
			{
				if (currentGameField[i, j].GetLinckedCell() == null)
					continue;
				if (currentGameField[i, j].CurrentFigure != null && currentGameField[i, j].GetLinckedCell().GetComponent<Image>().sprite != null)
				{
					if(currentGameField[i, j].CurrentFigure != exeptFigure)
						currentGameField[i, j].CurrentFigure.DeleteAllCloneExeptSelf();
				}
			}
		}
	}

	public List<Cell> GetDangerCellsForKing(Figure.Side kingSide)
	{
		List<Cell> dangerCells = new List<Cell>();
		for(int i = 0; i < currentGameField.GetLength(0);i++)
		{
			for (int j = 0; j < currentGameField.GetLength(0); j++)
			{
				if (currentGameField[i, j].GetLinckedCell() == null)
					continue;
				if (currentGameField[i, j].CurrentFigure == null)
					continue;
				if (currentGameField[i, j].CurrentFigure.FigureSide == kingSide)
					continue;
				if (currentGameField[i, j].GetLinckedCell().GetComponent<Image>().sprite == null)
					continue;
				dangerCells.AddRange(currentGameField[i, j].CurrentFigure.TraceMove(this));
			}
		}
		return dangerCells;
	}

	public List<Cell> GetDangerCellToKing(Figure.Side kingSide)
	{
		List<Cell> dangerCells = new List<Cell>();
		for (int i = 0; i < currentGameField.GetLength(0); i++)
		{
			for (int j = 0; j < currentGameField.GetLength(0); j++)
			{
				if (currentGameField[i, j].GetLinckedCell() == null)
					continue;
				if (currentGameField[i, j].CurrentFigure == null)
					continue;
				if (currentGameField[i, j].CurrentFigure.FigureSide == kingSide)
					continue;
				if (currentGameField[i, j].GetLinckedCell().GetComponent<Image>().sprite == null)
					continue;
				dangerCells.AddRange(currentGameField[i, j].CurrentFigure.TraceMoveToKing(this));
			}
		}
		return dangerCells;
	}

	public List<Figure> GetDangerFigureForKing(Figure.Side kingSide)
	{
		List<Figure> dangerFigure = new List<Figure>();
		for (int i = 0; i < currentGameField.GetLength(0); i++)
		{
			for (int j = 0; j < currentGameField.GetLength(0); j++)
			{
				if (currentGameField[i, j].GetLinckedCell() == null)
					continue;
				if (currentGameField[i, j].CurrentFigure == null)
					continue;
				if (currentGameField[i, j].CurrentFigure.FigureSide == kingSide)
					continue;
				if (currentGameField[i, j].GetLinckedCell().GetComponent<Image>().sprite == null)
					continue;
				if (currentGameField[i, j].CurrentFigure.TraceMove(this).Contains(GetKingCell(kingSide)))
					dangerFigure.Add(currentGameField[i, j].CurrentFigure);
			}
		}
		return dangerFigure;
	}

	public Cell GetKingCell(Figure.Side kingSide)
	{
		for (int i = 0; i < currentGameField.GetLength(0); i++)
		{
			for (int j = 0; j < currentGameField.GetLength(0); j++)
			{
				if (currentGameField[i, j].GetLinckedCell() == null)
					continue;
				if (currentGameField[i, j].CurrentFigure == null)
					continue;
				if (currentGameField[i, j].CurrentFigure.FigureSide == kingSide)
				{
					if (currentGameField[i, j].CurrentFigure.FigureType == Figure.TypesOfFigure.King)
						return currentGameField[i, j];
				}
			}
		}
		return null;
	}

	public Figure.Side ChangePlayerTurn(Figure.Side currentPlayer)
	{
		if (currentPlayer == Figure.Side.Upper)
			currentPlayer = Figure.Side.Bottom;
		else
			currentPlayer = Figure.Side.Upper;
		EnableAllCell();
		CheckShah(currentPlayer);
		CheckMat(currentPlayer);
		CheckPat(currentPlayer);
		return currentPlayer;
	}

	List<Cell> FindEnableFigure(Figure.Side currentPlayer)
	{
		List<Cell> listWithFigure = new List<Cell>();
		foreach(Cell cell in currentGameField)
		{
			if (cell.GetLinckedCell() == null)
				continue;
			if (cell.CurrentFigure == null)
				continue;
			if (cell.CurrentFigure.FigureSide != currentPlayer)
				continue;
			if (cell.CurrentFigure.FigureType == Figure.TypesOfFigure.King)
				continue;
			if (cell.GetLinckedCell().GetComponent<Image>().sprite == null)
				continue;
			if (cell.IsEnabled == false)
				continue;
			listWithFigure.Add(cell);
		}
		return listWithFigure;
	}

	void CheckShah(Figure.Side currentPlayer)
	{
		Cell kingCell = GetKingCell(currentPlayer);
		if (!GetDangerCellsForKing(currentPlayer).Contains(kingCell))
			return;
		kingCell.GetLinckedCell().GetComponent<Image>().color = Color.red;
		List<Cell> dangerCells = GetDangerCellToKing(currentPlayer);
		List<Figure> dangerFigure = GetDangerFigureForKing(currentPlayer);
		if (dangerFigure.Count > 1)
		{
			DisableAllAlly(currentPlayer);
			return;
		}
		foreach (Cell cell in currentGameField)
		{
			bool stayFigureActive = false;
			List<Cell> saveCells = new List<Cell>();
			if (cell.GetLinckedCell() == null)
				continue;
			if (cell.CurrentFigure == null)
				continue;
			if (cell.CurrentFigure.FigureSide != currentPlayer)
				continue;
			if (cell.CurrentFigure.FigureType == Figure.TypesOfFigure.King)
				continue;
			if (cell.GetLinckedCell().GetComponent<Image>().sprite == null)
				continue;

			saveCells.AddRange(cell.CurrentFigure.TraceMove(this));

			foreach (Cell cellInSaveCell in saveCells)
			{
				if (!dangerCells.Contains(cellInSaveCell))
				{
					cellInSaveCell.DisableCellEnabled();
				}
				else
				{
					if(cellInSaveCell.CurrentFigure != null)
					{
						if (dangerFigure.Contains(cellInSaveCell.CurrentFigure))
							stayFigureActive = true;
						else
							cellInSaveCell.DisableCellEnabled();
					}
					else
						stayFigureActive = true;
				}
			}
			cell.IsEnabled = stayFigureActive;
			GetKingCell(currentPlayer).IsEnabled = true;
		}
	}

	void CheckMat(Figure.Side currentPlayer)
	{
		if (FindEnableFigure(currentPlayer).Count == 0)
		{
			if(GetKingCell(currentPlayer).CurrentFigure.Move(this).Count == 0)
			{
				if(GetDangerFigureForKing(currentPlayer).Count != 0)
					Debug.Log("��� � ���");
			}
			ResetCells();
		}
	}

	void CheckPat(Figure.Side currentPlayer)
	{
		List<Figure> movebleFigure = new List<Figure>();
		foreach(Cell cell in currentGameField)
		{
			if (cell.GetLinckedCell() == null)
				continue;
			if (cell.CurrentFigure == null)
				continue;
			if (cell.CurrentFigure.FigureSide != currentPlayer)
				continue;
			if (cell.GetLinckedCell().GetComponent<Image>().sprite == null)
				continue;
			if (cell.CurrentFigure.Move(this).Count != 0)
				movebleFigure.Add(cell.CurrentFigure);
			ResetCells();
		}
		if(movebleFigure.Count == 0)
		{
			Debug.Log("���");
		}
	}

	void EnableAllCell()
	{
		foreach (Cell cell in currentGameField)
		{
			if (cell.GetLinckedCell() == null)
				continue;
			cell.IsEnabled = true;
		}
	}

	void DisableAllAlly(Figure.Side currentPlayer)
	{
		foreach (Cell cell in currentGameField)
		{
			if (cell.GetLinckedCell() == null)
				continue;
			if (cell.CurrentFigure == null)
				continue;
			if (cell.CurrentFigure.FigureSide != currentPlayer)
				continue;
			if (cell.CurrentFigure.FigureType == Figure.TypesOfFigure.King)
				continue;
			if (cell.GetLinckedCell().GetComponent<Image>().sprite == null)
				continue;
			cell.IsEnabled = false;
		}
	}
}
