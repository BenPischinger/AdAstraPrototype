using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "VorbereitungsRaum/Create GötterSkill")]							//Menu tool um neue Skills zu erstellen
public class GSkills : ScriptableObject
{
    public string Description;
    public Sprite Icon;

    public bool equiped;
    public bool locked;

    public PlayerStats Spieler;
    public GSkillDisplay GSD;
    public GSkills neighbor1;
    public GSkills neighbor2;


	public void SetValues(GameObject GSkillDisplayObject, PlayerStats Player)            //wird von SkillDisplay aufgerufen, weißt Canvas Componente die Skill Information zu
    {
		Spieler = Player.GetComponent<PlayerStats>();
        if (GSkillDisplayObject)                                                         //error handling
        {
            GSD = GSkillDisplayObject.GetComponent<GSkillDisplay>();

            GSD.skillName.text = name;
            if (GSD.skillDescription)
                GSD.skillDescription.text = Description;

            if (GSD.skillIcon)
                GSD.skillIcon.sprite = Icon;
        }
    }

    public bool HasSkill(PlayerStats Player)                                        //überprüft ob Spieler Skill schon hat
    {
        List<GSkills>.Enumerator gskills = Player.GötterSkills.GetEnumerator();       //geht durch alle Skills die Spieler gerade hat
        while (gskills.MoveNext())                                                   //geht weiter bis Liste zuende ist
        {
            var CurrSkill = gskills.Current;
            if (CurrSkill.name == this.name)
            {
                return true;
            }
        }
        return false;
    }

    public bool UnlockSkill(PlayerStats Player)
    {
		Player.GötterSkills.Add(this);     
		equiped = true;
		return true;
    }

    public bool UnequipSkill(PlayerStats Player)
    {
		Player.GötterSkills.Remove(this);  
		equiped = false;
		return true;
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