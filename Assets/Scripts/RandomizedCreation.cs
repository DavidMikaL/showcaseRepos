using System.Collections;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public static class RandomizedCreation
{
    // public static GameObject generateGOFromBeetleInfo()
    // {
    //     GameObject gameObject = new GameObject();
    //     BeetleInfo info = createRandomBeetleInfo();
    //     SpriteRenderer spriteRenderer = new SpriteRenderer();
    //     spriteRenderer.sprite = Square;

    //     gameObject = gameObject.AddComponent<>()
    // }

    /**
        create RandomCoreCellRecursively
    */
    public static BeetleInfo createRandomBeetleInfo()
    {
        return new BeetleInfo(Random.Range(0,2), Random.Range(1,10), Random.Range(0,10), 0, createRandomCoreCell(null));
    }

    /**
        recursively add in Randomly created Cells starting from ExtremityRootCell 
    */
    public static ExtremityRootCell createRandomExtremityRootCell(double cellSize, RootCell parent)
    {
        //Debug.Log("This happens");

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
        if(thickness >= 1)
        {
            int topheight = Random.Range(0,thickness - 1);
            for(int i = 0; i < topheight; i++)
            {
                cells[2,i] = randomizedCell(cellSize, parent);
            }
        
            if(Random.Range(0,999) == 5)//1 in 1000
            {
                cells[2,topheight] = createRandomCoreCell(parent);
            } else if(Random.Range(0,99) < 75){
                cells[2,topheight] = createRandomExtremityRootCell(cellSize, parent);// additional chance to elongate extremy
            } else {
                cells[2,topheight] = randomizedCell(cellSize, parent);
            }
        }

        extremityRootCell.Cells =  (Cell[,])cells.Clone();
        return extremityRootCell;
    }

    /**
        recursively add in Randomly created Cells starting from coreCell 
    */
    public static CoreCell createRandomCoreCell(RootCell parent)
    {
        int thickness = Random.Range(2,5);
        double cellSize = Random.Range(5,10);
        int mainXSize = Random.Range(20,100);//remove
        int mainYSize = Random.Range(20,100);//remove
        int cellColumnAmount = (mainXSize + mainYSize)/4 - ((mainXSize+mainYSize) / 8) + Random.Range(0, mainXSize+mainYSize/8); // defines density around elyptical CoreCell

        CoreCell CoreCell =  new CoreCell(true, mainXSize, mainYSize, parent);

        Cell[,] cells = new Cell[cellColumnAmount, thickness];

        for(int i = 0; i < cellColumnAmount; i++)
        {
            int j = 0;
            while(j < thickness && Random.Range(0,99) < 95)
            {
                cells[i,j] = randomizedCell(cellSize, parent);
                j++;
            }
        }

        CoreCell.Cells =  (Cell[,])cells.Clone();// not call by reference for better readability

        return CoreCell;
    }

    /**
        return new random Cell of random Type
    */
    public static Cell randomizedCell(double cellSize, RootCell parent)// Cant return Core Cell
    {
        int randomSeed = Random.Range(0,99);

        if(randomSeed > 11){//Meat
            return new CommonCell(true, cellSize, parent);}
        if(randomSeed < 5){//Horn
            return new HornCell(true, cellSize, parent);
        }if (randomSeed >= 5 && randomSeed < 10){//Extremity
            return createRandomExtremityRootCell(cellSize, parent);
        }if(randomSeed == 10){//Eye
            return new EyeCell(true, cellSize, parent);
        }else {
            return new MouthCell(true, cellSize, parent);
        }
    }
}
