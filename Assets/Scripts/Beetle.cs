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

        transform.position = new Vector3(-1f, -1f, 0f);
    }

    void Start()
    {
        
    }


    BeetleInfo beetleInfo;
    int evolveTimer = 100;
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Add sprite"))
        {
            beetleInfo = RandomizedCreation.createRandomBeetleInfo();
            sr.sprite = SpriteWork.createBeetleSprite(beetleInfo);
        }

        if (GUI.Button(new Rect(150, 10, 100, 30), "Evolve"))
        {
            if (evolveTimer >= 100 && beetleInfo != null)
            {
                evolveTimer = 0;
            }
            else if(beetleInfo != null){
                evolveTimer = 100;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(evolveTimer < 100 && beetleInfo != null)
        {
            beetleInfo = beetleInfo.evolvedBeetleInfo();
            sr.sprite = SpriteWork.createBeetleSprite(beetleInfo);
            evolveTimer++;
        }
    }
}
