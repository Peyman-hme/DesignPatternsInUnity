using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface WarriorBuilder
{
    void SetEquipment(Equipment equipment);

    void SetDamage(int damage);

    void SetHealth(int health);

    void SetTalent(Talent talent);

    void Reset();
    Warrior GetWarrior();

}
