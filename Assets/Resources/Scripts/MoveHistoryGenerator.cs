using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveHistoryGenerator : MonoBehaviour
{
    public GameObject moveHisoryObject;
    public GameObject moveHistoryParent;
    public int NumberOfCollumsInBoard;
    const int FIGURE_PANEL_START_X_POS = -500;
    const int MAX_HISTORY_OBJECT = 6;
    const int FIGURE_PANEL_Y_POS = -12;
    int figurePanelXdelta = 200;
    int figurePanelXpos = FIGURE_PANEL_START_X_POS;
    GameObject[] listOfMoveHistoryObject = new GameObject[MAX_HISTORY_OBJECT];
    int i = 0;
    int countOfHisoryObjects = 1;

    public void GenerateNewMoveHistoryObject(string moveFrom, string moveTo)
    {
        int moveFromRow = Mathf.Abs(int.Parse(moveFrom[0].ToString()) - NumberOfCollumsInBoard) + 1;
        char moveFromColl = (char) (int.Parse(moveFrom.ToCharArray()[1].ToString()) + 'A' - 1); 

        int moveToRow = Mathf.Abs(int.Parse(moveTo[0].ToString()) - NumberOfCollumsInBoard) + 1;
        char moveToColl = (char)(int.Parse(moveTo.ToCharArray()[1].ToString()) + 'A' - 1);

        if (i == MAX_HISTORY_OBJECT)
        {
            Destroy(listOfMoveHistoryObject[0]);
            for(int j = 1;j < listOfMoveHistoryObject.Length;j++)
            {
                listOfMoveHistoryObject[j].transform.localPosition = new Vector3(listOfMoveHistoryObject[j].transform.localPosition.x - figurePanelXdelta, FIGURE_PANEL_Y_POS, -20480);
                listOfMoveHistoryObject[j - 1] = listOfMoveHistoryObject[j];
            }
            i--;
            figurePanelXpos -= figurePanelXdelta;
        }
        listOfMoveHistoryObject[i] = Instantiate(moveHisoryObject, moveHistoryParent.transform);
        listOfMoveHistoryObject[i].transform.localPosition = new Vector3(figurePanelXpos, FIGURE_PANEL_Y_POS, -20480);

        GameObject objectCanvas = listOfMoveHistoryObject[i].transform.Find("Canvas").gameObject;

        GameObject moveNumberObject = objectCanvas.transform.Find("MoveNumber").gameObject;
        GameObject moveFromCellObject = objectCanvas.transform.Find("MoveFromCell").gameObject;
        GameObject moveToCellObject = objectCanvas.transform.Find("MoveToCell").gameObject;

        moveNumberObject.GetComponent<TMP_Text>().text = countOfHisoryObjects.ToString();
        moveFromCellObject.GetComponent<TMP_Text>().text = $"{moveFromColl}{moveFromRow}";
        moveToCellObject.GetComponent<TMP_Text>().text = $"{moveToColl}{moveToRow}";

        figurePanelXpos += figurePanelXdelta;
        i++;
        countOfHisoryObjects++;
    }
}
