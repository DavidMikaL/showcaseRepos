using UnityEngine;

public class HornCell : Cell
{
    public HornCell(double hardness, double size, double maxHealth, RootCell parent) : base(hardness, size, size, maxHealth, CellType.Horn, parent)
    {
    }

    /**
        random/null constructor (nothing to randomize)
    */
    public HornCell(bool random, double size, RootCell parent) : base(random, size, size, CellType.Horn, parent)
    {
    }

    public override Cell evolvedCell(RootCell parent)
    {
        return new HornCell(BeetleInfo.randomize(Hardness, 5),
                            BeetleInfo.randomize(XSize,3),
                            BeetleInfo.randomize(MaxHealth, 5),
                            parent);
    }
}
