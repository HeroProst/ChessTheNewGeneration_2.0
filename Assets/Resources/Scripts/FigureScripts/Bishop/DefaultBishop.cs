using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBishop : Figure
{
	public DefaultBishop(Side figureSide, SpriteModel figureSprite)
	{
		FigureSide = figureSide;
		FigureSprite = figureSprite;

		FigureType = TypesOfFigure.Bishop;
		FigureCollection = CollectionType.Default;

		moveBehaiver = new DefaultBishopMove();
	}
}
