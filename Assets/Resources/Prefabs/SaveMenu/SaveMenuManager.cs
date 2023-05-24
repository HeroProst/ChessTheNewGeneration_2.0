using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMenuManager : MonoBehaviour
{
    public GameObject saveMenu;
    public void OpenSaveMenu()
    {
        saveMenu.SetActive(true);
    }

    public void CloseSaveMenu()
    {
        saveMenu.SetActive(false);
    }
}
