using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingSceneManager : MonoBehaviour
{
    public GameObject registrationMenu;
    public GameObject BoardMarkingToggle;

    private void Start()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(Application.persistentDataPath + $"/UserName.dat", FileMode.Open);

        UserDataAndSettings userData = (UserDataAndSettings)bf.Deserialize(file);

        file.Close();

        BoardMarkingToggle.GetComponent<Toggle>().isOn = userData.EnableBoardMarking;
    }

    public void ChangeNickNameButtonClick()
    {
        CallRegistrationMenu();
    }

    void CallRegistrationMenu()
    {
        Instantiate(registrationMenu, this.gameObject.transform);
    }

    public void onToggleValueChange()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(Application.persistentDataPath + $"/UserName.dat", FileMode.Open);

        UserDataAndSettings userData = (UserDataAndSettings)bf.Deserialize(file);

        file.Close();

        userData.EnableBoardMarking = BoardMarkingToggle.GetComponent<Toggle>().isOn;

        file = File.Create(Application.persistentDataPath + $"/UserName.dat");

        bf.Serialize(file, userData);

        file.Close();
    }

    public void BackButtonClick() => SceneManager.LoadScene("MainMenu");
}
