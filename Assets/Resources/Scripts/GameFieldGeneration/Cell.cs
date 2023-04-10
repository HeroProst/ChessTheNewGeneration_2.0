using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell
{
    bool cellEnable = true;

   public bool IsEnabled
	{
        get => cellEnable;
        set => cellEnable = value;
	}

    public void DisableCellEnabled()
	{
        cellEnable = false;
	}

    public void EnableCellEnabled()
	{
        cellEnable = true;
	}

    int xPos;
	public int XPos
    {
        get => xPos; 
        set => xPos = value; 
    }

    int yPos;
    public int YPos
    {
        get => yPos;
        set => yPos = value;
    }

    private Figure currentFigure;
    public Figure CurrentFigure 
    {
      get
      { 
            return currentFigure; 
      }

      set
      {
            if (value != null)
            {
                if(currentFigure != null)
                    currentFigure.DeleteAllClones();
                value.XPos = XPos;
                value.YPos = YPos;
                Color cellColor = GetLinckedCell().GetComponent<Image>().color;
                cellColor.a = 1;
                GetLinckedCell().GetComponent<Image>().color = cellColor;
            }
            currentFigure = value;
        }
    }

    GameObject linckedCell;

    public GameObject GetLinckedCell()
	{
        return linckedCell;
	}

    public void SetLinckedCellSprite(Sprite sprite)
	{
        Color cellColor = GetLinckedCell().GetComponent<Image>().color;
        GetLinckedCell().GetComponent<Image>().sprite = sprite;
        if (sprite != null)
            cellColor.a = 1;
        else
            cellColor.a = 0;
        GetLinckedCell().GetComponent<Image>().color = cellColor;
    }

    public Cell() { }

    public bool HasFigureInCell()
	{
        if (CurrentFigure == null)
            return false;
        else
            return true;
	}

    public Cell(int yPos, int xPos, Transform transOfLinckedCell)
    {
        XPos = xPos;
        YPos = yPos;
        linckedCell = transOfLinckedCell.gameObject;
        Color cellColor = GetLinckedCell().GetComponent<Image>().color;
        cellColor.a = 0;
        linckedCell.GetComponent<Image>().color = cellColor;
        linckedCell.GetComponent<Image>().sprite = null;
    }

    public void AllowCellToMove(List<Cell> cellsToMove)
	{
        if (this.IsEnabled == false)
            return;
        AllowCellToMoveAnyway(cellsToMove);
    }

    public void AllowCellToMoveAnyway(List<Cell> cellsToMove)
    {
        if (this.GetLinckedCell() == null)
            return;
        if (!this.HasFigureInCell())
            this.SetLinckedCellSprite(ObjectSpritesChooser.GetSprite("Sprites/Other/GreenDot"));
        else
            this.GetLinckedCell().GetComponent<Image>().color = Color.green;
        cellsToMove.Add(this);
    }

    public void SwapFigure(Cell cellToSwapFigure)
	{
        Figure rookCell = this.CurrentFigure;
        Sprite cellSprite = this.GetLinckedCell().GetComponent<Image>().sprite;
        this.CurrentFigure = cellToSwapFigure.CurrentFigure;
        this.GetLinckedCell().GetComponent<Image>().sprite = cellToSwapFigure.GetLinckedCell().GetComponent<Image>().sprite;

        cellToSwapFigure.CurrentFigure = rookCell;
        cellToSwapFigure.GetLinckedCell().GetComponent<Image>().sprite = cellSprite;
    }
}
