using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveBehaiver
{
	public List<Cell> typeMove(GameField gameField, Figure currentFigure);
	public List<Cell> traceTypeMove(GameField gameField, Figure currentFigure);
	public List<Cell> traceTypeMoveToKing(GameField gameField, Figure currentFigure);
}
