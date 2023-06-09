using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultQueen : Figure
{
	public DefaultQueen(Side figureSide, SpriteModel figureSprite)
	{
		FigureSide = figureSide;
		FigureSprite = figureSprite;

		price = 5;

		FigureType = TypesOfFigure.Queen;
		FigureCollection = CollectionType.Default;

		moveBehaiver = new DefaultQueenMove();
	}

	public DefaultQueen()
    {
		FigureType = TypesOfFigure.Queen;
		FigureCollection = CollectionType.Default;

		moveBehaiver = new DefaultQueenMove();

		price = 5;

		figureName = "Королева";
	}
}
