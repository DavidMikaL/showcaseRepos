using UnityEngine;

public class HornCell : Cell
{
    public HornCell(double hardness, double size, double maxHealth, RootCell parent) : base(hardness, size, size, maxHealth, CellType.Horn, parent)
    {
    }

    public HornCell(bool random, double size, RootCell parent) : base(random, size, size, CellType.Horn, parent)
    {
    }
}
