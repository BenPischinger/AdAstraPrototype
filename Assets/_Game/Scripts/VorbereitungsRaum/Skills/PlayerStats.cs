using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [Header("Main Player Stats")]
    public string PlayerName;
    private int health;
    private int endurance;
    private int fighting;
    private int reason;
    private int strength;
    private int agility;

    CharackterStats CS;

    //Listener    
    public delegate void XpListener();
    public event XpListener OnXPChange;

    public delegate void LevelChangeListener();
    public event LevelChangeListener OnLevelChange;

    public delegate void StatsListener();
    public event StatsListener OnStatsChange;

    [SerializeField]
    private int m_PlayerXP = 0;
    public int PlayerXP
    {
        get { return m_PlayerXP; }
        set
        {
            m_PlayerXP = value;

            if (OnXPChange != null)                                             // null heißt kein listener angemeldet
                OnXPChange();                                                   // führ alle Methoden aus die an onXPChange hängen (SkillDisplay zeile 24)
        }
    }

    [SerializeField]
    private int m_PlayerLevel = 1;
    public int PlayerLevel
    {
        get { return m_PlayerLevel; }
        set
        {
            m_PlayerLevel = value;

            if (OnLevelChange != null)                                          // null heißt kein listener angemeldet
                OnLevelChange();                                                // führ alle Methoden aus die an onLevelChange hängen (SkillDisplay zeile 25)
        }
    }

    [Header("Attribute")]
    public List<PlayerAttribute> Attributes = new List<PlayerAttribute>();      //Liste von zugewiesenen Attributen

    [Header("Player Skills")]
    public List<Skills> PlayerSkills = new List<Skills>();                      //Liste von Skills 

	[Header("GötterSkills")]
    public List<GSkills> GötterSkills = new List<GSkills>();                      //Liste von Götter Skills 

    private void Start()
    {
        CS = GetComponent<CharackterStats>();
        UpdateStats();
    }

    public int GetValue(PlayerStats Player, string attribute)
    {
        List<PlayerAttribute>.Enumerator PlayerAttr = Player.Attributes.GetEnumerator();
        while (PlayerAttr.MoveNext())
        {
            if (PlayerAttr.Current.attribute.name.ToString() == attribute)
            {
                return PlayerAttr.Current.amount;
            }
        }
        return 0;
    }

    public int GetValue(PlayerStats Player, int att)    // Dann muss die Reihenfolge der Attribute festgelegt sein 0 = Health, 1 = Endurance
    {
        return Player.Attributes[att].amount;
    }

    public void SetValue(PlayerStats Player, string attribute, int value)
    {
        List<PlayerAttribute>.Enumerator PlayerAttr = Player.Attributes.GetEnumerator();
        while (PlayerAttr.MoveNext())
        {
            if (PlayerAttr.Current.attribute.name.ToString() == attribute)
            {
                PlayerAttr.Current.amount += value;
                //OnStatsChange();
                //UpdateStats();
            }
        }
    }

    public void UpdateStats()
    {
        /*
        health = Attributes[0].amount;
        endurance = Attributes[1].amount;
        fighting = Attributes[2].amount;
        reason = Attributes[3].amount;
        strength = Attributes[4].amount;
        agility = Attributes[5].amount;
		/*
        Debug.Log("Health " + health);
        Debug.Log("Endurance " + endurance);
        Debug.Log("Fighting " + fighting);
        Debug.Log("Strength " + strength);
        Debug.Log("Reason " + reason);
        Debug.Log("Agility " + agility);
        */
        /*
        CS.SetStat(BaseStat.BaseStatType.Strength, strength);
        CS.SetStat(BaseStat.BaseStatType.Agility, agility);
        CS.SetStat(BaseStat.BaseStatType.Endurance, endurance);
        CS.SetStat(BaseStat.BaseStatType.HP, health);

        Debug.Log(CS.GetStat(BaseStat.BaseStatType.Strength));
        Debug.Log(CS.GetStat(BaseStat.BaseStatType.Agility));
        Debug.Log(CS.GetStat(BaseStat.BaseStatType.Endurance));
        Debug.Log(CS.GetStat(BaseStat.BaseStatType.HP));
        */
    }

}





