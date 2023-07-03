using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    private int enemyCounts;
    private static GameController _instance;
    private GameController()
    {

    }

    public static GameController getInstance()
    {
        if (_instance == null)
        {
            _instance = new GameController();
        }

        return _instance;
    }

    public void setEnemyCounts(int count)
    {
        enemyCounts = count;
    }

    public int getEnemyCounts()
    {
        return enemyCounts;
    }
}
