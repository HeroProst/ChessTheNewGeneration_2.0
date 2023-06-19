using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISetFactory
{
    public void SetFigureOnField(int xPos, int yPos, GameField currentGameField, Figure.TypesOfFigure typesOfFigure, Figure.Side figureSide, Figure.SpriteModel figureSprites)
    {
        Figure createdFigure = currentGameField.GetGameField()[yPos, xPos].CurrentFigure = CreateFigure(typesOfFigure, figureSide, figureSprites);
        currentGameField.GetGameField()[yPos, xPos].SetLinckedCellSprite(ObjectSpritesChooser.GetFigureSprite(createdFigure.FigureType, createdFigure.FigureCollection, figureSprites));
    }

    public static ISetFactory CreateSetFactory(Figure.CollectionType collectionType)
    {
        ISetFactory returningFactory;
        switch(collectionType)
        {
            case Figure.CollectionType.Default:
                returningFactory = new DefaultFigureFactory();
                break;
            case Figure.CollectionType.Extended:
                returningFactory = new ExtendedFigureFactory();
                break;
            default:
                returningFactory = new DefaultFigureFactory();
                break;
        }
        return returningFactory;
    }

    Figure CreateFigure(Figure.TypesOfFigure typesOfFigure, Figure.Side side, Figure.SpriteModel spriteModel);
}
