using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour {
    CharackterStats stats;
	// Use this for initialization
	void Start () {
        stats = GetComponent<Player>().charackterStats; // Statuswerte des Charackters abgreifen
	}

    public void ConsumeItem(Item item)//Item krallen
    {
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Consumeables/" + item.ObjectSlug));//Item aus dem Consumeables herraus suchen
        if(item.ItemModifier)//überprüfen ob Statuswerte geändert werden müssen dann methode mit Stats aufrufen
        {
            itemToSpawn.GetComponent<IConsume>().Consume(stats);
        }
        else
        {
            itemToSpawn.GetComponent<IConsume>().Consume();
        }
        
    }


}
