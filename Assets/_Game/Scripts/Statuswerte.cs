using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statuswerte {

    public int Strength { get; set; }
    public int HP { get; set; }
    public int Mana { get; set; }
    public int Defense { get; set; }

    public Statuswerte(int _Strength, int _HP, int _Mana, int _Defense)
    {
        this.Strength = _Strength;
        this.HP = _HP;
        this.Mana = _Mana;
        this.Defense = Defense;
    }

}
