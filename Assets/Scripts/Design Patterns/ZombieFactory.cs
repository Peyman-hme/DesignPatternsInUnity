using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFactory : EnemyFactory
{
    public override Enemy FactoryMethod()
    {
        return new Zombie();
    }
}
