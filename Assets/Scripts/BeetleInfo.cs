//using System;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Mathematics;
using UnityEngine;
public class BeetleInfo
{
    /** Stats (not status):
        reprod amount
        Speed
        regen Speed?

        Generation

        meatMultiplier
        plantMultiplier
        aggression

        Tree of Cells
        (just connection to main Core cell)
    */
    private CoreCell mainCoreCell;
    public CoreCell MainCoreCell {get{return mainCoreCell;} set{mainCoreCell = value;}}

    private double reprodAmount;
    private double speed;
    private double regenSpeed;
    private double generation;
    private double meatMultiplier;
    private double plantMultiplier;
    private double aggression;
    private double neededFood;
    
    /** status (probably stored in object of this class):
        (bool) alive
        survivalTime

        (Delays)
    */

    //private bool alive = true;
    private int survivalTime;


    public BeetleInfo(double reprodAmount, double speed, double regenSpeed, double generation, CoreCell mainCoreCell)
    {
        this.reprodAmount = reprodAmount;
        this.speed = speed;
        this.regenSpeed = regenSpeed;
        this.generation = generation;
        this.mainCoreCell = mainCoreCell;
    }

    /**
        Return a BeetleInfo 
        slightly different from the one executing the method 
        (dangerously recursive)
    */
    public BeetleInfo evolvedBeetleInfo()//cant simply clone and evolve cause pointers would stay the same
    {
        CoreCell newmainCore = mainCoreCell.evolvedCore(null);
        BeetleInfo newBI = new BeetleInfo(randomize(reprodAmount,1), randomize(reprodAmount,5), randomize(regenSpeed, 10), generation + 1, newmainCore);
        return newBI;
    }

    private static Unity.Mathematics.Random rand = new Unity.Mathematics.Random(1);
    /**
        maybe adjust random seed!

        get random double around input 
        values are more likely to be closer to input 
        values stay within range in both directions
    */  
    public static double randomize(double input, double range, double lowCap = 1)//adjust to normal distribution
    {
        double ret =  input + Mathf.Pow(-1,rand.NextInt(0,2)) * range * Mathf.Pow(rand.NextFloat(),5);
        return ret < lowCap ? lowCap : ret;
    }
    /**
        cast return of randomize(...) to Integer
    */
    public static int randomizeInt(int input, int range, int lowCap = 1)//adjust to normal distribution
    {
        int ret = (int)math.round(randomize(input,range, lowCap));
        return ret < lowCap ? lowCap : ret;
    }

//old planning:
    // create hitbox structure
    // should some cells behave on their own? - no
    // create gameobject
    // -> eating, execute damage impacts
    // Colliders are directly attached to gameobject?

    //movement
    /** decisionmaking (Directly in this class?)
        battle behaviour -> movement patterns - do attack check damage adjust behaviour if higher than before
    */


    //selfdespawn after time

    //generate stats for offspring
    //calculate neededFood
}
