using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{

    private GameObject triggeringNpc;
    private bool triggering;

    void Update()
    {
        if (triggering && Input.GetKeyDown(KeyCode.E)) // if the Player Object the Npc hits this should be happened
			//Changed from GetKey to GetKeyDown so event is only triggered once
        {
            triggeringNpc.GetComponent<Interactable>().Interact();
            GetComponentInParent<PlayerController>().enabled = !GetComponentInParent<PlayerController>().enabled;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC"|| other.tag == "InteractableObject")
        {
            triggering = true;
            triggeringNpc = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC" || other.tag == "InteractableObject")
        {
            triggering = false;
            triggeringNpc = null;
        }
    }

}