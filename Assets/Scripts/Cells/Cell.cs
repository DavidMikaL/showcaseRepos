using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;

public abstract class Cell
{   
    /** Stats (not status):
        hardness
        xSize
        ySize
        maxHealth

        Parent
    */
    private RootCell parent;
    private CellType cellType;
    public CellType CellType {get{return cellType;} private set{cellType = value;}}
    private double hardness {get; set;}
    public double Hardness {get{return hardness;} private set{hardness = value;}}
    private double xSize {get; set;}
    private double ySize {get; set;}
    public double XSize {get{return xSize;} set{xSize = value;}}
    public double YSize {get{return ySize;} set{ySize = value;}}
    private double maxHealth {get; set;}
    public double MaxHealth {get{return maxHealth;} set{maxHealth = value;}}
    /** Status:
        health
        position
    */
    private double health {get; set;} //=0; ???
    private double xPosition {get; set;}
    private double yPosition {get; set;}

    public Cell(double hardness, double xSize, double ySize, double maxHealth, CellType cellType, RootCell parent)
    {
        this.hardness = hardness;
        this.xSize = xSize;
        this.ySize = ySize;
        this.maxHealth = maxHealth;
        health = maxHealth;
        this.cellType = cellType;
        this.parent = parent;
    }

    /**
        random/null constructor 
    */
    public Cell(bool random, double xSize, double ySize, CellType cellType, RootCell parent)//random constructor
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

    /**
        Copy constructor
        unnecessary for now - not implemented in subclasses 
    */
    public Cell(Cell cell)
    {
        this.hardness = cell.hardness;
        this.xSize = cell.xSize;
        this.ySize = cell.ySize;
        this.maxHealth = cell.maxHealth;
        health = cell.maxHealth;
        this.cellType = cell.cellType;
        this.parent = cell.parent;
    }

    /**
        (To be reworked as basis for override)
    */
    // public Cell evolveCell(RootCell parent,Cell cell, CellType cellType)// workout cells other than
    // {
    //     
    // }

    public abstract Cell evolvedCell(RootCell parent);
}
