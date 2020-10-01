using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoeexplosion : MonoBehaviour {
    public bool aoenow = false;
    public GameObject explosion;
    private GameObject explosion2;
    private Vector3 position;
	// Use this for initialization
	void Start () {
        position = new Vector3(0.0f, -3f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
 
        if(aoenow)
        {
            if(explosion2 != null)
            {
                Destroy(explosion2);
            }
            aoenow = false;
            explosion2 = Instantiate(explosion, (transform.position-position), transform.rotation);
            
            
        }
		
	}
}
