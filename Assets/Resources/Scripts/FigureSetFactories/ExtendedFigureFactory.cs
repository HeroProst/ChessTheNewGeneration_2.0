using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedFigureFactory : ISetFactory
{
    public Figure CreateFigure(Figure.TypesOfFigure typesOfFigure, Figure.Side side, Figure.SpriteModel spriteModel)
    {
        Figure createdFigure;
        switch (typesOfFigure)
        {
            case Figure.TypesOfFigure.Knight:
                createdFigure = new ExtendedPony(side, spriteModel);
                break;
            default:
                createdFigure = new ExtendedPony(side, spriteModel);
                break;
        }
        return createdFigure;
    }
}