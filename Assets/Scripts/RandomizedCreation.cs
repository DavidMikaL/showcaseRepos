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

    public static BeetleInfo createRandomBeetleInfo()
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
        } else if(Random.Range(0,99) < 5){
            cells[2,topheight] = createRandomExtremityRootCell(cellSize, parent);
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
        int cellColumnAmount = 2*mainXSize + 2*mainYSize - ((mainXSize+mainYSize) / 2) + Random.Range(0, mainXSize+mainYSize); // defines density around Cylindrical CoreCell

        CoreCell CoreCell =  new CoreCell(true, mainXSize, mainYSize, parent);

        Cell[,] cells = new Cell[cellColumnAmount, thickness];

        for(int i = 0; i < cellColumnAmount; i++)
        {
            int j = 0;
            while(j < thickness && Random.Range(0,99) < 95)
            {
                j++;
                cells[i,j] = randomizedCell(cellSize, parent);
            }
        }

        CoreCell.Cells =  (Cell[,])cells.Clone();// not call by reference for better readability

        return CoreCell;
    }

    public static Cell randomizedCell(double cellSize, Cell parent)// Cant return Core Cell
    {
        int randomSeed = Random.Range(0,999);

        // if(randomSeed > 7){//Meat
        //     return new CommonCell(true, cellSize, parent);}
        if(randomSeed < 5){//Horn
            return new HornCell(true, cellSize, parent);
        }if (randomSeed == 5){//Extremity
            return createRandomExtremityRootCell(cellSize, parent);
        }if(randomSeed == 6){//Eye
            return new EyeCell(true, cellSize, parent);
        }if(randomSeed == 7){//Mouth
            return new MouthCell(true, cellSize, parent);
        }
        else {return new CommonCell(true, cellSize, parent);}
    }
}
