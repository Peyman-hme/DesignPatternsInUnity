using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderClient : MonoBehaviour
{
    void Start()
    {
        WarriorBuilder warriorBuilder = new KnightBuilder();
        WarriorDirector warriorDirector = new WarriorDirector();

        Warrior knight = warriorDirector.MakeKnight(warriorBuilder);
        Warrior angryKnight = warriorDirector.MakeAngryKnight(warriorBuilder);
        Warrior darkKnight = warriorDirector.MakeDarkKnight(warriorBuilder);
        
        Debug.Log(knight.GetAttributes());
        Debug.Log(angryKnight.GetAttributes());
        Debug.Log(darkKnight.GetAttributes());
    }
    
}
