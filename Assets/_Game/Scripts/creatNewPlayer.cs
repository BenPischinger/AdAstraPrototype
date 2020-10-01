using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatNewPlayer : MonoBehaviour {
    public Statuswerte charStat;


    void Start()
    {
        charStat = new Statuswerte(10, 10, 10, 10);

    }


}
