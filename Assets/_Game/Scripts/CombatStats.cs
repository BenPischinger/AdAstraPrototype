using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CombatStats : MonoBehaviour
{
    [Tooltip("Damage reduction in percent")]
    public int Def = 10;
	public int Atk = 1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Min 1
	public int CalculateDamage(int weaponDamage, Collider other)
	{
		var otherCombatStats = other.GetComponent<CombatStats>();
		if (otherCombatStats == null)
		{
			return weaponDamage + Atk;
		}
		return (int)Math.Max((weaponDamage+Atk * ((100-otherCombatStats.Def)/100f)),1);
	}
}
