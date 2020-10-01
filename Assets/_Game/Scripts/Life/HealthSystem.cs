using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {
    public int Health = 20;
    public int MaxHealth = 20;
    public float TickDuration = 3;
    public int RegenPerTick = 1;
    private float _durationToNextTick;


    // Use this for initialization
    void Start() {
    }
 
    // Update is called once per frame
    void Update() {
        if (Health >= MaxHealth) return;

        _durationToNextTick -= Time.deltaTime;
        if (!(_durationToNextTick <= 0)) return;
        Heal(RegenPerTick);
        _durationToNextTick = TickDuration;
    }

    private void LateUpdate() {
        if (Health <= 0) {
            DropOnDeath dropOnDeath = this.GetComponent<DropOnDeath>();
            if (dropOnDeath != null) {
                dropOnDeath.drop();
            }

            if (gameObject.CompareTag("Player")) {
                Health = MaxHealth; //TODO replace with reset function
                GameManager.Instance.EndRound();
                return;
            }
            Destroy(this.gameObject);
        }
    }

    public void Damage(int value) {
        if (value < 0) {
            throw new ArgumentException("only positive values allowed");
        }

        if (Health >= MaxHealth) //make sure when energy was full a new tick will start in <TickDuration>
        {
            _durationToNextTick = TickDuration;
        }

        Health -= value;
        if (Health <= 0) {
            GameManager.Instance.invokeDeathEvent(this.gameObject);
        }
    }

    public void Heal(int value) {
        if (value < 0) {
            throw new ArgumentException("only positive values allowed");
        }

        Health += value;
        if (Health > MaxHealth) {
            Health = MaxHealth;
        }
    }

    public int GetHealth() {
        return Health;
    }
}