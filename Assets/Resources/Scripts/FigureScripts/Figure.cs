using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Figure
{
	public IMoveBehaiver moveBehaiver;

	protected List<Cell> cellsWithClone = new List<Cell>();

	private int xPos;
	private int yPos;

	public int moveCount = 0;

	private Side figureSide;

	private SpriteModel figureSprite;

	public int XPos { get; set; }
	public int YPos { get; set; }

	public Side FigureSide
	{
		get;
		set;
	}

	public SpriteModel FigureSprite
	{
		get;
		set;
	}
	public TypesOfFigure FigureType
	{
		get;
		set;
	}

	public CollectionType FigureCollection
	{
		get;
		set;
	}

	public int price
	{
		get;
	}
	public enum Side
	{
		Bottom,
		Upper
	}

	public enum SpriteModel
	{
		Origin,
		Alternative
	}

	public enum TypesOfFigure
	{
		Pawn,
		Rook,
		Bishop,
		Knight,
		Queen,
		King
	}

	public enum CollectionType
	{
		Default
	}

	public void DeleteAllClones()
	{
		foreach (Cell c in cellsWithClone)
			c.CurrentFigure = null;
	}

	public void DeleteAllCloneExeptSelf()
	{
		if (cellsWithClone.Count < 2)
			return;
		for(int i = 1;i < cellsWithClone.Count;i++)
		{
			cellsWithClone[i].CurrentFigure = null;
			cellsWithClone.Remove(cellsWithClone[i]);
		}
		cellsWithClone.Clear();
	}

	public List<Cell> Move(GameField gameField)
	{
		return moveBehaiver.typeMove(gameField, this);
	}

	public List<Cell> TraceMove(GameField gameField)
	{
		return moveBehaiver.traceTypeMove(gameField, this);
	}

	public List<Cell> TraceMoveToKing(GameField gameField)
	{
		return moveBehaiver.traceTypeMoveToKing(gameField, this);
	}

	public virtual void MoveFigure(Cell cellToMoveFigure, Cell thisFromMoveCell, GameField currentGameField)
	{
		cellToMoveFigure.CurrentFigure = thisFromMoveCell.CurrentFigure;
		cellToMoveFigure.GetLinckedCell().GetComponent<Image>().sprite = thisFromMoveCell.GetLinckedCell().GetComponent<Image>().sprite;

		Color cellColor = thisFromMoveCell.GetLinckedCell().GetComponent<Image>().color;
		cellColor.a = 0;
		thisFromMoveCell.GetLinckedCell().GetComponent<Image>().color = cellColor;

		thisFromMoveCell.CurrentFigure = null;
		thisFromMoveCell.GetLinckedCell().GetComponent<Image>().sprite = null;

		this.moveCount++;
	}

}
