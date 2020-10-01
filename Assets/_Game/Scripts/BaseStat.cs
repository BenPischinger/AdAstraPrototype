using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft;
using Newtonsoft.Json.Converters;

public class BaseStat 
{

    public enum BaseStatType {Strength, Agility, Endurance, HP}
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public BaseStatType StatType { get; set; }
    public List<StatBonus> BaseAdditives { get; set; }
    public int BaseValue { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set; }


    public BaseStat(int baseValue, string statName,string statDescirption)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescirption;
    }
    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(BaseStatType statType, int baseValue, string statName)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.StatType = statType;
        this.BaseValue = baseValue;
        this.StatName = statName;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add(BaseAdditives.Find(x => x.BonusValue == statBonus.BonusValue));
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Remove(statBonus);
    }

    public int GetCalculatedStatValue()
    { 
        this.FinalValue = 0;
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
        FinalValue += BaseValue;
        return FinalValue;
    }



}
