using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostConnectionMenuManager : MonoBehaviour
{
    public void BackButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
