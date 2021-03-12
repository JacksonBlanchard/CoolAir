using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<ItemSlot> itemSlotList;
    public GameObject itemSlotPrefab;
    public bool interactable;

    void Start()
    {
        itemSlotList = new List<ItemSlot>();
        interactable = true;
    }

    void Update()
    {
        
    }

    public void AddItem(Item item)
    {
        // instantiate the itemSlotPrefab UI Panel and make it a child of this object
        GameObject itemSlot = Instantiate(itemSlotPrefab, transform);
        itemSlot.GetComponent<ItemSlot>().SetItem(item);

        // add item to the List<Item>
        itemSlotList.Add(itemSlot.GetComponent<ItemSlot>());

        Debug.Log("Added " + item.itemType.ToString() + " to inventory (size " + itemSlotList.Count + ")");
    }

    public void RemoveItem(Item.ItemType itemType)
    {
        if(Contains(itemType))
        {
            ItemSlot slotToRemove;
            foreach(ItemSlot itemSlot in itemSlotList)
            {
                if (itemSlot.GetItemType() == itemType)
                {
                    slotToRemove = itemSlot;
                    itemSlotList.Remove(slotToRemove);
                    Destroy(slotToRemove.gameObject);
                    break;
                }
            }
        }
    }

    public bool Contains(Item.ItemType itemType)
    {
        foreach(ItemSlot itemSlot in itemSlotList)
        {
            if(itemSlot.GetItemType() == itemType)
            {
                return true;
            }
        }
        return false;
    }

    public void ToggleInteraction()
    {
        interactable = !interactable;
        //this.enabled = false;
    }
}
