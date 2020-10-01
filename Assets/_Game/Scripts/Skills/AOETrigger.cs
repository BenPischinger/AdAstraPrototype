using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AOETrigger : MonoBehaviour
{
	private int _damage;
	private float _maxRange;
	private float _expansion;
	private CombatStats _combatStats;

	private SphereCollider _collider;
	// Use this for initialization
	void Start ()
	{
		_collider = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_collider.radius < _maxRange)
		{
			_collider.radius = Math.Min(_collider.radius + _expansion*Time.deltaTime, _maxRange);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void SetData(int damage, float maxRange, float expansion, CombatStats combatStats)
	{
		_damage = damage;
		_maxRange = maxRange;
		_expansion = expansion;
		_combatStats = combatStats;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Enemy"))
		{
			HealthSystem otherHealth = other.GetComponent<HealthSystem>();
			if (otherHealth != null)
			{
				otherHealth.Damage(_combatStats.CalculateDamage(_damage, other));
			}
		}
	}
}
