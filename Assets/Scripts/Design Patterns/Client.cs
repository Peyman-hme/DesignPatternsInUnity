using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private void Start()
    {
        GameController gameController = GameController.getInstance();
        
        gameController.setEnemyCounts(20);
        Debug.Log($"Counts of enemy is {gameController.getEnemyCounts()}");
        
        EnemyFactory zombieCreator = new ZombieFactory();
        EnemyFactory orcCreator = new OrcFactory();
        
        var zombie = zombieCreator.FactoryMethod();
        var orc = orcCreator.FactoryMethod();
        
        zombie.Introduce();
        orc.Introduce();
    }

    
    
}
