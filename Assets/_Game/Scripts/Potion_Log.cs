using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_Log : MonoBehaviour, IConsume {
    public void Consume()//You Drink a Potion with out stat modifier
    {
        Debug.Log("You Drink a Potion with out stat modifier");
    }

    public void Consume(CharackterStats stats)//Dring an other potion with stats modifier
    {
        Debug.Log("Dring an other potion with stats modifier");
    }

}
