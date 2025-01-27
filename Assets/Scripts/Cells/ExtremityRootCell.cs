using UnityEngine;

public class ExtremityRootCell : RootCell
{
    private int angle;
    public int Angle {get{return angle;} set{angle = value;}}
    public ExtremityRootCell(double hardness, double size, double maxHealth, int angle, Cell parent) : base(hardness, size, size, maxHealth, CellType.ExtremityRoot, parent)
    {
        this.angle = angle;
    }

    public ExtremityRootCell(bool random, double xSize, double ySize, Cell parent) : base(random, xSize, ySize, CellType.ExtremityRoot, parent)
    {
        if(random)
        {
            this.angle =  -15 + Random.Range(0,30);
        }
    }
}
