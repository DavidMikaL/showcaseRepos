using System.Collections;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class RandomizedCreation
{
    public RandomizedCreation()
    {
        
    }

    // public static GameObject generateGOFromBeetleInfo()
    // {
    //     GameObject gameObject = new GameObject();
    //     BeetleInfo info = createRandomBeetleInfo();
    //     SpriteRenderer spriteRenderer = new SpriteRenderer();
    //     spriteRenderer.sprite = Square;

    //     gameObject = gameObject.AddComponent<>()
    // }

    public static BeetleInfo createRandomBeetleInfo() //no Return necessary
    {
        return new BeetleInfo(Random.Range(0,2), Random.Range(1,10), Random.Range(0,10), 0, createRandomCoreCell(null));
    }

    public static ExtremityRootCell createRandomExtremityRootCell(double cellSize, Cell parent)
    {
        int thickness = UnityEngine.Random.Range(1,4);
        Cell[,] cells = new Cell[3,thickness];
        ExtremityRootCell extremityRootCell =  new ExtremityRootCell(true, cellSize, cellSize, parent);
        
        for(int i = 0; i < 2; i++)
        {
            for(int j  = 0; j < thickness; j ++)
            {
                if(Random.Range(0,99) < 95)
                {
                    cells[i,j] = randomizedCell(cellSize, parent);
                }else {break;}
            }
        }

        int topheight = Random.Range(1,thickness - 1);
        for(int i = 0; i < topheight; i++)
        {
            cells[2,i] = randomizedCell(cellSize, parent);
        }
        if(Random.Range(0,999) == 5)//1 in 1000
        {
            cells[2,topheight] = createRandomCoreCell(parent);
        } else {
            cells[2,topheight] = randomizedCell(cellSize, parent);
        }
        
        extremityRootCell.Cells =  (Cell[,])cells.Clone();    
        return extremityRootCell;
    }
    

    public static CoreCell createRandomCoreCell(Cell parent)
    {
        int thickness = UnityEngine.Random.Range(1,4);
        double cellSize = UnityEngine.Random.Range(1,10); //should also work out with very small mainCoreCells
        int mainXSize = Random.Range(1,10);
        int mainYSize = Random.Range(1,10);
        int cellColumnAmount = 4 * thickness + 2 * mainXSize + 2 * mainYSize;

        CoreCell CoreCell =  new CoreCell(true, mainXSize * cellSize, mainYSize * cellSize, parent);

        Cell[,] cells = new Cell[cellColumnAmount, thickness];
        // mainXSize == cells.GetLength(0);

        // Build straight sides:
        // X/Y

        // Insert 4 different propperly rotated corners rotated
        // top right:
        bool y = true;
        int current = 0;
        for(int k = 0; k < 4; k++)
        {
            //build corners
            Cell[,] corner = generateCorner(thickness, cellSize, CoreCell);
            for(int i = 0; i < thickness; i++)
            {
                for(int j = 0; j < thickness; j++)
                {
                    cells[current,j] = corner[i,j];
                }
                current++;
            }

            //build straight sides:
            if(y) 
            {
                //current += mainYSize;
                for(int i = 0; i < mainYSize; i++)
                {
                    for(int j = 0; j < thickness; j++)
                    {
                        if(Random.Range(0,99) < 95)
                        {
                            cells[current,j] = new CommonCell(true, cellSize, CoreCell);
                        }
                        else
                        {
                            break;
                        }
                    }
                    current++;
                }
            } 
            else 
            {
                //current += mainXSize;
                for(int i = 0; i < mainXSize; i++)
                {
                    for(int j = 0; j < thickness; j++)
                    {
                        if(Random.Range(0,99) < 95)
                        {
                            cells[current,j] = new CommonCell(true, cellSize, CoreCell);
                        }
                        else
                        {
                            break;
                        }
                    }
                    current++;
                }
            }
            y = !y;
        }

        CoreCell.Cells =  (Cell[,])cells.Clone();// not call by rference for better readability
        
        return CoreCell;
    }

    public static Cell[,] generateCorner(int thickness, double cellSize, Cell parent) // Fix:  compress first cell into for loop / maybe adjust for correct rotation
    {
        Cell[,] cells = new Cell[thickness , thickness]; 
        if(Random.Range(0,99) < 99) //1% chance for core Cell of corner to not exist
        {
            cells[0,0] = randomizedCell(cellSize, parent);
            bool left = true;
            bool right = true;
            for(int i = 1; i < thickness; i++){//generate outside walls of corner
                if(left){
                    if(Random.Range(0,99) < 95)
                    {
                        cells[0,i] = randomizedCell(cellSize, parent);
                    }
                    else{left = false;}
                }
                if(right){
                    if(Random.Range(0,99) < 95)
                    {
                        cells[i,0] = randomizedCell(cellSize, parent);
                    }else{right = false;}
                }
            }

            //check if cell on central line should exist -> build rows up -> check next central cell
            for(int i = 1; i<thickness; i++){
                if((cells[i-1,i] != null || cells[i,i-1] != null) && Random.Range(0,99) < 97)// 3% on core diagonal cells
                {
                    cells[i,i] = randomizedCell(cellSize, parent);
                    left = true;
                    right = true;
                    for(int j = i + 1; j < thickness; j++)
                    {
                        if(left){
                            if(Random.Range(0,99) < 95){
                                cells[i,j] = randomizedCell(cellSize, parent);
                            }else{left = false;}
                        }
                        if(right){
                            if(Random.Range(0,99) < 95){
                                cells[j,i] = randomizedCell(cellSize, parent);
                            }else{right = false;}
                        }
                    }
                    
                }else{break;}
            }
        }
        return cells;
    }



    public static Cell randomizedCell(double cellSize, Cell parent)// Cant return Core Cell
    {
        int randomSeed = Random.Range(0,999);
        
        if(randomSeed > 7){//Meat
            return new CommonCell(true, cellSize, parent);
        }if(randomSeed < 5){//Horn
            return new HornCell(true, cellSize, parent);
        }if (randomSeed == 5){//Extremity
            return createRandomExtremityRootCell(cellSize, parent);
        }if(randomSeed == 6){//Eye
            return new EyeCell(true, cellSize, parent);
        }if(randomSeed == 7){//Mouth
            return new MouthCell(true, cellSize, parent);
        }
        else {return null;}
    }
}
