using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Collector
{
    private static System.Object target;
    private static System.Type type;

    public static void setType(System.Type newType)
    {
        Collector.type = newType;
    }

    public static System.Object CollectInventory(System.Object inventory)
    {
        if (inventory.GetType() == type)
        {
            target = inventory;
        }
        return target;
    }
}
