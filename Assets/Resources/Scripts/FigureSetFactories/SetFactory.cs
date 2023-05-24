using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SetFactory
{
    public void SetFigureOnField(int xPos, int yPos, GameField currentGameField, Figure.TypesOfFigure typesOfFigure, Figure.Side figureSide, Figure.SpriteModel figureSprites)
    {
        Figure createdFigure = currentGameField.GetGameField()[yPos, xPos].CurrentFigure = CreateFigure(typesOfFigure, figureSide, figureSprites);
        currentGameField.GetGameField()[yPos, xPos].SetLinckedCellSprite(ObjectSpritesChooser.GetFigureSprite(createdFigure.FigureType, createdFigure.FigureCollection, figureSprites));
    }

    public static SetFactory CreateSetFactory(Figure.CollectionType collectionType)
    {
        SetFactory returningFactory;
        switch(collectionType)
        {
            case Figure.CollectionType.Default:
                returningFactory = new DefaultFigureFactory();
                break;
            default:
                returningFactory = new DefaultFigureFactory();
                break;
        }
        return returningFactory;
    }

    Figure CreateFigure(Figure.TypesOfFigure typesOfFigure, Figure.Side side, Figure.SpriteModel spriteModel);
}
