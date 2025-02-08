//using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class CoreCell : RootCell
{

    public CoreCell(double hardness, double xSize, double ySize, double maxHealth, RootCell parent) : base(hardness, xSize, ySize, maxHealth, CellType.Core, parent)
    {
        
    }

    /**
        random/null constructor (nothing to randomize)
    */
    public CoreCell(bool random, double xSize, double ySize, RootCell parent) : base(random, xSize, ySize, CellType.Core, parent)
    {
    }


    /**
        Return a CoreCell 
        slightly different from the one executing the method 
    */    
    public CoreCell evolvedCore(RootCell parent)
    {
        CoreCell coreCell = new CoreCell(BeetleInfo.randomize(this.Hardness, 5),
                                        BeetleInfo.randomize(this.XSize,5),
                                        BeetleInfo.randomize(this.YSize,5),
                                        BeetleInfo.randomize(this.MaxHealth, 5),
                                        parent);
        

        int thickness = Cells.GetLength(1);//BeetleInfo.randomizeInt(Cells.GetLength(1) + 1, 1);
        
        double cellSize; 
        if(Cells[0,0] != null)
        {cellSize = BeetleInfo.randomize(Cells[0,0].XSize, 1);}
        else{cellSize = Random.Range(5,10);}

        int cellColumnAmount = Cells.GetLength(0);//BeetleInfo.randomizeInt(Cells.GetLength(0), 4);// defines density around elyptical CoreCell

        Cell[,] newCells = new Cell[cellColumnAmount, thickness];

        for(int i = 0; i < cellColumnAmount; i++)
        {
            int topheight = -1;
            for(int j = 0; j < thickness; j++)
            {
                //rethink if thickness has decreased / increased !!!!!!!!!!!!!!!!
                // also use 
                if(j == thickness - 1 || j == Cells.GetLength(1) - 1) // whatever gets reached first???
                {
                    topheight = j;
                    //chance to disappear
                    if(Random.Range(0,99) == 1)
                    {
                        newCells[i,topheight] = null;
                    }
                    break;
                } else if(Cells[i,j] == null)
                {
                    topheight = j - 1;
                
                    //chance to add new random cell at topheight + 1 (if topheight != thickness - 1)
                    if(topheight >= 0 && topheight != thickness - 1 && Random.Range(0,99) == 1)
                    {
                        newCells[i,topheight] = RandomizedCreation.randomizedCell(cellSize, parent);
                    }
                    //chance to disappear topheight(if j != -1)
                    else 
                    if(topheight >= 0 && j != -1 && Random.Range(0,99) == 1)
                    {
                        newCells[i,topheight] = null;
                    }
                    break;
                }

                switch(Cells[i,j].CellType)
                {
                    case CellType.Common:
                        CommonCell coc = (CommonCell) Cells[i,j];
                        newCells[i,j] =  new CommonCell(BeetleInfo.randomize(coc.Hardness, 5),
                                            BeetleInfo.randomize(coc.XSize,3),
                                            BeetleInfo.randomize(coc.MaxHealth, 5),
                                            parent);
                    break;
                    case CellType.Core:
                        CoreCell cc = (CoreCell) Cells[i,j];
                        newCells[i,j] =  cc.evolvedCore(parent);
                    break;
                    case CellType.ExtremityRoot:
                        ExtremityRootCell erc = (ExtremityRootCell) Cells[i,j];
                        newCells[i,j] =  erc.evolvedExtremityRoot(parent);
                    break;
                    case CellType.Eye:
                        EyeCell ec = (EyeCell) Cells[i,j];
                        newCells[i,j] = new EyeCell(BeetleInfo.randomize(ec.Hardness, 5),
                                            BeetleInfo.randomize(ec.XSize,3),
                                            BeetleInfo.randomize(ec.MaxHealth, 5),
                                            BeetleInfo.randomize(ec.VisionDistance, 10),
                                            BeetleInfo.randomize(ec.VisionAngle, 2),
                                            parent);
                    break;
                    case CellType.Horn:
                        HornCell hc = (HornCell) Cells[i,j];
                        newCells[i,j] =  new HornCell(BeetleInfo.randomize(hc.Hardness, 5),
                                            BeetleInfo.randomize(hc.XSize,3),
                                            BeetleInfo.randomize(hc.MaxHealth, 5),
                                            parent);
                    break;
                    default: //Celltype.Mouth
                        MouthCell mc = (MouthCell) Cells[i,j];
                        newCells[i,j] =  new MouthCell(BeetleInfo.randomize(mc.Hardness, 5),
                                            BeetleInfo.randomize(mc.XSize,3),
                                            BeetleInfo.randomize(mc.MaxHealth, 5),
                                            parent);
                    break;
                }
            }
        }

        coreCell.Cells =  newCells;// not call by reference for better readability clone is not necessary rn

        return coreCell;
    }
}
