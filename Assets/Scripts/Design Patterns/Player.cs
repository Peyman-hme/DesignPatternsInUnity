using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int health;
    public int Health => health;
    private List<PlayerSubscriber> _subscribers = new List<PlayerSubscriber>();

    public Player(int health)
    {
        this.health = health;
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
    }
    
    public void DecreaseHealth(int amount)
    {
        health -= amount;
        Notify();
    }

    public void Notify()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.update(this);
        }
    }

    public void Subscribe(PlayerSubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }
    
    public void Unsubscribe(PlayerSubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }


}
