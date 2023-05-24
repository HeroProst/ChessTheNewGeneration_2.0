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
		set;
	}

	public string figureName;

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
		King,
		None
	}

	public enum CollectionType
	{
		Default,
		None
	}

	public static Figure.CollectionType GetCollectionTypeByName(string name)
    {
		switch (name)
		{
			case "Default":
				return Figure.CollectionType.Default; 
			case "None":
				return Figure.CollectionType.None;
		}
		return Figure.CollectionType.None;
	}

	public static string GetStringNameOfCollection(Figure.CollectionType collectionType)
	{
		switch (collectionType)
		{
			case Figure.CollectionType.Default:
				return "Default";
			case Figure.CollectionType.None:
				return "None";
		}
		return "None";
	}

	public static string GetStringNameOfFigure(Figure.TypesOfFigure typesOfFigure)
	{
		switch (typesOfFigure)
		{
			case Figure.TypesOfFigure.Pawn:
				return "Pawn";
			case Figure.TypesOfFigure.Rook:
				return "Rook";
			case Figure.TypesOfFigure.Bishop:
				return "Bishop";
			case Figure.TypesOfFigure.Queen:
				return "Queen";
			case Figure.TypesOfFigure.King:
				return "King";
			case Figure.TypesOfFigure.Knight:
				return "Knight";
			case Figure.TypesOfFigure.None:
				return "None";
		}
		return "None";
	}

	public static Figure.TypesOfFigure GetFigureTypeByName(string name)
	{
		{
			switch (name)
			{
				case "Pawn":
					return Figure.TypesOfFigure.Pawn;
				case "Rook":
					return Figure.TypesOfFigure.Rook;
				case "Bishop":
					return Figure.TypesOfFigure.Bishop;
				case "Queen":
					return Figure.TypesOfFigure.Queen;
				case "Knight":
					return Figure.TypesOfFigure.Knight;
				case "King":
					return Figure.TypesOfFigure.King;
				case "None":
					return Figure.TypesOfFigure.None;
			}
			return Figure.TypesOfFigure.None;
		}
	}

	public static Figure.Side GetFigureSideByName(string name)
    {
        switch(name)
		{
			case "Bottom":
				return Figure.Side.Bottom;
			case "Upper":
				return Figure.Side.Upper;
			default:
				return Figure.Side.Upper;
		}
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
