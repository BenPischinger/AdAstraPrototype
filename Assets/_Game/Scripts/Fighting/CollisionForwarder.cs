using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionForwarder : MonoBehaviour {

	public Sword Sword;

	void OnTriggerEnter(Collider other) {
		Sword.OnTriggerEnter(other);
	}
}
