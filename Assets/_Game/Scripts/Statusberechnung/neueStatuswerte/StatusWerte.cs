using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Obsolete("demokratie!")]
[CreateAssetMenu(fileName = "StatusWerte", menuName = "Stats", order = 1)]
public class StatusWerte:ScriptableObject  {

    public StatusWerte(List<BasisStatusWert> list, int _strength, int _endurance, int _agility, int _hp,int  _ambrosia)
    {

        list.Add(new BasisStatusWert(BasisStatusWert.BasisStatusType.Strength, _strength, "Strength", "Stärke des Spielers"));
        list.Add(new BasisStatusWert(BasisStatusWert.BasisStatusType.Endurance, _endurance, "Endurance", "Ausdauer des Spielers"));
        list.Add(new BasisStatusWert(BasisStatusWert.BasisStatusType.Agility, _agility, "Agility", "Agilität des Spielers"));
        list.Add(new BasisStatusWert(BasisStatusWert.BasisStatusType.HP, _hp, "HP", "Lebenspunkte"));
        list.Add(new BasisStatusWert(BasisStatusWert.BasisStatusType.Ambrosia, _ambrosia, "Ambrosia", "Energie/Mana des Charackters"));

    }



    public int GetStatValue(string _name, List<BasisStatusWert> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].StatName == _name)
            {
                return list[i].BaseValue;
            }
        }
        return 0;
    }

    public string GetStatName(string _name, List<BasisStatusWert> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].StatName == _name)
            {
                return list[i].StatName;
            }
        }
        return null;
    }

    public string GetStatDescription(string _name, List<BasisStatusWert> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].StatName == _name)
            {
                return list[i].StatDescription;
            }
        }
        return null;
    }

    public void AddBonus(string _name, int _bonusValue, List<BasisStatusWert> list)
    {
        for (int i = 0; i < list.Count ; i++)
        {
            if (list[i].StatName == _name)
            {
                list[i].setBaseValue(_bonusValue, list[i]);
                break;
            }
        }
    }

}
