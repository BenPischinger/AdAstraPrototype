using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviour : MonoBehaviour {

    public GameObject m_player;
    public float npc_attackDistance = 1.0f; // aus welcher Distance der NPC den Spieler angreifen kann
    public float rotSpeed = 1.0f;

    private NavMeshAgent npc_agent;
    private Animator npc_anim;
    private bool npc_isAttacking; // ob der NPC einen gerade angreift
    private bool npc_isTravelling; // bewegt sich der NPC auf einen zu

    

	// Use this for initialization
	void Start () {

        npc_agent = this.GetComponent<NavMeshAgent>();
        npc_anim = this.GetComponent<Animator>();

	    m_player = GameManager.Instance.Player;

        if(npc_agent == null) {
            Debug.Log("Das folgende Objekt hat kein NavMeshAgent Component" + gameObject.name);
            SetDestination();
        }

        else {

            SetDestination();
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(Vector3.Distance(m_player.transform.position, this.transform.position) <= npc_attackDistance) {
           
//            Debug.Log(Vector3.Distance(m_player.transform.position, this.transform.position));
            npc_anim.SetBool("isRunning", false);
            npc_anim.SetBool("isAttacking", true);
            npc_anim.SetBool("isIdle", false);
        }

        else{

            SetDestination();
        }

    }

    // Methode die den Zielpunkt festlegt
    private void SetDestination(){

        Vector3 lookAtGoal = new Vector3(m_player.transform.position.x, this.transform.position.y, m_player.transform.position.z);
        this.transform.LookAt(lookAtGoal);
        Vector3 targetVector = m_player.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(targetVector),
                                                    Time.deltaTime * rotSpeed);
        npc_agent.SetDestination(targetVector);
        npc_anim.SetBool("isIdle", false);
        npc_anim.SetBool("isRunning", true);
        npc_anim.SetBool("isAttacking", false);
        npc_isTravelling = true;
    }

}
