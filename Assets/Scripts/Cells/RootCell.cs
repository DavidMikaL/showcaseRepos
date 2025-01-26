using UnityEngine;

public class RootCell : Cell
{
    private Cell[,] cells;//!!! remove public
    public Cell[,] Cells {get{return cells;} set{cells = value;}}
    double[] angles;

    public RootCell(double hardness, double xSize, double ySize, double maxHealth, Cell parent) : base(hardness, xSize, ySize, maxHealth, parent)
    {
        //cells = (Cell[,])inputCells.Clone();// check if this works propperly
        //angles = new double[inputCells.Length];// Initialized with zeros
    }

    public RootCell(bool random, double xSize, double ySize, Cell parent) : base(random, xSize, ySize, parent) //random constructor
    {
        //cells = (Cell[,])inputCells.Clone();// check if this works propperly
        //angles = new double[inputCells.Length];// Initialized with zeros
    }
}
