using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Cell
{   
    /** Stats (not status):
        hardness
        xSize
        ySize
        maxHealth

        Parent
    */
    private Cell parent;
    private CellType cellType;
    public CellType CellType {get{return cellType;} private set{cellType = value;}}
    private double hardness {get; set;}
    private double xSize {get; set;}
    private double ySize {get; set;}
    public double XSize {get{return xSize;} set{xSize = value;}}
    public double YSize {get{return ySize;} set{ySize = value;}}
    private double maxHealth {get; set;}
    /** Status:
        health
        position
    */
    private double health {get; set;} //=0; ???
    private double xPosition {get; set;}
    private double yPosition {get; set;}

    public Cell(double hardness, double xSize, double ySize, double maxHealth, CellType cellType, Cell parent)
    {
        this.hardness = hardness;
        this.xSize = xSize;
        this.ySize = ySize;
        this.maxHealth = maxHealth;
        health = maxHealth;
        this.parent = parent;
    }

    public Cell(bool random, double xSize, double ySize, CellType cellType, Cell parent)//random constructor
    {
        
        if(random)
        {   
            this.hardness = UnityEngine.Random.Range(1,100);
            this.xSize = xSize;
            this.ySize = ySize;
            this.maxHealth = UnityEngine.Random.Range(1,100);
            health = maxHealth;
            this.cellType = cellType;
            this. parent = parent;
        }
    }
}
