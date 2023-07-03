using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private void Start()
    {
        EnemyFactory zombieCreator = new ZombieFactory();
        EnemyFactory orcCreator = new OrcFactory();
        
        var zombie = zombieCreator.FactoryMethod();
        var orc = orcCreator.FactoryMethod();
        
        zombie.Introduce();
        orc.Introduce();
    }

    
    
}
