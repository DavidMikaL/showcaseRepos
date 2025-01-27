using UnityEngine;

public class Spot
{
    private int x;
    private int y;
    private Color color;

    public int X {get{return x;} set{x = value;}}
    public int Y {get{return y;} set{y = value;}}
    public Color Color {get{return color;} set{color = value;}}

    public Spot(int x, int y, Color color)
    {
        this.x = x;
        this.y = y;
        this.color = color;
    }

    public void printSpot()
    {
        Debug.Log("(x: " + x + " y: " + y + " c: " + color + ")");
    }
}
