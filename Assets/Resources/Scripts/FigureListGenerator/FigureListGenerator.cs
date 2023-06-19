using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FigureListGenerator
{
    public static List<Figure> GenerateListOfFigure(GameField.FieldType fieldType)
    {
        List<Figure> figures = new List<Figure>();

        DefaultPawns defaultPawns = new DefaultPawns();
        DefaultRook defaultRook = new DefaultRook();
        DefaultBishop defaultBishop = new DefaultBishop();
        DefaultQueen defaultQueen = new DefaultQueen();
        DefaultKnight defaultKnight = new DefaultKnight();

        ExtendedPony extendedPony = new ExtendedPony();

        figures.Add(defaultPawns);
        figures.Add(defaultRook);
        figures.Add(defaultBishop);
        figures.Add(defaultQueen);
        figures.Add(defaultKnight);

        figures.Add(extendedPony);


        switch (fieldType)
        {
            case GameField.FieldType.LowRange:
                figures.Remove(defaultKnight);
                break;
            case GameField.FieldType.MiddleRange:
                break;
            case GameField.FieldType.LongRange:
                break;
            case GameField.FieldType.All:
                break;
        }
        return figures;
    }
}
