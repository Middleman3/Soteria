using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : Action { // Strategy Design Pattern (ConcreteStrategy)
    private bool test = true;

    // Override Abstract Properties
    protected override string buttonName 
    {
        get { return "LootButton"; }
        set { buttonName = value; }
    }
    public override string title 
    {
        get { return "Loot"; }
        set { buttonName = value; }
    }

    //Singleton Design Pattern
    private static Action _instance = null;
    public static Action Instance()
    {
        if (_instance == null) _instance = new Loot();
        return _instance;
    }
    protected Loot() : base()
    {
        if (test) Debug.Log("Loot Constructor...");
    }

    // Overrides for Template Method Design Pattern
    protected override bool Execute() 
    {
        if (test) Debug.Log("Loot.Execute...");
        //throw new System.NotImplementedException();
        return false;
    }
    protected override bool ValidateAction() 
    {
        if (test) Debug.Log("Loot.ValidateAction...");
        //Check Inventory Space, Carrying Capacity
        //throw new System.NotImplementedException();
        return false;
    }
}
