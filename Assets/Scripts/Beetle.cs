using UnityEngine;


public class Beetle : MonoBehaviour
{
    BeetleInfo info;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void writeCells(Cell[,] cells)
    {
        for(int i = 0; i < cells.GetLength(0); i++)
        {
            string logString = "";
            for(int j = 0; j < cells.GetLength(1); j++)
            {
                if(cells[i,j] != null)
                {
                    logString += j; 
                }
                else{
                    logString += "_";
                }
            }
            Debug.Log(logString);
        }
    }
    
    void Start()
    {
        //info = RandomizedCreation.createRandomBeetleInfo();
        BeetleInfo beetleInfo = RandomizedCreation.createRandomBeetleInfo();
        //Cell[,] cells = beetleInfo.MainCoreCell.cells;
        //Debug.l
        //writeCells(cells);

        // Cell[,] cells = new Cell[10,10];
        // for(int i = 0; i < 10; i++)
        // {
        //     for(int j = 0; j < 10; j++)
        //     {
        //         if(Random.Range(0,99) < 95)
        //         {
        //             cells[i,j] = new MeatCell(true,5);
        //         }
                
        //     }
        // }

        // writeCells(cells);
        // for(int i = 0; i < 10; i++)
        // {
        //     Debug.Log(Random.Range(0,99));
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
