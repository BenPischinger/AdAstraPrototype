using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }
    public PlayerController playerWeaponController;
    public ConsumableController consumeableController;
    public List<Item> playerItems = new List<Item>();
    public InventoryUIDetails inventoryDetailsPanel;


    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance =this;
        }
        playerWeaponController = GetComponent<PlayerController>();
        consumeableController = GetComponent<ConsumableController>();
        GiveItem("sword");
        GiveItem("potion_Log");
        GiveItem("staff");

    }
    public void GiveItem(string itemSlug)//Item wird hinzugefügt
    {
        Item item = ItemDataBase.Instance.GetItem(itemSlug);
        playerItems.Add(ItemDataBase.Instance.GetItem(itemSlug));
        Debug.Log(playerItems.Count + " items in the Inventory. Added " + itemSlug);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void EquipItem(Item itemToEquip) // das Item aus dem Inventar wird ausgerüstet
    {
        //TODO sry messed with your code
        if (itemToEquip is IWeapon) {
            playerWeaponController.EquipWeapon((IWeapon)itemToEquip);
        }   
    }

    public void ConsumeItem(Item itemToConsume)// das Item aus dem Inventar wird verbraucht
    {
        consumeableController.ConsumeItem(itemToConsume);
    }
    public void SetItemDetails(Item item ,Button selectedButton)
    {
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }

}
