using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public void UnPauseButtonClick() => this.gameObject.SetActive(false);

    public void CallGameMenu() => gameObject.SetActive(true);

    public void BackButtonClick()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }
}
