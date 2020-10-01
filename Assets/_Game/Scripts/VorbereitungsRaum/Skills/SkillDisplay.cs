using UnityEngine.UI;
using UnityEngine;

public class SkillDisplay : MonoBehaviour
{
    public Skills skill;
    public Text skillName;
    public Text skillDescription;
    public Image skillIcon;
    public Text skillLevel;
    public Text skillXPNeeded;
    public Text skillAttribute;
    public Text skillAttrAmount;

    [SerializeField]
    private PlayerStats m_PlayerHandler;

    void Start()	//passiert wenn man den Skilltree canvas öffnet
    {
        m_PlayerHandler.OnXPChange += ShowSkills;                                               //listener Xp anmelden
        m_PlayerHandler.OnLevelChange += ShowSkills;                                            //listener Level anmelden

        if (skill)
			skill.SetValues(this.gameObject, m_PlayerHandler);                                  //Weißt den Skill den Playerhandler und die Canvas componente zu
		
		ShowSkills ();
    }

    public void ShowSkills()
    {
        if (m_PlayerHandler && skill && skill.HasSkill(m_PlayerHandler))                             //hat Spieler den Skill schon?
        {
            TurnOnSkillIcon();                                                                  
        }
        else if (m_PlayerHandler && skill && skill.CanGetSkill(m_PlayerHandler) && !skill.locked)     //kann der Spieler den Skill erlangen?
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
        if (!skill.Used())
        {
            if (skill.UnlockSkill(m_PlayerHandler))                                                 //schalte Skill frei
            {
                TurnOnSkillIcon();                                                                  //zeig dies im Skilltree an
                skill.neighbor1.locked = true;
                skill.neighbor2.locked = true;
                skill.neighbor1.SD.ShowSkills();
                skill.neighbor2.SD.ShowSkills();
            }
        }
        else
        {
            if (skill.UnequipSkill(m_PlayerHandler))                                                 
            {
                AvailableSkillIcon();
                skill.neighbor1.locked = false;
                skill.neighbor2.locked = false;
                skill.neighbor1.SD.ShowSkills();
                skill.neighbor2.SD.ShowSkills();
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

