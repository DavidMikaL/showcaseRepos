using UnityEngine;

public class ExtremityRootCell : RootCell
{
    public ExtremityRootCell(double hardness, double size, double maxHealth, Cell parent) : base(hardness, size, size, maxHealth, CellType.ExtremityRoot, parent)
    {
    }

    public ExtremityRootCell(bool random, double xSize, double ySize, Cell parent) : base(random, xSize, ySize, CellType.ExtremityRoot, parent)
    {
    }
}
