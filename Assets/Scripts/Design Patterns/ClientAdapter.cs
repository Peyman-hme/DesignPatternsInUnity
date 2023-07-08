using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientAdapter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Warrior warrior = new Warrior();
        Zombie zombie = new Zombie();
        Orc orc = new Orc();

        List<Enemy> _allForces = new List<Enemy>();

        WarriorAdapter warriorAdapter = new WarriorAdapter(warrior);
        
        _allForces.Add(zombie);
        _allForces.Add(orc);
        _allForces.Add(warriorAdapter);
        
        foreach (var force in _allForces)
        {
            force.Introduce();
        }
    }

}
