using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteractionSystem: MonoBehaviour {

    private GameObject triggeringNpc;
    private bool triggering;

    void Update()
    {
        if(triggering&&Input.GetKey(KeyCode.E)) // if the Player Object the Npc hits this should be happened
        {
            triggeringNpc.GetComponent<Interactable>().Interact();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            triggering = true;
            triggeringNpc = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "NPC")
        {
            triggering = false;
            triggeringNpc = null;
        }
    }

}
