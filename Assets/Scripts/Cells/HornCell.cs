using UnityEngine;

public class HornCell : Cell
{
    public HornCell(double hardness, double size, double maxHealth, Cell parent) : base(hardness, size, size, maxHealth, parent)
    {
    }

    public HornCell(bool random, double size, Cell parent) : base(random, size, size, parent)
    {
    }
}
