using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class DropOnDeath : MonoBehaviour {
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject field1;
    [SerializeField] private GameObject field2;
    [SerializeField] private GameObject field3;

    //TODO This does not belong here!
    public void drop() {
        float random;
        do {
            random = Random.value;
            float spawnAgain = Random.value;
            if (random < 0.3) {
                Debug.Log("1");
                Instantiate(prefab, field1.transform.position, field1.transform.rotation);
            }

            if (random > 0.3 && random < 0.6) {
                Debug.Log("2");
                Instantiate(prefab, field2.transform.position, field2.transform.rotation);
            }

            if (random > 0.6) {
                Debug.Log("3");
                Instantiate(prefab, field3.transform.position, field3.transform.rotation);
            }
        } while (random > 0.7);
    }
}