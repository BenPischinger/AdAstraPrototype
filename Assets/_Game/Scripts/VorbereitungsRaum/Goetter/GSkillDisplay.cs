using UnityEngine.UI;
using UnityEngine;

public class GSkillDisplay : MonoBehaviour
{
    public GSkills gskill;
    public Text skillName;
    public Text skillDescription;
    public Image skillIcon;

    [SerializeField]
    private PlayerStats m_PlayerHandler;

    void Start()	//passiert wenn man den Skilltree canvas öffnet
    {
        m_PlayerHandler.OnXPChange += ShowSkills;                                               //listener Xp anmelden
        m_PlayerHandler.OnLevelChange += ShowSkills;                                            //listener Level anmelden

        if (gskill)
			gskill.SetValues(this.gameObject, m_PlayerHandler);                                  //Weißt den Skill den Playerhandler und die Canvas componente zu
		
		ShowSkills ();
    }

    void OnEnable()
    {
        ShowSkills();
    }

    public void ShowSkills()
    {
        if (m_PlayerHandler && gskill && gskill.HasSkill(m_PlayerHandler))                             //hat Spieler den Skill schon?
        {
            TurnOnSkillIcon();                                                                  
        }
        else if (m_PlayerHandler && gskill && !gskill.locked)     //kann der Spieler den Skill erlangen?
        {
            AvailableSkillIcon();
        }
        else
        {
            TurnOffSkillIcon();                                                                 
        }
    }
    //GetSkill wird aufgerufen wenn auf dem Canvas geklickt wird
    public void GetSkill()                                                                      
    {
        if(gskill == null)
        {
            Debug.Log("Leer");
        }

        if (!gskill.Used())
        {
            if (gskill.UnlockSkill(m_PlayerHandler))                                                 //schalte Skill frei
            {
                TurnOnSkillIcon();                                                                  //zeig dies im Skilltree an
                gskill.neighbor1.locked = true;
                gskill.neighbor2.locked = true;
                //gskill.neighbor1.GSD.ShowSkills();
                //gskill.neighbor2.GSD.ShowSkills();
            }
        }
        else
        {
            if (gskill.UnequipSkill(m_PlayerHandler))                                                 
            {
                AvailableSkillIcon();
                gskill.neighbor1.locked = false;
                gskill.neighbor2.locked = false;
                //gskill.neighbor1.GSD.ShowSkills();
                //gskill.neighbor2.GSD.ShowSkills();
            }
        }
    }
    //Drei Zustände Ausgewählt, Verfügbar, Nicht verfügbar
    public void TurnOnSkillIcon()
    { 
        this.GetComponent<Button>().interactable = true;
        this.transform.Find("IconParent").Find("Available").gameObject.SetActive(false);
        this.transform.Find("IconParent").Find("Disabled").gameObject.SetActive(false);
    }

    public void TurnOffSkillIcon()																
    {
        this.GetComponent<Button>().interactable = false;
        this.transform.Find("IconParent").Find("Available").gameObject.SetActive(true);
        this.transform.Find("IconParent").Find("Disabled").gameObject.SetActive(true);
    }

    public void AvailableSkillIcon()
    {
        this.GetComponent<Button>().interactable = true;
        this.transform.Find("IconParent").Find("Available").gameObject.SetActive(true);
        this.transform.Find("IconParent").Find("Disabled").gameObject.SetActive(false);
    }
}

