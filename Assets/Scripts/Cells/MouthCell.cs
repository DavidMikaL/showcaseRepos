using UnityEngine;

public class MouthCell : Cell
{
    // use as weapon?

    public MouthCell(double hardness, double size, double maxHealth, RootCell parent) : base(hardness, size, size, maxHealth, CellType.Mouth, parent)
    {
    }

    /**
        random/null constructor (nothing to randomize)
    */
    public MouthCell(bool random, double size, RootCell parent) : base(random, size, size, CellType.Mouth, parent)
    {
    }

    public override Cell evolvedCell(RootCell parent)
    {
        return new MouthCell (BeetleInfo.randomize(Hardness, 5),
                             BeetleInfo.randomize(XSize,3),
                             BeetleInfo.randomize(MaxHealth, 5),
                             parent);
    }
}
