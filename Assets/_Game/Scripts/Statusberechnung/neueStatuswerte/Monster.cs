using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("demokratie!")]
public class Monster : MonoBehaviour {
    public List<BasisStatusWert> monster1List = new List<BasisStatusWert>();
    public List<BasisStatusWert> monster2List = new List<BasisStatusWert>();
    public List<BasisStatusWert> monster3List = new List<BasisStatusWert>();
    public StatusWerte monster1_stat;
    public StatusWerte monster2_stat;
    public StatusWerte monster3_stat;

    // Use this for initialization
    void Awake () {
        monster1_stat = new StatusWerte(monster1List, 2, 10, 3, 40,100);
        monster2_stat = new StatusWerte(monster2List, 10, 5, 12, 100,100);
        monster3_stat = new StatusWerte(monster3List, 10, 5, 12, 100,100);
    }
	
}
