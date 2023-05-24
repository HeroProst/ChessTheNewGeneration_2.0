using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameSetMaker8x8ForBlackSceneManager : MonoBehaviour
{
    public GameObject board;
    public Figure.Side side;
    public int maxCurrancy;
    public void AcceptButton()
    {
        StaticDataContainer.SetFigureBoard(board, side);
        SceneManager.LoadScene($"{StaticDataContainer.ConvertTypeOfMapsToString(StaticDataContainer.currentMap)}_GameScreen");
    }

    public void BackButtonClick()
    {
        SceneManager.LoadScene("ChoiseGameModeScene");
    }
}
