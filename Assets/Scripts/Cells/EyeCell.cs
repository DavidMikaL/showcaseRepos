using UnityEngine;

public class EyeCell : Cell
{
    private double visionDistance {get; set;}
    public double VisionDistance {get{return visionDistance;} private set{visionDistance = value;}}
    // visionrange width angle
    private double visionAngle {get; set;}
    public double VisionAngle {get{return visionAngle;} private set{visionAngle = value;}}

    public EyeCell(double hardness, double size, double maxHealth, double visionDistance, double visionAngle, RootCell parent) : base(hardness, size, size, maxHealth, CellType.Eye, parent)
    {
        this.visionDistance = visionDistance;
        this.visionAngle = visionAngle;
    }

    /**
        random/null constructor 
    */
    public EyeCell(bool random, double size, RootCell parent) : base(random, size, size, CellType.Eye, parent)
    {
        this.visionDistance = Random.Range(1,300);
        this.visionAngle = Random.Range(10,90);
    }
}
