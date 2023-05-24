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
		var sprite = Resources.Load<Sprite>($"Sprites/FigureSets/{Figure.GetStringNameOfCollection(collectionType)}/{Figure.GetStringNameOfFigure(typesOfFigure)}/{Figure.GetStringNameOfCollection(collectionType)}{spriteVersionString}{Figure.GetStringNameOfFigure(typesOfFigure)}");
		return sprite;
	}
}
