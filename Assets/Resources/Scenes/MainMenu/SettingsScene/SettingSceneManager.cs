using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingSceneManager : MonoBehaviour
{
    public GameObject registrationMenu;
    public void ChangeNickNameButtonClick()
    {
        CallRegistrationMenu();
    }

    void CallRegistrationMenu()
    {
        Instantiate(registrationMenu, this.gameObject.transform);
    }

    public void BackButtonClick() => SceneManager.LoadScene("MainMenu");
}
