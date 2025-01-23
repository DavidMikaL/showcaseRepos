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
        (just connection to main intestine cell)
    */
    private IntestineCell mainIntestineCell;
    public IntestineCell MainIntestineCell {get{return mainIntestineCell;} set{mainIntestineCell = value;}}

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


    public BeetleInfo(double reprodAmount, double speed, double regenSpeed, double generation, IntestineCell mainIntestineCell)
    {
        this.reprodAmount = reprodAmount;
        this.speed = speed;
        this.regenSpeed = regenSpeed;
        this.generation = generation;
        this.mainIntestineCell = mainIntestineCell;
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
