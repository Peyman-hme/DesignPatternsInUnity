using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAdapter : Enemy
{
    private Warrior _warrior;

    public WarriorAdapter(Warrior warrior)
    {
        _warrior = warrior;
    }
    
    public override void Introduce()
    {
        Debug.Log("I'm an warrior");
    }
}
