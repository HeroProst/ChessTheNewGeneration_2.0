using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SetFiguretFactory
{
	protected Figure.Side figureSide;
	protected Figure.SpriteModel figureSprites;
	public SetFiguretFactory(Figure.Side figureSide, Figure.SpriteModel figureSprites)
	{
		this.figureSide = figureSide;
		this.figureSprites = figureSprites;
	}

	public void SetFigureOnField(int xPos, int yPos,GameField currentGameField, Figure.TypesOfFigure typesOfFigure)
	{
		Figure createdFigure = currentGameField.GetGameField()[yPos, xPos].CurrentFigure = CreateFigure(typesOfFigure, figureSide, figureSprites);
		currentGameField.GetGameField()[yPos, xPos].SetLinckedCellSprite(ObjectSpritesChooser.GetFigureSprite(createdFigure.FigureType, createdFigure.FigureCollection, figureSprites));
	}

	protected abstract Figure CreateFigure(Figure.TypesOfFigure typesOfFigure, Figure.Side side, Figure.SpriteModel spriteModel);
}
