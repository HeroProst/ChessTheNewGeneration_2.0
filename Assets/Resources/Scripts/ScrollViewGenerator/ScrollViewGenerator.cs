using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollViewGenerator : MonoBehaviour
{
    public GameObject FigurePanelPrefab;
    public GameObject ScrollViewContainer;
    public GameField.FieldType fieldType;
    int figurePanelXdelta = 220;
    int figurePanelXpos = 112;
    int figurePanelYpos = -155;
    public FigureSetter figureSetter;
    public Figure.SpriteModel spriteModel;

    public void AddFigurePanelToScrollView()
    {
        List<Figure> figures = FigureListGenerator.GenerateListOfFigure(fieldType);
        GameObject figurePanel;
        foreach (Figure figure in figures)
        {
            figurePanel = Instantiate(FigurePanelPrefab, ScrollViewContainer.transform);

            figurePanel.GetComponent<Button>().onClick.AddListener(SelectFigure);
            
            figurePanel.GetComponent<FigurePanelContainer>().linckedFigure = figure;

            figurePanel.transform.localPosition = new Vector2(figurePanelXpos, figurePanelYpos);

            figurePanelXpos += figurePanelXdelta;

            GameObject figurePanelCanvas = figurePanel.transform.Find("Canvas").gameObject;

            GameObject figurePanelImage = figurePanelCanvas.transform.Find("ImagePanel").gameObject;

            GameObject figurePanelDescription = figurePanelCanvas.transform.Find("DescriptionPanel").gameObject;

            GameObject figurePanelName = figurePanelDescription.transform.Find("FigureName").gameObject;
            GameObject figurePanelSetName = figurePanelDescription.transform.Find("FigureSetName").gameObject;
            GameObject figurePanelPrice = figurePanelDescription.transform.Find("FigurePrice").gameObject;

            figurePanelImage.GetComponent<Image>().sprite = ObjectSpritesChooser.GetFigureSprite(figure.FigureType, figure.FigureCollection, spriteModel);

            figurePanelName.GetComponent<TextMeshProUGUI>().text = figure.figureName;

            switch(figure.FigureCollection)
            {
                case Figure.CollectionType.Default:
                    figurePanelSetName.GetComponent<TextMeshProUGUI>().text = "Оригинал";
                    break;
            }

            figurePanelPrice.GetComponent<TextMeshProUGUI>().text = figure.price.ToString();
        }
    }

    public void SelectFigure()
    {
        GameObject pressedBoardCell = EventSystem.current.currentSelectedGameObject;
        figureSetter.selectedFigure = pressedBoardCell.GetComponent<FigurePanelContainer>().linckedFigure;
    }

    private void Start()
    {
        AddFigurePanelToScrollView();
        figureSetter = new FigureSetter();
    }
}
