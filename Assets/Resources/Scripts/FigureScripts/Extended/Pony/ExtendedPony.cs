using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedPony : Figure
{
    public ExtendedPony(Side figureSide, SpriteModel figureSprite)
    {
        FigureSide = figureSide;
        FigureSprite = figureSprite;

        price = 2;

        FigureType = TypesOfFigure.Knight;
        FigureCollection = CollectionType.Extended;

        moveBehaiver = new ExtendedPonyMove();
    }

    public ExtendedPony()
    {
        FigureType = TypesOfFigure.Knight;
        FigureCollection = CollectionType.Extended;

        moveBehaiver = new ExtendedPonyMove();

        price = 2;

        figureName = "Пони";
    }
}
