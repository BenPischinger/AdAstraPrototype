using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DachFutschEventScript : MonoBehaviour {
    public GameObject dach;
    public Collider col;


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            
            dach.SetActive(false);
        }

    }
}
