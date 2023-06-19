using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHistorySceneManager : MonoBehaviour
{
    [SerializeField] GameObject gameHistoryPrefab;
    [SerializeField] GameObject scrollViewContent;
    // Start is called before the first frame update
    void Start()
    {
        var gameHistoryFiles = Directory.GetFiles(Application.persistentDataPath + @"/GameHistory");
        scrollViewContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 150 * gameHistoryFiles.Length);
        for (int i = 0; i < gameHistoryFiles.Length; i++)
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(gameHistoryFiles[i], FileMode.Open);

            GameHistory game = (GameHistory)bf.Deserialize(file);

            file.Close();

            GameObject gameHistoryObject = Instantiate(gameHistoryPrefab, scrollViewContent.transform);

            gameHistoryObject.transform.localPosition = new Vector3(400, -(80 + (150 * i)));

            GameObject gameHistoryObjectPanel = gameHistoryObject.transform.Find("Panel").gameObject;

            GameObject gameHistoryObjectDate = gameHistoryObjectPanel.transform.Find("DateOfGame").gameObject;
            GameObject gameHistoryObjectMapType = gameHistoryObjectPanel.transform.Find("MapType").gameObject;

            gameHistoryObjectDate.GetComponent<TMP_Text>().text = "Игра № " + game.GameNumber.ToString();
            gameHistoryObjectMapType.GetComponent<TMP_Text>().text = StaticDataContainer.ConvertTypeOfMapsToString(game.typeOfMap);

            gameHistoryObject.GetComponent<GameHistoryPreviewScript>().linkedGameHistory = game;
        }
    }

    public void BackButtonClick()
    {
        SceneManager.LoadScene("GameDataScene");
    }
}
