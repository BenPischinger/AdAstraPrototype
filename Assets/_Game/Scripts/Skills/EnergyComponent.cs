using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class EnergyComponent : MonoBehaviour {

	public int MaxEnergy = 100;
	public int Energy = 100;
	public int RegenPerTick = 5;
	[Tooltip("Duration between energy regeneration ticks")]
	public float TickDuration = 1;

	private float _durationToNextTick;
	
	// Use this for initialization
	public void Start ()
	{
		_durationToNextTick = TickDuration;
	}
	
	// Update is called once per frame
	public void Update () {
		if (Energy >= MaxEnergy) return;
		
		_durationToNextTick -= Time.deltaTime;
		if (!(_durationToNextTick <= 0)) return;
		ReceiveEnergy(RegenPerTick);
		_durationToNextTick = TickDuration;
	}

	public void ReceiveEnergy(int amount)
	{
		Energy += amount;
		if (Energy > MaxEnergy)
		{
			Energy = MaxEnergy;
		}
	}
	
	// Drains energy even if there is less than <amount>
	public void DrainEnergy(int amount)
	{
		//make sure when energy was full a new tick will start in <TickDuration>
		if (Energy >= MaxEnergy)
		{
			_durationToNextTick = TickDuration;
		}
		Energy -= amount;
		if (Energy < 0)
		{
			Energy = 0;
		}
	}

	// Drains energy even only if there is enough
	public bool UseEnergy(int amount)
	{
		Debug.Log("Used energy: "+amount);
		//make sure when energy was full a new tick will start in <TickDuration>
		if (Energy >= MaxEnergy)
		{
			_durationToNextTick = TickDuration;
		}
		var newEnergy = Energy - amount;
		if (newEnergy < 0)
		{
			return false;
		}
		else
		{
			Energy = newEnergy;
			return true;
		}
	}
}
