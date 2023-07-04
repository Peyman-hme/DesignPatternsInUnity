using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    protected int durability;
    protected int cost;

    public Equipment(int durability, int cost)
    {
        this.durability = durability;
        this.cost = cost;
    }
}
