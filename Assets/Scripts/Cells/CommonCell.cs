using Unity.Burst.Intrinsics;
using UnityEngine;

public class CommonCell : Cell
{
    public CommonCell(double hardness, double size, double maxHealth, RootCell parent) : base(hardness, size, size, maxHealth, CellType.Common, parent)
    {
    }

    /**
        random/null constructor 
    */
    public CommonCell(bool random, double size, RootCell parent) : base(random, size, size, CellType.Common, parent)
    {
    }

    public override Cell evolvedCell(RootCell parent)
    {
        return new CommonCell(BeetleInfo.randomize(Hardness, 5),
                              BeetleInfo.randomize(XSize,3),
                              BeetleInfo.randomize(MaxHealth, 5),
                              parent);
    }
}
