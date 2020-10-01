using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("demokratie!")]
public class BasisStat
{

    public int BaseValue { get; set; }
    public string StatName { get; set; }


    public BasisStat(int _baseValue, string _statName)
    {
        this.BaseValue = _baseValue;
        this.StatName = _statName;
    }
}
