using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetsMenuSceneManager : MonoBehaviour
{
    public void GoTo8x8SetCreater()
    {
        SceneManager.LoadScene("8x8GameFieldSetCreateScene");
    }

    public void GoTo5x5SetCreater()
    {
        SceneManager.LoadScene("5x5GameFieldSetCreateScene");
    }

    public void GoTo10x10SetCreater()
    {
        SceneManager.LoadScene("10x10GameFieldSetCreateScene");
    }

    public void GoBackToGameDataScene()
    {
        SceneManager.LoadScene("GameDataScene");
    }

    public void GoBackToSetsMenuScene()
    {
        SceneManager.LoadScene("SetsMenuScene");
    }
}
