using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultFigureFactory : SetFactory
{   
    public Figure CreateFigure(Figure.TypesOfFigure typesOfFigure, Figure.Side side, Figure.SpriteModel spriteModel)
    {
        Figure createdFigure;
        switch (typesOfFigure)
        {
            case Figure.TypesOfFigure.Pawn:
                createdFigure = new DefaultPawns(side,spriteModel);
                break;
            case Figure.TypesOfFigure.Rook:
                createdFigure = new DefaultRook(side, spriteModel);
                break;
            case Figure.TypesOfFigure.Knight:
                createdFigure = new DefaultKnight(side, spriteModel);
                break;
            case Figure.TypesOfFigure.Bishop:
                createdFigure = new DefaultBishop(side,spriteModel);
                break;
            case Figure.TypesOfFigure.King:
                createdFigure = new DefaultKing(side, spriteModel);
                break;
            case Figure.TypesOfFigure.Queen:
                createdFigure = new DefaultQueen(side, spriteModel);
                break;
            default:
                createdFigure = new DefaultPawns(side,spriteModel);
                break;
        }
        return createdFigure;
    }
}
