using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTeleporter : MonoBehaviour {
	private void OnTriggerEnter(Collider other) {
		this.gameObject.SetActive(false);
		GameManager.Instance.StartRound();
	}
}
