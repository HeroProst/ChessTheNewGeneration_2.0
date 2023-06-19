using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{
    public GameObject hintToggle;

    private void Start()
    {
        hintToggle.GetComponent<Toggle>().isOn = StaticDataContainer.HintEnabled;
    }

    public void UnPauseButtonClick() => this.gameObject.SetActive(false);

    public void CallGameMenu() => gameObject.SetActive(true);

    public void BackButtonClick()
    {
        PhotonNetwork.Disconnect();
        if (SceneManager.GetActiveScene().name.Split("_").Length > 1)
        {
            if (SceneManager.GetActiveScene().name.Split("_")[1] == "GameScreen")
            {
                BinaryFormatter bf = new BinaryFormatter();

                FileStream file = File.Open(Application.persistentDataPath + $"/UserName.dat", FileMode.Open);

                UserDataAndSettings userData = (UserDataAndSettings)bf.Deserialize(file);

                file.Close();

                userData.countOfGames++;
                userData.countOfLose++;

                file = File.Create(Application.persistentDataPath + $"/UserName.dat");

                bf.Serialize(file, userData);

                file.Close();
            }
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void HintEnabledChange()
    {
        StaticDataContainer.HintEnabled = hintToggle.GetComponent<Toggle>().isOn;
    }
}
