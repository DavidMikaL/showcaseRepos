using Unity.Burst.Intrinsics;
using UnityEngine;

public class CommonCell : Cell
{
    public CommonCell(double hardness, double size, double maxHealth, RootCell parent) : base(hardness, size, size, maxHealth, CellType.Common, parent)
    {
    }

    public CommonCell(bool random, double size, RootCell parent) : base(random, size, size, CellType.Common, parent)
    {
    }
}
