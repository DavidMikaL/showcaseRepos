using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
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

    private bool alive = true;
    private int survivalTime;


    public BeetleInfo(double reprodAmount, double speed, double regenSpeed, double generation, CoreCell mainCoreCell)
    {
        this.reprodAmount = reprodAmount;
        this.speed = speed;
        this.regenSpeed = regenSpeed;
        this.generation = generation;
        this.mainCoreCell = mainCoreCell;
    }

    public BeetleInfo evolvedBeetleInfo()//cant simply clone and evolve cause pointers would stay the same
    {
        CoreCell newmainCore = mainCoreCell.evolvedCore(null);
        BeetleInfo newBI = new BeetleInfo(randomize(reprodAmount,1), randomize(reprodAmount,5), randomize(regenSpeed, 10), generation + 1, newmainCore);
        return newBI;
    }

    public static double randomize(double input, int range)//adjust to normal distribution
    {
        double ret =  input - range/2 + Random.Range(0,range);
        return ret < 1 ? 1 : ret;
    }

    public static int randomizeInt(double input, int range)//adjust to normal distribution
    {
        int ret = (int)input - range/2 + Random.Range(0,range);
        return ret < 1 ? 1 : ret;
    }


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
