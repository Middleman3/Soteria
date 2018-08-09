using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Element
{
    private bool test = true;
    public enum lootOption
    {
        TakeAll, Pickpocket, Select
    }

    public List<Item> inventory { get; set; }

    void Start()
    {
        inventory = new List<Item>();
    }

    public void Add(Item item)
    {
        inventory.Add(item);
    }

    public bool Loot(Inventory target, lootOption option)
    {
        if (test) Debug.Log("Inventory.Loot...");
        switch (option)
        {
            case lootOption.TakeAll:
                this.inventory.AddRange(target.inventory);
                target.inventory.Clear();
                return true;

            case lootOption.Select:
                if (test) Debug.Log("Select LootOption not implemented.");
                return false;

            case lootOption.Pickpocket:
                if (test) Debug.Log("Select LootOption not implemented.");
                return false;
            default:
                return false;
        }
    }
}
