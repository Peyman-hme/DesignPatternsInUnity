using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    public override void Introduce()
    {
        Debug.Log("I'm a zombie");
    }
}
