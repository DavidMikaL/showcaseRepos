using UnityEngine;

public class MouthCell : Cell
{
    // use as weapon?

    public MouthCell(double hardness, double size, double maxHealth, Cell parent) : base(hardness, size, size, maxHealth, CellType.Mouth, parent)
    {
    }

    public MouthCell(bool random, double size, Cell parent) : base(random, size, size, CellType.Mouth, parent)
    {
    }
}
