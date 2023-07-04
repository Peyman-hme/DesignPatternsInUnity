using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageTalent : Talent
{
    private float _rageRate;
    
    public RageTalent(int cooldown, float rageRate) : base(cooldown)
    {
        this._rageRate = rageRate;
    }

    public override void DoAction(Warrior warrior)
    {
        warrior.Damage =(int)(warrior.Damage*_rageRate);
    }

    public override string ToString()
    {
        return "Rage";
    }
}
