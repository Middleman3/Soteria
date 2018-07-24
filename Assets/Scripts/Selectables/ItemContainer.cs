using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : Selectable {
    private bool test = true;

    private List<Item> items;

    //Constructor
    public ItemContainer ()
    {
        actions[0] = new Loot.Instance();
    }

    public override void UpdateActions(GameObject player)
    {
        if (test) Debug.Log("ItemContainer Constructor...");
        //throw new System.NotImplementedException();
    }
}
