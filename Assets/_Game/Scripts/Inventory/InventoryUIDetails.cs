using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour {
    Item item;
    Button selectedItemButton;
    Button itemInteracButton;
    Text itemNameText;
    Text itemDescriptionText;
    Text itemInteractButtonText;

    public Text statText;

    void Start()
    {
        itemNameText = transform.Find("Item_Name").GetComponent<Text>();
        itemDescriptionText = transform.Find("Item_Description").GetComponent<Text>();
        itemInteracButton = transform.Find("Button").GetComponent<Button>();
        itemInteractButtonText = itemInteracButton.transform.Find("Text").GetComponent<Text>();
        gameObject.SetActive(false);
    }
    public void SetItem(Item item, Button selectedButton)
    {
        statText.text = "";
        if(item.Stats != null)
        {
            foreach(BaseStat stat in item.Stats)
            {
                statText.text += stat.StatName + ": "+ stat.BaseValue +"\n";
            }
        }
        itemInteracButton.onClick.RemoveAllListeners();
        this.item = item;
        selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description;
        itemInteractButtonText.text = item.ActionName;
        itemInteracButton.onClick.AddListener(OnItemInteract);
        gameObject.SetActive(true);
    }

    public void OnItemInteract()
    {
        if(item.ItemType == Item.ItemTypes.Consumeable)
        {
            InventoryController.Instance.ConsumeItem(item);
            Destroy(selectedItemButton.gameObject);
        }
        else if(item.ItemType == Item.ItemTypes.Weapon)
        {
            InventoryController.Instance.EquipItem(item);
            Destroy(selectedItemButton.gameObject); // Hier wird die Waffe deletet also muss noch geändert werden.
        }
        item = null;
        gameObject.SetActive(false);
    }

}
