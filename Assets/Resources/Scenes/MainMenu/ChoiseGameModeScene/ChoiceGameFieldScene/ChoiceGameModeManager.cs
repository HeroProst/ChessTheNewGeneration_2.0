using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceGameModeManager : MonoBehaviour
{
    public GameObject header;

    void Start()
    {
        switch (StaticDataContainer.currentGameMode)
        {
            case StaticDataContainer.GameMode.Ai:
                header.GetComponent<TextMeshProUGUI>().text = "Против бота";
                return;
            case StaticDataContainer.GameMode.Multiplayer:
                header.GetComponent<TextMeshProUGUI>().text = "Против игроков";
                return;
            case StaticDataContainer.GameMode.SinglePlayer:
                header.GetComponent<TextMeshProUGUI>().text = "На одном устройстве";
                return;
        }
    }

    public void GoTo8x8Builder()
    {
        StaticDataContainer.currentMap = StaticDataContainer.TypeOfMaps.Map8x8;
        SceneManager.LoadScene("InGameSetMaker8x8Scene");
    }
    public void GoTo5x5Builder()
    {
        StaticDataContainer.currentMap = StaticDataContainer.TypeOfMaps.Map5x5;
        SceneManager.LoadScene("InGameSetMaker5x5Scene");
    }
    public void GoTo10x10Builder()
    {
        StaticDataContainer.currentMap = StaticDataContainer.TypeOfMaps.Map10x10;
        SceneManager.LoadScene("InGameSetMaker10x10Scene");

    }

    public void BackButtonClick()
    {
        SceneManager.LoadScene("ChoiseGameModeScene");
    }
}
