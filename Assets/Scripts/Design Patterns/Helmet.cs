using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : Equipment
{
    public Helmet(int durability, int cost) : base(durability, cost)
    {
    }
    
    public override string ToString()
    {
        return "Helmet";
    }
}
