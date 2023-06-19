using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FigureSceneInfoManager : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject ScrollView;
    public GameObject DescriptionText;
    Figure.TypesOfFigure selectedFigureType = Figure.TypesOfFigure.None;
    GameObject createdField;

    public void GoBackButton()
    {
        SceneManager.LoadScene("GameDataScene");
    }

    void Update()
    {
        CreateFigureInfoGameField();
    }

    public void CreateFigureInfoGameField()
    {
        Figure figure = ScrollView.GetComponent<ScrollViewGenerator>().figureSetter.selectedFigure;
        if (figure == null)
            return;

        selectedFigureType = figure.FigureType;
        if (createdField != null)
            Destroy(createdField);
        var prefab = Resources.Load($"Scenes/MainMenu/GameDataScene/FigureInfoScene/FigureInfoGameFields/{Figure.GetStringNameOfCollection(figure.FigureCollection)}{Figure.GetStringNameOfFigure(figure.FigureType)}GameField");
        createdField = Instantiate(prefab,MainCanvas.transform) as GameObject;

        var figureDescriptionFile = Resources.Load($"Scenes/MainMenu/GameDataScene/FigureInfoScene/FigureInfoDescription/{Figure.GetStringNameOfCollection(figure.FigureCollection)}{Figure.GetStringNameOfFigure(figure.FigureType)}Description") as TextAsset;
        DescriptionText.GetComponent<TMP_Text>().text = figureDescriptionFile.text;

    }
}
