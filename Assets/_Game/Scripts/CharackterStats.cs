using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharackterStats : MonoBehaviour {
    /*Statuswerte vom Player können über charakterStat.stats[Gewünschter Wert].baseValue/finalValue abgegriffen werden
     */
    public List<BaseStat> stats = new List<BaseStat>();

    public CharackterStats()
    {
        stats = new List<BaseStat>() {
            new BaseStat(BaseStat.BaseStatType.Strength, 0, "Strength"),
            new BaseStat(BaseStat.BaseStatType.Endurance, 0, "Endurance"),
            new BaseStat(BaseStat.BaseStatType.Agility, 0, "Agility"),
            new BaseStat(BaseStat.BaseStatType.HP, 0, "HP")
        };
    }

    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        return this.stats.Find(x => x.StatType == stat);
    }

    public void SetStat(BaseStat.BaseStatType stat, int value)
    {
        List<BaseStat>.Enumerator list = stats.GetEnumerator();
        while(list.MoveNext())
        {
            if (list.Current.StatType == stat)
            {
                list.Current.BaseValue += value;
            }
        }
    }


    public void AddStatBonus(List<BaseStat>statBonuses)
    {
        foreach(BaseStat statBonus in statBonuses)
        {
            //per foreach über die Stats im BaseStat (CharakterStats) laufen und die Namen filtern danach den neuen Wert hinzufügen!addStatBonus...
            GetStat(statBonus.StatType).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            GetStat(statBonus.StatType).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}
