using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScipt : MonoBehaviour
{
	public GameObject registrationMenu;

    private void Start()
    {
        LoadUserData();
        CheckGameHistoryDirectory();
    }

    public void GameDataButtonClick()
	{
		SceneManager.LoadScene("GameDataScene");
	}

    public void SettingButtonClick() => SceneManager.LoadScene("SettingScene");

    public void PlayButton()
    {
        StaticDataContainer.YourFigureBoard = null;
        StaticDataContainer.EnemyFigureBoard = null;
        SceneManager.LoadScene("ChoiseGameModeScene");
	}

	void CallRegistrationMenu()
    {
        Instantiate(registrationMenu, this.gameObject.transform);
    }

    public void LoadUserData()
    {
        //File.Delete(Application.persistentDataPath + $"/UserName.dat");
        if (File.Exists(Application.persistentDataPath + $"/UserName.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + $"/UserName.dat", FileMode.Open);

            UserDataAndSettings userData = (UserDataAndSettings)bf.Deserialize(file);

            file.Close();

            StaticDataContainer.UserName = userData.GetUserName();

            Debug.Log($"Game data load");
        }
        else
        {            
            CallRegistrationMenu();
        }
    }

    public void CheckGameHistoryDirectory()
    {
        if(!Directory.Exists(Application.persistentDataPath + @"/GameHistory"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + @"/GameHistory");
        }
    }
}
