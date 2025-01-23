using System;
using Unity.VisualScripting;
using UnityEngine;

public class IntestineCell : RootCell
{

    public IntestineCell(double hardness, double xSize, double ySize, double maxHealth, Cell parent) : base(hardness, xSize, ySize, maxHealth, parent)
    {
        
    }

    //random constructor (nothing to randomize)
    public IntestineCell(bool random, double xSize, double ySize, Cell parent) : base(random, xSize, ySize, parent)
    {
    }
}
