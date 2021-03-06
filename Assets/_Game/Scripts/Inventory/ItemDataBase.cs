﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDataBase : MonoBehaviour {

    public static ItemDataBase Instance { get; set; }
    private List<Item> Items { get; set; }

	// Use this for initialization
	void Awake () {
		if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        BuildDataBase();
    }

	
    private void BuildDataBase()
    {
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
        Debug.Log(Items[0].Stats[0].StatName+"Level is "+ Items[0].Stats[0].GetCalculatedStatValue());
    }

    public Item GetItem(string itemSlug)
    {
        foreach(Item item in Items)
        {
            if(item.ObjectSlug == itemSlug)
            {
                return item;
            }
        }
        Debug.LogWarning("Couldn´t find item: " + itemSlug);
        return null;
    }
}
