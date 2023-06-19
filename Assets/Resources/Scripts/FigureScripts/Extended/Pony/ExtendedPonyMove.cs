using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedPonyMove : IMoveBehaiver
{
    public List<Cell> traceTypeMove(GameField gameField, Figure currentFigure)
    {
        List<Cell> pathToMove = new List<Cell>();
        if (!currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1)))
        {
            if (currentFigure.allowedCells.Count > 0)
            {
                if (currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1)))
                {
                    if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1).CurrentFigure == null)
                        pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1));
                    else
                        if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                        pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1));
                }

            }
            else
            {
                if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1).CurrentFigure == null)
                    pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1));
                else
                    if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                    pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1));
            }
        }

        //<V
        if (!currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1)))
        {
            if (currentFigure.allowedCells.Count > 0)
            {
                if (currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1)))
                {
                    if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1).CurrentFigure == null)
                        pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1));
                    else
                        if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                        pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1));
                }

            }
            else
            {
                if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1).CurrentFigure == null)
                    pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1));
                else
                    if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                    pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1));
            }
        }


        //>^
        if (!currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1)))
        {
            if (currentFigure.allowedCells.Count > 0)
            {
                if (currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1)))
                {
                    if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1).CurrentFigure == null)
                        pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1));
                    else
                        if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                        pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1));
                }

            }
            else
            {
                if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1).CurrentFigure == null)
                    pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1));
                else
                    if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                    pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1));
            }
        }


        //<^
        if (!currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1)))
        {
            if (currentFigure.allowedCells.Count > 0)
            {
                if (currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1)))
                {
                    if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1).CurrentFigure == null)
                        pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1));
                    else
                        if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                        pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1));
                }

            }
            else
            {
                if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1).CurrentFigure == null)
                    pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1));
                else
                    if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                    pathToMove.Add(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1));
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
        //>V
        if (!currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1)))
        {
            if (currentFigure.allowedCells.Count > 0)
            {
                if (currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1)))
                {
                    if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1).CurrentFigure == null)
                        gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1).AllowCellToMove(pathToMove);
                    else
                        if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                            gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1).AllowCellToMove(pathToMove);
                }

            }
            else
            {
                if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1).CurrentFigure == null)
                    gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1).AllowCellToMove(pathToMove);
                else
                    if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                        gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos + 1).AllowCellToMove(pathToMove);
            }
        }

        //<V
        if (!currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1)))
        {
            if (currentFigure.allowedCells.Count > 0)
            {
                if (currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1)))
                {
                    if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1).CurrentFigure == null)
                        gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1).AllowCellToMove(pathToMove);
                    else
                        if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                        gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1).AllowCellToMove(pathToMove);
                }

            }
            else
            {
                if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1).CurrentFigure == null)
                    gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1).AllowCellToMove(pathToMove);
                else
                    if (gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                    gameField.FindCellByCoordinates(currentFigure.YPos + 1, currentFigure.XPos - 1).AllowCellToMove(pathToMove);
            }
        }


        //>^
        if (!currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1)))
        {
            if (currentFigure.allowedCells.Count > 0)
            {
                if (currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1)))
                {
                    if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1).CurrentFigure == null)
                        gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1).AllowCellToMove(pathToMove);
                    else
                        if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                        gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1).AllowCellToMove(pathToMove);
                }

            }
            else
            {
                if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1).CurrentFigure == null)
                    gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1).AllowCellToMove(pathToMove);
                else
                    if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                    gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos + 1).AllowCellToMove(pathToMove);
            }
        }


        //<^
        if (!currentFigure.forbbidenCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1)))
        {
            if (currentFigure.allowedCells.Count > 0)
            {
                if (currentFigure.allowedCells.Contains(gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1)))
                {
                    if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1).CurrentFigure == null)
                        gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1).AllowCellToMove(pathToMove);
                    else
                        if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                        gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1).AllowCellToMove(pathToMove);
                }

            }
            else
            {
                if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1).CurrentFigure == null)
                    gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1).AllowCellToMove(pathToMove);
                else
                    if (gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1).CurrentFigure.FigureSide != currentFigure.FigureSide)
                    gameField.FindCellByCoordinates(currentFigure.YPos - 1, currentFigure.XPos - 1).AllowCellToMove(pathToMove);
            }
        }
        return pathToMove;
    }
}
