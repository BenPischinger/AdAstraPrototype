using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemhit : MonoBehaviour {

    public ParticleSystem particle;
    public int HP;
	// Use this for initialization
	void Start () {
        HP = GetComponent<HealthSystem>().Health;
	}
	
	// Update is called once per frame
	void Update () {
        if (HP > GetComponent<HealthSystem>().Health)
        {
            particle.Play();
            HP = GetComponent<HealthSystem>().Health;
        }
        if(HP < GetComponent<HealthSystem>().Health)
        {
            particle.Stop();
            HP = GetComponent<HealthSystem>().Health;
        }
		
	}
}
