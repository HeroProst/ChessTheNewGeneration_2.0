using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBishop : Figure
{
	public DefaultBishop(Side figureSide, SpriteModel figureSprite)
	{
		FigureSide = figureSide;
		FigureSprite = figureSprite;

		price = 4;

		FigureType = TypesOfFigure.Bishop;
		FigureCollection = CollectionType.Default;

		moveBehaiver = new DefaultBishopMove();
	}

	public DefaultBishop()
    {
		FigureType = TypesOfFigure.Bishop;
		FigureCollection = CollectionType.Default;

		moveBehaiver = new DefaultBishopMove();

		price = 4;

		figureName = "Слон";
	}
}
