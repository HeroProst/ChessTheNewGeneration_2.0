using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MatrixAction
{
    public static string[,] ReverseMatrix(string[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);
        string[,] result = new string[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[rows - i - 1, columns - j - 1] = array[i, j];
            }
        }
        return result;
    }
}
