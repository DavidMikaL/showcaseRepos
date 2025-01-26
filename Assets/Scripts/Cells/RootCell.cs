using UnityEngine;

public class RootCell : Cell
{
    private Cell[,] cells;//!!! remove public
    public Cell[,] Cells {get{return cells;} set{cells = value;}}
    double[] angles;

    public RootCell(double hardness, double xSize, double ySize, double maxHealth, CellType cellType, Cell parent) : base(hardness, xSize, ySize, maxHealth, cellType, parent)
    {
        //cells = (Cell[,])inputCells.Clone();// check if this works propperly
        //angles = new double[inputCells.Length];// Initialized with zeros
    }

    public RootCell(bool random, double xSize, double ySize, CellType cellType, Cell parent) : base(random, xSize, ySize, cellType, parent) //random constructor
    {
        //cells = (Cell[,])inputCells.Clone();// check if this works propperly
        //angles = new double[inputCells.Length];// Initialized with zeros
    }
}
