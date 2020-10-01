using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class WorldInteraction : MonoBehaviour
{
   /* NavMeshAgent playerAgent; // der Agent erlaubt es dem Pfad (Agent Pfad) zu verfolgen

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) //Hierbei wird festgelegt das der Spieler auf ein Gameobjekt clicked und nicht in einem UI Element also Menü oder ähnlichem
            GetInteraction();

    }
    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition); 
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;

            if (interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().MovetoInteraction(playerAgent); // das Interactable ist eine Methode aus dem Interactable Objekt egal ob NPC oder Item daher können wir von dieser Schnittstelle auf die Objekte zugreifen
            }
            else
            {
                playerAgent.stoppingDistance = 0F;
                playerAgent.destination = interactionInfo.point;
            }
        }
    }*/

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
