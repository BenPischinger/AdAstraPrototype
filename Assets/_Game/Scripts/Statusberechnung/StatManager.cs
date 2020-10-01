using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("demokratie!")]
public class StatManager: MonoBehaviour
{
    public BasisStat Strength = new BasisStat(10, "Strength");
    public BasisStat Defense = new BasisStat(5, "Defense");
    public BasisStat Healthpoint = new BasisStat(100, "Healthpoint");


    public static List<BasisStat> charackterStatList = new List<BasisStat>();



    public void generateList( BasisStat hp, BasisStat def, BasisStat str)
    {
        charackterStatList.Add(hp);
        charackterStatList.Add(def);
        charackterStatList.Add(str);
    }

    public void addStasToList( BasisStat stat)
    {
        charackterStatList.Add(stat);
    }


    public void addBonus( BasisStat value)
    {
        foreach (BasisStat stat in charackterStatList)
        {
            if (stat.StatName == value.StatName)
            {
                stat.BaseValue += value.BaseValue;
            }
        }
    }

    public void removeBonus( BasisStat value)
    {
        foreach (BasisStat stat in charackterStatList)
        {
            if (stat.StatName == value.StatName)
            {
                stat.BaseValue -= value.BaseValue;
            }
        }
    }

    public BasisStat getStat( string value)
    {
        foreach (BasisStat stat in charackterStatList)
        {
            if (stat.StatName == value)
            {
                Debug.Log("Hab was gefunden");
                return stat;
            }
            Debug.Log("Habe nix gefunden");
            return null;
        }
        Debug.Log("Anderer Fehler");
        return null;
    }

    void Start()
    {
        Debug.Log(Strength.BaseValue);
        Debug.Log(Defense.BaseValue);
        Debug.Log(Healthpoint.BaseValue);

        generateList(Healthpoint,Defense,Strength);

    

    }
    void Update()
    {

    }

}
