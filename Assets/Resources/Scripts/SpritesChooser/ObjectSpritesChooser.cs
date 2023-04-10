using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectSpritesChooser
{
	public static Sprite GetSprite(string path)
	{
		Sprite sprite = Resources.Load<Sprite>($"{path}");
		if (sprite == null)
			return null;
		return sprite;
	}

	public static Sprite GetFigureSprite(Figure.TypesOfFigure typesOfFigure, Figure.CollectionType collectionType, Figure.SpriteModel spriteVersion)
	{
		string spriteVersionString;
		if (spriteVersion == Figure.SpriteModel.Origin)
			spriteVersionString = "Origin";
		else
			spriteVersionString = "Alternative";
		var sprite = Resources.Load<Sprite>($"Sprites/FigureSets/{ChoiceFigureSet(collectionType)}/{ChoiceFigureType(typesOfFigure)}/{ChoiceFigureSet(collectionType)}{spriteVersionString}{ChoiceFigureType(typesOfFigure)}");
		return sprite;
	}

	static string ChoiceFigureSet(Figure.CollectionType collectionType)
	{
		switch(collectionType)
		{
			case Figure.CollectionType.Default:
				return "Default";
		}
		return "Default";
	}

	static string ChoiceFigureType(Figure.TypesOfFigure typesOfFigure)
	{
		switch (typesOfFigure)
		{
			case Figure.TypesOfFigure.Pawn:
				return "Pawn";
			case Figure.TypesOfFigure.Rook:
				return "Rook";
			case Figure.TypesOfFigure.Bishop:
				return "Bishop";
			case Figure.TypesOfFigure.Queen:
				return "Queen";
			case Figure.TypesOfFigure.King:
				return "Knight";
			case Figure.TypesOfFigure.Knight:
				return "Knight";
		}
		return "Pawn";
	}
}
