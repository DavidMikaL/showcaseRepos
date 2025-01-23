using UnityEngine;

public class MeatCell : Cell
{
    public MeatCell(double hardness, double size, double maxHealth, Cell parent) : base(hardness, size, size, maxHealth, parent)
    {
    }

    public MeatCell(bool random, double size, Cell parent) : base(random, size, size, parent)
    {
    }
}
