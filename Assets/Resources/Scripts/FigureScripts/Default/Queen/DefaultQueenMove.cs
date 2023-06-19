using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultQueenMove : IMoveBehaiver
{
	DefaultRookMove rookMove = new DefaultRookMove();
	DefaultBishopMove bishopMove = new DefaultBishopMove();

	public List<Cell> traceTypeMove(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove;
		pathToMove =(rookMove.traceTypeMove(gameField, currentFigure));
		pathToMove.AddRange(bishopMove.traceTypeMove(gameField, currentFigure));
		return pathToMove;
	}

	public List<Cell> traceTypeMoveToKing(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove = new List<Cell>(); 
		List<Cell> pathToMoveRook;
		List<Cell> pathToMoveBishop;
		pathToMoveRook = (rookMove.traceTypeMoveToKing(gameField, currentFigure));
		pathToMoveBishop =(bishopMove.traceTypeMoveToKing(gameField, currentFigure));
		pathToMove.AddRange(pathToMoveRook);
		pathToMove.AddRange(pathToMoveBishop);
		return pathToMove;
	}

	public List<Cell> typeMove(GameField gameField, Figure currentFigure)
	{
		List<Cell> pathToMove;
		pathToMove = (rookMove.typeMove(gameField, currentFigure));
		pathToMove.AddRange(bishopMove.typeMove(gameField, currentFigure));
		return pathToMove;
	}

	public List<Cell> typeMoveToSaveKing(GameField gameField, List<Cell> dangerPath)
	{
		throw new System.NotImplementedException();
	}
}
