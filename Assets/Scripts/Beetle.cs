using System.Collections;
using System.Collections.Generic; // Import for spot list
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
                    logString += " "; 
                    logString += cells[i,j].CellType; 
                    logString += " "; 
                }
                else{
                    logString += " _ ";
                }
            }
            Debug.Log(logString);
        }
    }
    

    private Sprite mySprite;
    private SpriteRenderer sr; // do I have to insert this?

    void Awake()
    {
        sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        //sr.color = new Color(1f, 1f, 1f, 1f);

        transform.position = new Vector3(-1f, -1f, 0f);
    }

    void Start()
    {
        BeetleInfo beetleInfo = RandomizedCreation.createRandomBeetleInfo();
        // ICollection<Spot> spots = SpriteWork.createSpotBug(beetleInfo);
        // foreach(Spot s in spots)
        // {
        //     s.printSpot();
        // }
        mySprite = SpriteWork.createBeetleSprite(beetleInfo);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Add sprite"))
        {
            sr.sprite = mySprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
