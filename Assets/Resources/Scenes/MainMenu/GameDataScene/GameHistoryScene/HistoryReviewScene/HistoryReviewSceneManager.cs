using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HistoryReviewSceneManager : MonoBehaviour
{
    [SerializeField] GameObject Title;
    [SerializeField] GameObject ScrollViewContent;
    [SerializeField] GameObject GameMove;
    private void Start()
    {
        Title.GetComponent<TMP_Text>().text = "Игра " + StaticDataContainer.choisenGameHistory.GameNumber;
        int numberOfCollumsInBoard = StaticDataContainer.choisenGameHistory.primaryGameBoard.GetLength(1);
        int i = 1;
        foreach (string gameMove in StaticDataContainer.choisenGameHistory.gameMoves)
        {

            int moveFromRow = Mathf.Abs(int.Parse(gameMove[0].ToString()) - numberOfCollumsInBoard) + 1;
            char moveFromColl = (char)(int.Parse(gameMove[1].ToString()) + 'A' - 1);

            int moveToRow = Mathf.Abs(int.Parse(gameMove[3].ToString()) - numberOfCollumsInBoard) + 1;
            char moveToColl = (char)(int.Parse(gameMove[4].ToString()) + 'A' - 1);

            GameObject gameMoveObject = Instantiate(GameMove, ScrollViewContent.transform);
            gameMoveObject.transform.localPosition = new Vector3(400, -100 * i);


            GameObject gameMovePanel = gameMoveObject.transform.Find("Panel").gameObject;

            GameObject gameMoveMoveFrom = gameMovePanel.transform.Find("MoveFrom").gameObject;
            GameObject gameMoveMoveTo = gameMovePanel.transform.Find("MoveTo").gameObject; 
            GameObject gameMoveImage = gameMovePanel.transform.Find("Image").gameObject;

            gameMoveMoveFrom.GetComponent<TMP_Text>().text = moveFromColl.ToString() + moveFromRow;
            gameMoveMoveTo.GetComponent<TMP_Text>().text = moveToColl.ToString() + moveToRow;
            Debug.Log(gameMove.Split(" ")[2]);
            if (gameMove.Split(" ")[2] == "черные")
            {
                gameMoveImage.GetComponent<Image>().color = Color.white;
            }
            else
            {
                gameMoveImage.GetComponent<Image>().color = Color.black;
            }

            i++;
        }
    }
    public void BackButtonClick()
    {
        SceneManager.LoadScene("GameHistoryScene");
    }
}
