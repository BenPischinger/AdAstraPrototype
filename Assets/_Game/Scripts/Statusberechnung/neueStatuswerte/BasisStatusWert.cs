using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/*using Newtonsoft;
using Newtonsoft.Json.Converters;
*/
[Obsolete("demokratie!")]
public class BasisStatusWert 
{

    public enum BasisStatusType {Strength, Agility, Endurance, HP,Ambrosia}
   //[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public BasisStatusType StatType { get; set; }
   // public List<StatBonus> BaseAdditives { get; set; }
    public int BaseValue { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set; }


    public BasisStatusWert(BasisStatusType statType, int baseValue, string statName,string statDescirption)
    {
        //this.BaseAdditives = new List<StatBonus>();
        this.StatType = statType;
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescirption;
    }
    /* [Newtonsoft.Json.JsonConstructor]
     public BaseStat(BaseStatType statType, int baseValue, string statName)
     {
         this.BaseAdditives = new List<StatBonus>();
         this.StatType = statType;
         this.BaseValue = baseValue;
         this.StatName = statName;
     }*/
    public void setBaseValue(int _bonusValue, BasisStatusWert _baseStat)
    {
        _baseStat.BaseValue += _bonusValue;
    }




}
