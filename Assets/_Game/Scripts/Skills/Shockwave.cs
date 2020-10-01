using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(CombatStats))]
public class Shockwave : SkillBase {
    public int Damage = 5;
    public float MaxRange = 4;
    public float ExplosionForce = 20;
    public GameObject Explosion;
    private GameObject _oldExplosion;
    private Transform _playerTransform;
    private CombatStats _combatStats;
    
    // Use this for initialization
    public new void Start() {
        base.Start(); //Call base Start!
        _playerTransform = GetComponent<Transform>();
        _combatStats = GetComponent<CombatStats>();
    }

    protected override void ActuallyCast() {
        var cols = Physics.OverlapSphere(_playerTransform.position, MaxRange, GameLayer.DefaultMask);
        foreach (var col in cols) {
            if (!col.CompareTag("Enemy")) {
                continue;
            }

            var healthSystem = col.gameObject.GetComponent<HealthSystem>();
            if (healthSystem != null) {
                healthSystem.Damage(_combatStats.CalculateDamage(Damage, col));
            }
           
        }
        if(_oldExplosion != null)
        {
            Destroy(_oldExplosion);
        }
        _oldExplosion = Instantiate(Explosion, transform.position, transform.rotation);
        var xForce = _oldExplosion.GetComponent<ExplosionPhysicsForce>();
        var particle = _oldExplosion.GetComponent<ParticleSystemMultiplier>();
        xForce.explosionForce = ExplosionForce;
        particle.multiplier = MaxRange / 10;
    }
}