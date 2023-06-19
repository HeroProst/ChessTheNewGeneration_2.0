using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataScript : MonoBehaviour
{
	public GameObject countOfLose;
	public GameObject countOfWins;
	public GameObject countOfGames;
	public GameObject countOfPatsAndDraw;

    private void Start()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(Application.persistentDataPath + $"/UserName.dat", FileMode.Open);

        UserDataAndSettings userData = (UserDataAndSettings)bf.Deserialize(file);

        file.Close();

        countOfGames.GetComponent<TMP_Text>().text = userData.countOfGames.ToString();
        countOfLose.GetComponent<TMP_Text>().text = userData.countOfLose.ToString();
        countOfWins.GetComponent<TMP_Text>().text = userData.countOfWins.ToString();
        countOfPatsAndDraw.GetComponent<TMP_Text>().text = userData.countOfPatAndDraw.ToString();
    }

    public void BackButtonClick()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void GoToSetsBuilderScene()
    {
		SceneManager.LoadScene("SetsMenuScene");
	}

    public void GoToGameHistoryScene()
    {
        SceneManager.LoadScene("GameHistoryScene");
    }

	public void GoToFigureInfoScene()
    {
		SceneManager.LoadScene("FigureInfoScene");
    }
}
