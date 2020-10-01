using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
	public class PlayerAttribute			//Spieler's Attribut (+Attribute Wert)
    {
        public Attribute attribute;
        public int amount;

        public PlayerAttribute(Attribute attribute, int amount)
        {
            this.attribute = attribute;
            this.amount = amount;
        }
    }
