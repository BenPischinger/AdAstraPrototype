using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("demokratie!")]
public class My_Player : MonoBehaviour
{
    public List<BasisStatusWert> statList = new List<BasisStatusWert>();
    public StatusWerte my_Stats;
    public List<BaseCurrency> currencyList = new List<BaseCurrency>();

    // Use this for initialization
    void Awake()
    {
        my_Stats = new StatusWerte(statList, 10, 5, 12, 100,100);
        currencyList.Add(new BaseCurrency(0, "EXP", "Erfahrungspunkte"));
        currencyList.Add(new BaseCurrency(0, "Money", "Money for Weapon"));
        currencyList.Add(new BaseCurrency(0, "CraftingMat1", "For Crafting"));
        currencyList.Add(new BaseCurrency(0, "CraftingMat2", "For Crafting"));

    }


    public int GetCurrencyValue(string _name, List<BaseCurrency> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].CurrencyName == _name)
            {
                return list[i].BaseValue;
            }
        }
        return 0;
    }

    public string GetCurrencyName(string _name, List<BaseCurrency> list)
    {
        Debug.LogError("Fehler?");
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].CurrencyName == _name)
            {
                return list[i].CurrencyName;
            }
        }
        return null;
    }

    public string GetCurrencyDescription(string _name, List<BaseCurrency> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].CurrencyName == _name)
            {
                return list[i].CurrencyDescription;
            }
        }
        return null;
    }

    public void AddCurrencyBonus(string _name, int _bonusValue, List<BaseCurrency> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].CurrencyName == _name)
            {
                list[i].setBaseValue(_bonusValue,list[i]);
                break;
            }
        }
    }

}
