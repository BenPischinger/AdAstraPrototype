using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {
/* Schnittstelle für Interactive System siehe NPC Script
    eignet sich unteranderem auch als Schnittstelle für Interactive Objecte bspw. Waffen zum einsammeln oder ähnliches
    jedes Object was Interactable sein soll muss mit einem 2ten Collider ausgestattet sein der getriggert ist und der 
    an dem jeweiligen Object mit einer größeren (im bezug auf den eigentlichen Collider) radius ausgestattet ist
         */

    public virtual void Interact()
    {
        Debug.Log("Interact with the Base Class");
    }
}
