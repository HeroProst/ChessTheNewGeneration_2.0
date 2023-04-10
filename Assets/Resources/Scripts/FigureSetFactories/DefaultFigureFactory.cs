using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultFigureFactory : SetFigureFactory
{
	public DefaultFigureFactory(Figure.Side figureSide, Figure.SpriteModel figureSprites) : base(figureSide, figureSprites)
	{
		this.figureSide = figureSide;
		this.figureSprites = figureSprites;
	}

	protected override Figure CreateFigure(Figure.TypesOfFigure typesOfFigure, Figure.Side side, Figure.SpriteModel spriteModel)
	{
		switch(typesOfFigure)
		{
			case Figure.TypesOfFigure.Pawn:
				return new DefaultPawns(side, spriteModel);
			case Figure.TypesOfFigure.Rook:
				return new DefaultRook(side, spriteModel);
			case Figure.TypesOfFigure.Bishop:
				return new DefaultBishop(side, spriteModel);
			case Figure.TypesOfFigure.Queen:
				return new DefaultQueen(side, spriteModel);
			case Figure.TypesOfFigure.King:
				return new DefaultKing(side, spriteModel);
			case Figure.TypesOfFigure.Knight:
				return new DefaultKnight(side, spriteModel);
		}
		return null;
	}
}
