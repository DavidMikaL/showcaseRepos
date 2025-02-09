using UnityEngine;

public class ExtremityRootCell : RootCell
{
    private int angle;
    public int Angle {get{return angle;} set{angle = value;}}
    public ExtremityRootCell(double hardness, double size, double maxHealth, int angle, RootCell parent) : base(hardness, size, size, maxHealth, CellType.ExtremityRoot, parent)
    {
        this.angle = angle;
    }

    /**
        random/null constructor 
    */
    public ExtremityRootCell(bool random, double xSize, double ySize, RootCell parent) : base(random, xSize, ySize, CellType.ExtremityRoot, parent)
    {
        if(random)
        {
            this.angle =  -30 + Random.Range(0,60);
        }
    }

    /**
        Return a ERCell 
        slightly different from the one executing the method 
    */
    public override Cell evolvedCell(RootCell parent)
    {
        ExtremityRootCell extremityRootCell = new ExtremityRootCell(BeetleInfo.randomize(this.Hardness, 5),
                                                                    BeetleInfo.randomize(this.XSize,5),
                                                                    BeetleInfo.randomize(this.MaxHealth, 5),
                                                                    BeetleInfo.randomizeInt(angle, 5),
                                                                    parent);
        

        int thickness = Cells.GetLength(1);//BeetleInfo.randomizeInt(Cells.GetLength(1) + 1, 1);

        Cell[,] newCells = new Cell[3, thickness];

        int topheight;
        for(int i = 0; i < 2; i++)
        {
            //int topheight;
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
                        newCells[i,topheight] = RandomizedCreation.randomizedCell(this.XSize, parent);
                    }
                    //chance to disappear topheight(if j != -1)
                    else if(topheight >= 0 && j != -1 && Random.Range(0,99) == 1)
                    {
                        newCells[i,topheight] = null;
                    }
                    break;
                }

                newCells[i,j] = Cells[i,j].evolvedCell(parent);
            }
        }
        for(int i = 0; i < thickness; i++)
        {
            if(i == Cells.GetLength(1))
            {
                topheight = i;

                if(Random.Range(0,99) == 1)
                {
                    newCells[2,topheight] = null;
                }
                break;
            }
            if(Cells[2,i] == null)
                {
                    topheight = i - 1;
                
                    //chance to add new random cell at topheight + 1 (if topheight != thickness - 1)
                    if(topheight != thickness - 1 && Random.Range(0,99) == 1)
                    {
                        newCells[2,topheight] = RandomizedCreation.randomizedCell(this.XSize, parent);
                    }
                    //cahnce to disappear topheight(if j != -1)
                    else if(i != -1 && Random.Range(0,99) == 1)
                    {
                        newCells[i,topheight] = null;
                    }
                    break;
                }
            
            newCells[2,i] = Cells[2,i].evolvedCell(parent);
        }

        extremityRootCell.Cells =  newCells;// not call by reference for better readability clone is not necessary rn

        return extremityRootCell;
    }
}