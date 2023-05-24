using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetsSaver : MonoBehaviour
{
    public GameObject board;
    public GameObject CurrentCurrency;
    public StaticDataContainer.TypeOfMaps currentMap;
    public Figure.Side side;
    int offset = 0;


    private void Start()
    {
        if (this.side == Figure.Side.Bottom)
            offset = 0;
        else
            offset = -1;
    }

    public void SaveSetInBundle(int bundleNumber)
    {
        SetSave8x8 setSave = new SetSave8x8(board, side);

        setSave.currentSetPrice = int.Parse(CurrentCurrency.GetComponent<TMP_Text>().text);

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + $"/SaveSet{StaticDataContainer.ConvertTypeOfMapsToString(currentMap)}_bundle_{bundleNumber}.dat");

        bf.Serialize(file, setSave);

        file.Close();

        Debug.Log($"Game data saved in bundle {bundleNumber}");

        board.transform.parent.parent.GetComponent<SaveMenuManager>().CloseSaveMenu();
    }

    public void LoadSetFromBundle(int bundleNumber)
    {
      
        if (File.Exists(Application.persistentDataPath + $"/SaveSet{StaticDataContainer.ConvertTypeOfMapsToString(currentMap)}_bundle_{bundleNumber}.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + $"/SaveSet{StaticDataContainer.ConvertTypeOfMapsToString(currentMap)}_bundle_{bundleNumber}.dat", FileMode.Open);

            SetSave8x8 setSave = (SetSave8x8) bf.Deserialize(file);

            file.Close();

            string[,] savedBoard = setSave.savedBoard;

            setSave.LoadGameBoard(board, savedBoard, side);

            CurrentCurrency.GetComponent<TMP_Text>().text = setSave.currentSetPrice.ToString();

            Debug.Log($"Game data load from bundle {bundleNumber}");
        }
        else
            Debug.LogError("There is no save data!");
    }

    public int CountBoardPrice(GameObject board)
    {
        Transform[] rowsInGameBoarder = new Transform[board.transform.childCount];

        int totalPrice = 0;

        for (int i = 0; i < board.transform.childCount; i++)
        {
            rowsInGameBoarder[i] = board.transform.GetChild(i);
        }

        for (int i = 0; i < rowsInGameBoarder.Length;i++)
        {
            for(int j = 0;j < rowsInGameBoarder[i].childCount;j++)
            {
                GameObject cell = rowsInGameBoarder[i].GetChild(j).gameObject;
                if (cell.GetComponent<BoardCellContainer>() == null)
                    continue;
                totalPrice += cell.GetComponent<BoardCellContainer>().price;
            }
        }

        return totalPrice;
    }

    public void ClearBoard()
    {
        Transform[] rowsInGameBoarder = new Transform[board.transform.childCount];
        for (int i = 0; i < board.transform.childCount; i++)
        {
            rowsInGameBoarder[i] = board.transform.GetChild(i);
        }

        for (int i = 1 + offset; i < rowsInGameBoarder.Length + offset; i++)
        {
            for (int j = 0; j < rowsInGameBoarder[i].childCount; j++)
            {
                rowsInGameBoarder[i].GetChild(j).gameObject.GetComponent<Image>().sprite = null;
                Color cellColor = rowsInGameBoarder[i].GetChild(j).gameObject.GetComponent<Image>().color;
                cellColor.a = 0;
                rowsInGameBoarder[i].GetChild(j).gameObject.GetComponent<Image>().color = cellColor;
                rowsInGameBoarder[i].GetChild(j).gameObject.GetComponent<BoardCellContainer>().figureCollection = Figure.CollectionType.None;
                rowsInGameBoarder[i].GetChild(j).gameObject.GetComponent<BoardCellContainer>().figureType = Figure.TypesOfFigure.None;
            }
        }
    }
}
