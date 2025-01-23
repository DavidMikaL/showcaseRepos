using UnityEngine;

public class EyeCell : Cell
{
    private double visionDistance {get; set;}
    // visionrange width angle
    private double visionAngle {get; set;}

    public EyeCell(double hardness, double size, double maxHealth, double visionDistance, double visionAngle, Cell parent) : base(hardness, size, size, maxHealth, parent)
    {
        this.visionDistance = visionDistance;
        this.visionAngle = visionAngle;
    }

    public EyeCell(bool random, double size, Cell parent) : base(random, size, size, parent)
    {
        this.visionDistance = Random.Range(1,300);
        this.visionAngle = Random.Range(10,90);
    }
    // Give information through to BeetleBase
}
