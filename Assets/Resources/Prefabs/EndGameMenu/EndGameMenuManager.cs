using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenuManager : MonoBehaviour
{
    public void BackButtonClick()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }

    public void RematchButtonCklick()
    {
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().name);
    }
}
