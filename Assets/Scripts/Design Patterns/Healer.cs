using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : PlayerSubscriber
{
    private int healRate;

    public Healer(int healRate)
    {
        this.healRate = healRate;
    }

    public void update(Player player)
    {
        player.IncreaseHealth(healRate*1);
    }
    
}
