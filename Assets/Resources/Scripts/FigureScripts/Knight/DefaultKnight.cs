using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultKnight : Figure
{
	public DefaultKnight(Side figureSide, SpriteModel figureSprite)
	{
		FigureSide = figureSide;
		FigureSprite = figureSprite;

		FigureType = TypesOfFigure.Knight;
		FigureCollection = CollectionType.Default;

		moveBehaiver = new DefaultKnightMove();
	}
		
}
