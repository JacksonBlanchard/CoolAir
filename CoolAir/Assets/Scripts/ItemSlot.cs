using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private Item item;
    private PlayerController player;
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Main Camera").GetComponent<PlayerController>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItem(Item _item)
    {
        item = _item;
        // add the item image to the inventory slot panel
        GetComponent<Image>().sprite = item.inventoryImage;
    }

    public Item.ItemType GetItemType()
    {
        return item.itemType;
    }

    private void OnMouseDown()
    {
        if(item != null && inventory.interactable)
        {
            inventory.ToggleInteraction();
            player.ClickedItem(item);
        }
    }
}
