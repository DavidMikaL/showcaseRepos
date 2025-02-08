using System.Collections;
using System.Collections.Generic; // Import for spot list
using Unity.Mathematics;
using UnityEngine;


public class Beetle : MonoBehaviour
{
    BeetleInfo info;

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
            if(beetleInfo == null)
            {
                Debug.Log("first create a sprite");
            }
            else if (evolveTimer >= 100)
            {
                evolveTimer = 0;
            }
            else if(beetleInfo != null){
                evolveTimer = 100;
            }
        }
    }
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
