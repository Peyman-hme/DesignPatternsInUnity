using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorDirector
{

    public Warrior MakeKnight(WarriorBuilder builder)
    {
        builder.SetDamage(10);
        builder.SetHealth(150);
        builder.SetEquipment(new Sword(20,20,5));
        builder.SetEquipment(new Armor(50,30));
        builder.SetEquipment(new Helmet(25,15));
        return builder.GetWarrior();
    }
    
    public Warrior MakeAngryKnight(WarriorBuilder builder)
    {
        builder.SetDamage(10);
        builder.SetHealth(120);
        builder.SetEquipment(new Sword(15,15,5));
        builder.SetEquipment(new Armor(50,30));
        builder.SetTalent(new RageTalent(15,2));
        return builder.GetWarrior();
    }
    
    public Warrior MakeDarkKnight(WarriorBuilder builder)
    {
        builder.SetDamage(50);
        builder.SetHealth(500);
        builder.SetEquipment(new Sword(30,20,5));
        builder.SetEquipment(new Armor(100,40));
        builder.SetEquipment(new Helmet(20,10));
        return builder.GetWarrior();
    }
}
