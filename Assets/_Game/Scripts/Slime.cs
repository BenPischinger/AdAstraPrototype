using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemey
{
    public float currenthealth, power, toughness;
    public float maxhealth;

    private CharackterStats charackterStats;

    void Start()
    {
        charackterStats = new CharackterStats();
        currenthealth = maxhealth;
    }
    public void PerformAttack()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currenthealth -= amount;
        if(currenthealth <=0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
