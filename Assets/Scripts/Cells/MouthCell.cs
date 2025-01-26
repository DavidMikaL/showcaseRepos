using UnityEngine;

public class MouthCell : Cell
{
    // use as weapon?

    public MouthCell(double hardness, double size, double maxHealth, Cell parent) : base(hardness, size, size, maxHealth, parent)
    {
    }

    public MouthCell(bool random, double size, Cell parent) : base(random, size, size, parent)
    {
    }
}
