using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CharackterStats charackterStats;

    void Start()
    {
        charackterStats = new CharackterStats();  
    }
}
