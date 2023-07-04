using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipment
{
    public Armor(int durability, int cost) : base(durability, cost)
    {
    }
    
    public override string ToString()
    {
        return "Armor";
    }
}
