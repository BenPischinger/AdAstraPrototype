using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class HealSkill : SkillBase
{

	public int HealAmount = 10;

	private HealthSystem _healthSystem;
	
	// Use this for initialization
	public new void Start ()
	{
		base.Start(); //Call SkillBase
		this._healthSystem = GetComponent<HealthSystem>();
		if (_healthSystem == null)
		{
			Debug.LogWarning("HealSkill exists with no HealthSystem attached");
		}
	}
	
	
	protected override void ActuallyCast()
	{
		if (_healthSystem != null)
		{
			_healthSystem.Heal(HealAmount);
		}
		else
		{
			Debug.LogWarning("HealSkill used with no HealthSystem attached");
		}
	}
}
