using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnergyComponent))]
public abstract class SkillBase : MonoBehaviour
{
	[Tooltip("-1 for no cooldown")]
	public float Cooldown = 5;
	[Tooltip("-1 for no energy needed")]
	public int EnergyNeeded = 1;
	
	public float CurrentCooldown
	{
		get { return _currentCooldown; }
	}

	private EnergyComponent _energyComponent;
	private float _currentCooldown;

	// Use this for initialization
	public void Start ()
	{
		_energyComponent = gameObject.GetComponent<EnergyComponent>();
		_currentCooldown = 0;
	}

	public void Update()
	{
		if (_currentCooldown <= 0) return;
		_currentCooldown -= Time.deltaTime;
		if (_currentCooldown < 0)
		{
			_currentCooldown = 0;
		}
	}

	public bool Cast()
	{
		if (_currentCooldown > 0)
		{
			return false;
		}

		if (_energyComponent != null)
		{
			if (!_energyComponent.UseEnergy(EnergyNeeded))
			{
				return false;
			}
		}
		ActuallyCast();
		// ReSharper disable once CompareOfFloatsByEqualityOperator <-- this is like SupressWarnings for ReSharper/ Rider
		if (Cooldown != -1)
		{
			_currentCooldown = Cooldown;
		}
		return true;

	}

	protected abstract void ActuallyCast();
}
