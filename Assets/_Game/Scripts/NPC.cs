using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
  
	public string[] text;
    public string npcName;

    public override void Interact()
    {/* wird über Interactable aufgerufen und greift dann auf das Dialogue System zu braucht den Dialogue und den Namen des NPC´s */
       
        DialogueSystem.Instance.AddNewDialogue(text, npcName);
    }
	
}
