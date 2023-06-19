using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiseGameModeManager : MonoBehaviour
{
    public void OnOneDeviceButton()
    {
        StaticDataContainer.currentGameMode = StaticDataContainer.GameMode.SinglePlayer;
        SceneManager.LoadScene("ChoiceGameField");
    }
    public void VersusPlayerButton()
    {
        StaticDataContainer.currentGameMode = StaticDataContainer.GameMode.Multiplayer;
        SceneManager.LoadScene("RoomChoicerScene");
    }
    public void VersusAIButton()
    {
        StaticDataContainer.currentGameMode = StaticDataContainer.GameMode.Ai;
        SceneManager.LoadScene("MainMenu");
    }

    public void BackButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
