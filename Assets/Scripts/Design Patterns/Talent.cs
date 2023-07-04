using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Talent
{
    protected int _cooldown;

    protected Talent(int cooldown)
    {
        _cooldown = cooldown;
    }

    public abstract void DoAction(Warrior warrior);
    
    
}
