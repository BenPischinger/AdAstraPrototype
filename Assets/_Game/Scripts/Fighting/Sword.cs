using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{

    public int Damage = 5;

    private Animator _animator;
    private CombatStats _combatStats;
    private List<GameObject> hitList;
    public Boolean IsEnemySword = false;

    void Start()
    {
        _animator =     GetComponent<Animator>();
        _combatStats = GetComponentInParent<CombatStats>();
    }

    public void PerformAttack()
    {
        _animator.SetBool("Attack",true);
    }

    public void PerfomAOEAttack()
    {
        _animator.SetTrigger("AOE");
    }

    /*Für die Angriffe:
     *  - Es Läuft so ab das Prefab was erstellt wurde und den Grundtyp der Waffe darstellt legt man Animationen an siehe Sword (Idle, swing ,aoe)
     *  - Jede Animation nutzt den Triger (" ... ") sobald dieser Trigger ausgelöst wird greift der Animator die Animation auf und spielt diese ab es ist wichtig das dabei der Collider als aus startet und beim schaden auf an springt
     *  - Der extraDmg Wert ist ein Multiplizierer für den Standatschaden der durch Waffe und Charstats ausgerechnet wird 
     *  - Sobald der Collider der Waffe den anderen Collider des Enemy´s durchschlägt wird dieser Schaden dem NPC abgezogen.
         */

    public void OnTriggerEnter(Collider col)
    {
        if ((!IsEnemySword && col.CompareTag("Enemy")) || IsEnemySword && col.CompareTag("Player"))
        {
            if (hitList.Contains(col.gameObject))
            {
                return;
            }
            hitList.Add(col.gameObject);
            HealthSystem otherHealth = col.GetComponent<HealthSystem>();
            if (otherHealth != null)
            {
                otherHealth.Damage(_combatStats.CalculateDamage(Damage, col));
            }
        }
    }

    void OnAnimationStart()
    {
        Debug.Log("START");
        hitList = new List<GameObject>();
    }

    void OnAnimationEnd()
    {

    }
}
