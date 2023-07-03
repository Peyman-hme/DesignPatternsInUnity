using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcFactory : EnemyFactory
{
    public override Enemy FactoryMethod()
    {
        return new Orc();
    }
}