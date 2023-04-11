using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScipt : MonoBehaviour
{
	public void GameDataButtonClick()
	{
		SceneManager.LoadScene("GameDataScene");
	}
}
