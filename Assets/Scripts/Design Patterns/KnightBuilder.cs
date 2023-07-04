using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBuilder : WarriorBuilder
{
    private Warrior _warrior = new Warrior();

    public KnightBuilder()
    {
        this.Reset();
    }

    public void Reset()
    {
        this._warrior = new Warrior();
    }
    
    public void SetEquipment(Equipment equipment)
    {
        this._warrior.AddEquipment(equipment);
    }

    public void SetHealth(int health)
    {
        this._warrior.Health = health;
    }

    public void SetDamage(int damage)
    {
        this._warrior.Damage = damage;
    }

    public void SetTalent(Talent talent)
    {
        this._warrior.AddTalent(talent);
    }

    public Warrior GetWarrior()
    {
        Warrior warrior = this._warrior;
        this.Reset();
        return warrior;
    }
}
