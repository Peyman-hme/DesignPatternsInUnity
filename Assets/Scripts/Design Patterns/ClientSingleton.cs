using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSingleton : MonoBehaviour
{
    void Start()
    {
        GameController gameController = GameController.getInstance();
        
        gameController.setEnemyCounts(20);
        Debug.Log($"Counts of enemy is {gameController.getEnemyCounts()}");
    }
}
