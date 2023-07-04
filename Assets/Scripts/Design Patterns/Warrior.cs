using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior
{
    private int health;
    private int damage;
    private List<Equipment> _equipments = new List<Equipment>();
    private List<Talent> _talents = new List<Talent>();

    public void AddEquipment(Equipment equipment)
    {
        _equipments.Add(equipment);
    }
    
    public void AddTalent(Talent talent)
    {
        _talents.Add(talent);
    }

    public List<Talent> Talents
    {
        get => _talents;
        set => _talents = value;
    }

    public List<Equipment> Equipments
    {
        get => _equipments;
        set => _equipments = value;
    }

    public int Health
    {
        get => health;
        set => health = value;
    }

    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    public string GetAttributes()
    {
        string attributes = "Health: " + health.ToString() + " Damage: "+damage.ToString();

        if (_equipments.Count > 0)
        {
            attributes += "\n Equipments: ";
        }

        foreach (var equipment in _equipments)
        {
            attributes += equipment.ToString()+", ";
        }

        if (_talents.Count > 0)
        {
           attributes += " Talents: ";
        }
        
        foreach (var talent in _talents)
        {
            attributes += talent.ToString()+", ";
        }

        return attributes;
    }
}
