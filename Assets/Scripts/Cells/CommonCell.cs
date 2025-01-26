using UnityEngine;

public class CommonCell : Cell
{
    public CommonCell(double hardness, double size, double maxHealth, Cell parent) : base(hardness, size, size, maxHealth, parent)
    {
    }

    public CommonCell(bool random, double size, Cell parent) : base(random, size, size, parent)
    {
    }
}
