using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHistoryPreviewScript : MonoBehaviour
{
    public GameHistory linkedGameHistory;

    public void OpenGameButtonClick()
    {
        StaticDataContainer.choisenGameHistory = linkedGameHistory;
        SceneManager.LoadScene("HistoryReviewScene");
    }
}
