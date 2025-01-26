using System;
using Unity.VisualScripting;
using UnityEngine;

public class CoreCell : RootCell
{

    public CoreCell(double hardness, double xSize, double ySize, double maxHealth, Cell parent) : base(hardness, xSize, ySize, maxHealth, CellType.Core, parent)
    {
        
    }

    //random constructor (nothing to randomize)
    public CoreCell(bool random, double xSize, double ySize, Cell parent) : base(random, xSize, ySize, CellType.Core, parent)
    {
    }
}
