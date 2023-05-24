using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetterFigureOnCell : MonoBehaviour
{
    [SerializeField] GameObject currantCurancy;
    [SerializeField] GameObject maxCurancy;
    [SerializeField] GameObject menuCanvas;

    void Start()
    {
        if(menuCanvas.GetComponent<InGameSetMaker8x8SceneManager>() != null)
            SetMaxCurancy(menuCanvas.GetComponent<InGameSetMaker8x8SceneManager>().maxCurrancy);
        else
            SetMaxCurancy(menuCanvas.GetComponent<InGameSetMaker8x8ForBlackSceneManager>().maxCurrancy);
    }

    public void ManipulateFigureInCell()
    {
        GameObject pressedBoardCell = EventSystem.current.currentSelectedGameObject;
        if (pressedBoardCell.GetComponent<Image>().sprite != null)
        {
            RemoveFigureFromCell(pressedBoardCell);
        }
        else
        {
            SetFigureOnCell(pressedBoardCell);
        }
    }

    public void SetFigureOnCell(GameObject pressedBoardCell)
    {
        Figure figure = pressedBoardCell.transform.parent.parent.parent.parent.GetComponent<ScrollViewGenerator>().figureSetter.selectedFigure;
        if (figure == null)
            return;
        if (!CheckCurrency(figure.price))
            return;
        Color cellColor = pressedBoardCell.GetComponent<Image>().color;
        cellColor.a = 1;
        pressedBoardCell.GetComponent<Image>().sprite = ObjectSpritesChooser.GetFigureSprite(figure.FigureType, figure.FigureCollection, this.transform.parent.parent.GetComponent<ScrollViewGenerator>().spriteModel);
        pressedBoardCell.GetComponent<Image>().color = cellColor;
        pressedBoardCell.GetComponent<BoardCellContainer>().figureCollection = figure.FigureCollection;
        pressedBoardCell.GetComponent<BoardCellContainer>().figureType = figure.FigureType;
        pressedBoardCell.GetComponent<BoardCellContainer>().price = figure.price;
        SetCurrantCurancy(figure.price);
        
    }

    public void RemoveFigureFromCell(GameObject pressedBoardCell)
    {
        Color cellColor = pressedBoardCell.GetComponent<Image>().color;
        cellColor.a = 0;
        pressedBoardCell.GetComponent<Image>().color = cellColor;
        pressedBoardCell.GetComponent<Image>().sprite = null;
        pressedBoardCell.GetComponent<BoardCellContainer>().figureCollection = Figure.CollectionType.None;
        pressedBoardCell.GetComponent<BoardCellContainer>().figureType = Figure.TypesOfFigure.None;
        SetCurrantCurancy(pressedBoardCell.GetComponent<BoardCellContainer>().price * -1);
        pressedBoardCell.GetComponent<BoardCellContainer>().price = 0;
    }

    void SetCurrantCurancy(int num)
    {
        currantCurancy.GetComponent<TMP_Text>().text = (int.Parse(currantCurancy.GetComponent<TMP_Text>().text) + num).ToString();
    }

    void SetMaxCurancy(int num)
    {
        maxCurancy.GetComponent<TMP_Text>().text = "из " + num.ToString();
    }

    bool CheckCurrency(int figurePrice)
    {
        int maxCurrancy = int.Parse(maxCurancy.GetComponent<TMP_Text>().text.Split(" ")[1]); ;
        if (int.Parse(currantCurancy.GetComponent<TMP_Text>().text) + figurePrice >= maxCurrancy)
            return false;
        else
            return true;
    }
}
