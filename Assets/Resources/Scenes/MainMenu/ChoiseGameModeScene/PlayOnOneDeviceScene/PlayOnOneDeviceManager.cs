using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayOnOneDeviceManager : MonoBehaviour
{
    public void GoTo8x8GameField()
    {
        StaticDataContainer.currentMap = StaticDataContainer.TypeOfMaps.Map8x8;
        SceneManager.LoadScene("InGameSetMaker8x8Scene");
    }

    public void GoTo5x5GameField()
    {
        StaticDataContainer.currentMap = StaticDataContainer.TypeOfMaps.Map5x5;
        SceneManager.LoadScene("InGameSetMaker5x5Scene");
    }

    public void GoTo10x10GameField()
    {
        StaticDataContainer.currentMap = StaticDataContainer.TypeOfMaps.Map10x10;
        SceneManager.LoadScene("InGameSetMaker10x10Scene");
    }
}
