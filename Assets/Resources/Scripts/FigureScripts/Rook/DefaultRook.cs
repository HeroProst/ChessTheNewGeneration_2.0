using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultRook : Figure
{
	public DefaultRook(Side figureSide, SpriteModel figureSprite)
	{
		FigureSide = figureSide;
		FigureSprite = figureSprite;

		FigureType = TypesOfFigure.Rook;
		FigureCollection = CollectionType.Default;

		moveBehaiver = new DefaultRookMove();
	}
	
	public DefaultRook()
    {
		FigureType = TypesOfFigure.Rook;
		FigureCollection = CollectionType.Default;

		moveBehaiver = new DefaultRookMove();

		price = 1;

		figureName = "Ладья";
	}
}

