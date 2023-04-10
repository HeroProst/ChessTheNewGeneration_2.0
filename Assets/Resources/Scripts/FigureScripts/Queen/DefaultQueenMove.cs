using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultQueenMove : IMoveBehaiver
{
	DefaultRookMove rookMove = new DefaultRookMove();
	DefaultBishopMove bishopMove = new DefaultBishopMove();

	public List<Cell> traceTypeMove(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove = new List<Cell>();
		pathToMove = rookMove.traceTypeMove(gameField, currentFigure);
		pathToMove.AddRange(bishopMove.traceTypeMove(gameField, currentFigure));
		return pathToMove;
	}

	public List<Cell> traceTypeMoveToKing(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove = new List<Cell>();
		pathToMove = rookMove.traceTypeMoveToKing(gameField, currentFigure);
		pathToMove.AddRange(bishopMove.traceTypeMoveToKing(gameField, currentFigure));
		return pathToMove;
	}

	public List<Cell> typeMove(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove = new List<Cell>();
		pathToMove = rookMove.typeMove(gameField, currentFigure);
		pathToMove.AddRange(bishopMove.typeMove(gameField, currentFigure));
		return pathToMove;
	}

	public List<Cell> typeMoveToSaveKing(GameField gameField, List<Cell> dangerPath)
	{
		throw new System.NotImplementedException();
	}
}
