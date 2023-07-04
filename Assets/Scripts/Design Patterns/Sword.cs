using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Equipment
{
    private int damage;

    public Sword(int durability, int cost, int damage) : base(durability, cost)
    {
        this.damage = damage;
    }

    public override string ToString()
    {
        return "Sword";
    }
}
