using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenEventScript : MonoBehaviour {

    public Collider col;
    public Animator _animator;
    public GameObject dach;


    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            _animator.SetBool("open", true);
            dach.SetActive(true);
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            _animator.SetBool("open", false);
            dach.SetActive(false);
        }

    }
}
