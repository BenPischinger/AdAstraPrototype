using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJohn : MonoBehaviour {
    private Statuswerte charStat;
    public enum Gods { Zeus, Hades };



    private string descriptionStrength = "Stärke erhöht physischen Angriff";
    public string getDescriptionStrength()
    {
        return descriptionStrength;
    }


    private string descriptionHP = "HP gibt deine Healthpoint";
    public string getDescriptionHP()
    {
        return descriptionHP;
    }


    private string descriptionMana = "Mana ist eine Ressouce die für Angriffe genutzt wird";
    public string getDescriptionMana()
    {
        return descriptionMana;
    }


    private string descriptionDefense = "Verteidigung erhöht die Schadensreduktion";
    public string getDescriptionDefense()
    {
        return descriptionDefense;
    }

}
