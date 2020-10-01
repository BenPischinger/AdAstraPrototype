using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "VorbereitungsRaum/Create Skill")]							//Menu tool um neue Skills zu erstellen
public class Skills : ScriptableObject
{
    public string Description;
    public Sprite Icon;
    public int LevelNeeded;
    public int XPNeeded;

    public bool equiped;
    public bool locked;

    public PlayerStats Spieler;
    public SkillDisplay SD;
    public Skills neighbor1;
    public Skills neighbor2;

    public List<PlayerAttribute> AffectedAttributes = new List<PlayerAttribute>(); 		//Liste von Attributen die von der Skill beeinflusst werden 

	public void SetValues(GameObject SkillDisplayObject, PlayerStats Player)            //wird von SkillDisplay aufgerufen, weißt Canvas Componente die Skill Information zu
    {
		Spieler = Player.GetComponent<PlayerStats>();
        if (SkillDisplayObject)                                                         //error handling
        {
            SD = SkillDisplayObject.GetComponent<SkillDisplay>();
            SD.skillName.text = name;
            if (SD.skillDescription)
                SD.skillDescription.text = Description;

            if (SD.skillIcon)
                SD.skillIcon.sprite = Icon;

            if (SD.skillLevel)
                SD.skillLevel.text = LevelNeeded.ToString();
            /*
            if (SD.skillXPNeeded)
                SD.skillXPNeeded.text = XPNeeded.ToString() + "XP";*/
            SD.skillXPNeeded.gameObject.SetActive(false);

            if (SD.skillAttribute)
                SD.skillAttribute.text = AffectedAttributes[0].attribute.ToString();

            if (SD.skillAttrAmount)
                SD.skillAttrAmount.text = "+" + AffectedAttributes[0].amount.ToString();
        }
    }

    public bool CanGetSkill(PlayerStats Player)                                     //überprüft ob Spieler Skill kriegen kann
    {
        if (Player.PlayerLevel < LevelNeeded)
            return false;

        if (Player.PlayerXP < XPNeeded)
            return false;

        return true;
    }

    public bool HasSkill(PlayerStats Player)                                        //überprüft ob Spieler Skill schon hat
    {
        List<Skills>.Enumerator skills = Player.PlayerSkills.GetEnumerator();       //geht durch alle Skills die Spieler gerade hat
        while (skills.MoveNext())                                                   //geht weiter bis Liste zuende ist
        {
            var CurrSkill = skills.Current;
            if (CurrSkill.name == this.name)
            {
                return true;
            }
        }
        return false;
    }

    public bool UnlockSkill(PlayerStats Player)
    {
        int i = 0;

        List<PlayerAttribute>.Enumerator attributes = AffectedAttributes.GetEnumerator();                           //Liste von Attributen die von Skill beeinflusst werden
        while (attributes.MoveNext())
        {
            List<PlayerAttribute>.Enumerator PlayerAttr = Player.Attributes.GetEnumerator();                        //Liste von Attributen die der Spieler hat
            while (PlayerAttr.MoveNext())
            {
                if (attributes.Current.attribute.name.ToString() == PlayerAttr.Current.attribute.name.ToString())   //überprüft ob Spieler über das Attribut verfügt
                {
					Spieler.SetValue(Spieler, attributes.Current.attribute.name.ToString(), attributes.Current.amount);
                    //PlayerAttr.Current.amount += attributes.Current.amount;                                         
                    i++;                                                                                            //makiert das ein Attribute geupdated wurde
                    equiped = true;
                }
            }
            if (i > 0)
            {
                Player.PlayerXP -= this.XPNeeded;                                                                   //zieht benötigtes XP ab
                Player.PlayerSkills.Add(this);                                                                      //fügt Skill dem Spieler zu
                return true;                                                                                        //Spieler hat das Skill erlangt
            }
        }
        return false;                                                                                               //Spieler hat den Skill nicht erlangt
    }

    public bool UnequipSkill(PlayerStats Player)
    {
        int i = 0;
        List<PlayerAttribute>.Enumerator attributes = AffectedAttributes.GetEnumerator();
        while (attributes.MoveNext())
        {
            List<PlayerAttribute>.Enumerator PlayerAttr = Player.Attributes.GetEnumerator();
            while (PlayerAttr.MoveNext())
            {
                if (attributes.Current.attribute.name.ToString() == PlayerAttr.Current.attribute.name.ToString())
                {
					Spieler.SetValue(Spieler, attributes.Current.attribute.name.ToString(), -attributes.Current.amount);
					//PlayerAttr.Current.amount -= attributes.Current.amount;
                    i++;
                    equiped = false;
                }
            }
            if (i > 0)
            {
                Player.PlayerXP += this.XPNeeded;    
                Player.PlayerSkills.Remove(this);    
                return true;   
            }
        }
        return false;
    }

    public bool Used()
    {
        return equiped;
    }

	void OnEnable()
	{
		equiped = false;
		locked = false;
	}

}

//Scriptable Object führen Start Methode nur einmal beim erzeugen aus. Awake Methode jedes mal wenn du Unity neu öffnest und sie inistanziert werden, also OnEnable