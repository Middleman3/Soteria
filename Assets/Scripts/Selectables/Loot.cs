using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : Action { // Command Design Pattern (ConcreteCommand)
    private Inventory target;
    private Inventory looter;
    private Inventory.lootOption option;

    // Default Constructor for Unity 
    public Loot() { }

    public Loot(Inventory target, Inventory looter, Inventory.lootOption option)
    {
        if (test) Debug.Log("Loot Constructor...");
        this.target = target;
        this.option = option;
        this.looter = looter;
    }

    // Overrides for Template Method Design Pattern
    protected override bool Execute() 
    {
        if (test) Debug.Log("Loot.Execute...");
        return this.looter.Loot(target, option);
    }

    public override System.Type TargetType()
    {
        if (test) Debug.Log("Loot.TargetType...");
        return new Inventory().GetType();
    }
}
