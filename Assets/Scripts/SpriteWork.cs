using System;
using Unity.Collections;
using System.Collections.Generic; // Import for spot list
using UnityEngine;
using Unity.VisualScripting;
using Unity.Burst.Intrinsics;
using System.Linq;
using UnityEngine.InputSystem.Interactions;

public class SpriteWork
{
    //public Sprite mySprite;
    /**
        Create Sprite from texture
    */
    public static Sprite createBeetleSprite(BeetleInfo beetleInfo)
    {
        Texture2D tex = drawAllSpots(createSpotBug(beetleInfo));
        tex.Apply();
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0f, 0f));
        

        return sprite;
        //this.GetComponent<SpriteRenderer>().sprite = mySprite;
    }
    
    /**
        create Texture from list of Spots
    */
    public static Texture2D drawAllSpots(ICollection<Spot> spots)
    {
        int maxX = 0;
        int maxY = 0;
        foreach(Spot spot in spots)
        {
            if(Math.Abs(spot.X) > maxX)
            {
                maxX = Math.Abs(spot.X);
            }
            if(Math.Abs(spot.Y) > maxY)
            {
                maxY = Math.Abs(spot.Y);
            }
        }

        //Debug.Log(maxX + " | " + maxY);

        Texture2D returnTexture = new Texture2D(3 + maxX * 2, 3 + maxY * 2);
        
        
        
        foreach(Spot spot in spots)
        {
            int x = 1 + maxX + spot.X;
            int y = 1 +  maxY + spot.Y;
            returnTexture.SetPixel(x,y, spot.Color);

            returnTexture.SetPixel(x+1,y, spot.Color);
            returnTexture.SetPixel(x-1,y, spot.Color);
            returnTexture.SetPixel(x,y+1, spot.Color);
            returnTexture.SetPixel(x,y-1, spot.Color);
        }
        //Debug.Log(spots.Count);
        //Debug.Log(returnTexture.GetPixel(1,1));
        return returnTexture;
    }

    /**
        Call recursive function for mainCoreCell 
    */
    public static ICollection<Spot> createSpotBug(BeetleInfo beetleInfo)
    {
        CoreCell mainCore = beetleInfo.MainCoreCell;
        ICollection<Spot> spots = createSpotCore(mainCore ,0 ,0 ,0 );

        return spots;
    }

    /**
        create List of spots for Cells under coreCell
        recursively add Cells under rootcells as spots

        Calculate positions on sprite from position in Structure
        Color depends on type of Cell
    */
    public static ICollection<Spot> createSpotCore(CoreCell currentCell, int currentX, int currentY, float currentAngle)
    {
        ICollection<Spot> spots = new List<Spot>
        {
            new Spot(currentX, currentY, Color.blue)
        };
        Cell[,] cells = currentCell.Cells;
        for(int i = 0; i < cells.GetLength(0); i++)
        {
            float angle = currentAngle + (360 / cells.GetLength(0)) * i;
            for(int j = 0; j < cells.GetLength(1); j++)
            {
                Cell cell = cells[i,j];
                if(cell == null)
                {
                    break;
                }
                Vector2 v = new Vector2((float)((currentCell.XSize/2) * Math.Sin(angle)), (float)((currentCell.YSize/2) * Math.Cos(angle)));
                double multiplier = 1 + (((1/2 + j) * cell.XSize)/(v.magnitude));
                //Debug.Log("vector y" + v.y);
                int xPosition = currentX + (int)Math.Round(v.x * multiplier);
                int yPosition = currentY + (int)Math.Round(v.y * multiplier);
                //Debug.Log("final yPos" + yPosition);
                switch(cell.CellType)
                {
                    case CellType.Common:
                        spots.Add(new Spot(xPosition, yPosition, Color.black));
                        break;
                    // case CellType.Core:
                    //     break;
                    case CellType.ExtremityRoot:
                        ExtremityRootCell erCell = (ExtremityRootCell)cell;
                        spots.Concat(createSpotExtremity(erCell, xPosition, yPosition, angle + erCell.Angle));
                        break;
                    case CellType.Eye:
                        spots.Add(new Spot(xPosition, yPosition, Color.green));
                        break;
                    case CellType.Horn:
                        spots.Add(new Spot(xPosition, yPosition, Color.gray));
                        break;
                    case CellType.Mouth:
                        spots.Add(new Spot(xPosition, yPosition, Color.red));
                        break;
                }
            }
        }
        return spots;
    }

    /**
        create List of spots for Cells under extremityRootCell
        recursively add Cells under rootcells as spots

        Calculate positions on sprite from position in Structure
        Color depends on type of Cell
    */
    public static ICollection<Spot> createSpotExtremity(ExtremityRootCell currentCell, int currentX, int currentY, float currentAngle)
    {
        //Debug.Log("Also does");
        ICollection<Spot> spots = new List<Spot>
        {
            new Spot(currentX, currentY, Color.magenta)
        };
        Cell[,] cells = currentCell.Cells;

        for(int i = 0; i < 2; i++)
        {
            float angle = currentAngle + 90 + 180 * i;
            for(int j = 0; j < cells.GetLength(1); j++)
            {
                Cell cell = cells[i,j];
                if(cell == null)
                {
                    break;
                }
                Vector2 v = new Vector2((float)((currentCell.XSize/2) * Math.Sin(angle)), (float)((currentCell.YSize/2) * Math.Cos(angle)));
                double multiplier = 1 + (((1/2 + j) * cell.XSize)/(v.magnitude));

                int xPosition = currentX + (int)Math.Round(v.x * multiplier);
                int yPosition = currentY + (int)Math.Round(v.y * multiplier);
                switch(cell.CellType)
                {
                    case CellType.Common:
                        spots.Add(new Spot(xPosition, yPosition, Color.black));
                        break;
                    // case CellType.Core:
                    //     break;
                    case CellType.ExtremityRoot:
                        ExtremityRootCell erCell = (ExtremityRootCell)cell;
                        spots.Concat(createSpotExtremity(erCell, xPosition, yPosition, angle + erCell.Angle));
                        break;
                    case CellType.Eye:
                        spots.Add(new Spot(xPosition, yPosition, Color.green));
                        break;
                    case CellType.Horn:
                        spots.Add(new Spot(xPosition, yPosition, Color.gray));
                        break;
                    case CellType.Mouth:
                        spots.Add(new Spot(xPosition, yPosition, Color.red));
                        break;
                }
            }
        }

        //topheight issue
        for(int j = 0; j < cells.GetLength(1); j++)
            {
                Cell cell = cells[2,j];
                if(cell == null)
                {
                    break;
                }
                Vector2 v = new Vector2((float)((currentCell.XSize/2) * Math.Sin(currentAngle)), (float)((currentCell.YSize/2) * Math.Cos(currentAngle)));
                double multiplier = 1 + (((1/2 + j) * cell.XSize)/(v.magnitude));

                int xPosition = currentX + (int)Math.Round(v.x * multiplier);
                int yPosition = currentY + (int)Math.Round(v.y * multiplier);
                switch(cell.CellType)
                {
                    case CellType.Common:
                        spots.Add(new Spot(xPosition, yPosition, Color.black));
                        break;
                    case CellType.Core:
                        CoreCell cCell = (CoreCell)cell;
                        spots.Concat(createSpotCore(cCell, xPosition, yPosition, currentAngle));
                        break;
                    case CellType.ExtremityRoot:
                        ExtremityRootCell erCell = (ExtremityRootCell)cell;
                        spots.Concat(createSpotExtremity(erCell, xPosition, yPosition, currentAngle + erCell.Angle));
                        break;
                    case CellType.Eye:
                        spots.Add(new Spot(xPosition, yPosition, Color.green));
                        break;
                    case CellType.Horn:
                        spots.Add(new Spot(xPosition, yPosition, Color.gray));
                        break;
                    case CellType.Mouth:
                        spots.Add(new Spot(xPosition, yPosition, Color.red));
                        break;
                }
            }
        return spots;
    }


    // public static Spot[] createInterpolatedBug(BeetleInfo beetleInfo)
    // {

    // }
}
