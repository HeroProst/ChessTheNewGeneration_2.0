using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour
{
    [SerializeField] GameObject currentGameBorder;
    GameField currentGameField;
    Figure.Side currentPlayer = Figure.Side.Bottom;

    void Start()
    {
        currentGameField = new GameField(currentGameBorder);
        OnlyForTest();
    }

    void OnlyForTest()
    {
        SetFigureFactory defaultSetBottom = new DefaultFigureFactory(Figure.Side.Upper, Figure.SpriteModel.Alternative);
        defaultSetBottom.SetFigureOnField(8, 8, currentGameField, Figure.TypesOfFigure.King);
        defaultSetBottom.SetFigureOnField(1, 8, currentGameField, Figure.TypesOfFigure.Rook);

        SetFigureFactory defaultSeUpper = new DefaultFigureFactory(Figure.Side.Bottom, Figure.SpriteModel.Origin);
        defaultSeUpper.SetFigureOnField(8, 2, currentGameField, Figure.TypesOfFigure.Rook);
        defaultSeUpper.SetFigureOnField(4,5,currentGameField,Figure.TypesOfFigure.Rook);
        defaultSeUpper.SetFigureOnField(6, 2, currentGameField, Figure.TypesOfFigure.Rook);
    }

    public void onClick()
    {
        currentPlayer = currentGameField.ClickActionSelecter(currentPlayer);
    }
}
