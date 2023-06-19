using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultKing : Figure
{
	public DefaultKing(Side figureSide, SpriteModel figureSprite)
	{
		FigureSide = figureSide;
		FigureSprite = figureSprite;

		FigureType = TypesOfFigure.King;
		FigureCollection = CollectionType.Default;

		moveBehaiver = new DefaultKingMove();
	}
}
