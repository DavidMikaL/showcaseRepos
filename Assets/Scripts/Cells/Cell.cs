using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Cell
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

    // public Cell evolveCell(RootCell parent,Cell cell, CellType cellType)// workout cells other than
    // {
    //     //Cell cell = new Cell(this);//copy constructor
    //     //take cell of given type - return similar cell of same type
    //     switch(cellType)
    //     {
    //         case CellType.Common:
    //             CommonCell coc = (CommonCell) cell;
    //             return new CommonCell(BeetleInfo.randomize(coc.hardness, 5),
    //                                 BeetleInfo.randomize(coc.xSize,3),
    //                                 BeetleInfo.randomize(coc.maxHealth, 5),
    //                                 parent);
    //         case CellType.Core:
    //             CoreCell cc = (CoreCell) cell;
    //             return cc.evolvedCore(parent);
    //         case CellType.ExtremityRoot:
    //             ExtremityRootCell erc = (ExtremityRootCell) cell;
    //             return erc.evolvedExtremityRoot(parent);
    //         case CellType.Eye:
    //             EyeCell ec = (EyeCell) cell;
    //             return new EyeCell(BeetleInfo.randomize(ec.hardness, 5),
    //                                 BeetleInfo.randomize(ec.xSize,3),
    //                                 BeetleInfo.randomize(ec.maxHealth, 5),
    //                                 BeetleInfo.randomize(ec.VisionDistance, 10),
    //                                 BeetleInfo.randomize(ec.VisionAngle, 2),
    //                                 parent);
    //         case CellType.Horn:
    //             HornCell hc = (HornCell) cell;
    //             return new HornCell(BeetleInfo.randomize(hc.hardness, 5),
    //                                 BeetleInfo.randomize(hc.xSize,3),
    //                                 BeetleInfo.randomize(hc.maxHealth, 5),
    //                                 parent);
    //         default: //Celltype.Mouth
    //             MouthCell mc = (MouthCell) cell;
    //             return new MouthCell(BeetleInfo.randomize(mc.hardness, 5),
    //                                 BeetleInfo.randomize(mc.xSize,3),
    //                                 BeetleInfo.randomize(mc.maxHealth, 5),
    //                                 parent);
    //     }
    // }
}
