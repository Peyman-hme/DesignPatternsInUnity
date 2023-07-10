using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientObserver : MonoBehaviour
{
    void Start()
    {
        Player player = new Player(100);
        Healer[] healers = new Healer[3];

        for (var i = 0; i < healers.Length; i++)
        {
            healers[i] = new Healer(5);
            player.Subscribe(healers[i]);
        }

        for (int i = 0; i < 3; i++)
        {
            Debug.Log($"The player health is: {player.Health}");
                    
            player.DecreaseHealth(20*(i+1));
                    
            Debug.Log($"Player damaged with amount {20*(i+1)}");
            Debug.Log($"Player healed with amount {5*(3-i)}");
            
            player.Unsubscribe(healers[i]);
            
            Debug.Log("One healer left the battlefield!");
        }
        
        Debug.Log($"The player health is: {player.Health}");
        
        

    }

}
