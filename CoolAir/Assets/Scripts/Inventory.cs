using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<Item> itemList;
    public GameObject itemSlotPrefab;
    public bool interactable;

    void Start()
    {
        itemList = new List<Item>();
        interactable = true;
    }

    void Update()
    {
        
    }

    public void AddItem(Item item)
    {
        // add item to the List<Item>
        itemList.Add(item);
        // instantiate the itemSlotPrefab UI Panel and make it a child of this object
        GameObject itemSlot = Instantiate(itemSlotPrefab, transform);
        itemSlot.GetComponent<ItemSlot>().SetItem(item);

        Debug.Log("Added " + item.name + " to inventory (size " + itemList.Count + ")");
    }

    public bool Contains(Item.ItemType itemType)
    {
        foreach(Item i in itemList)
        {
            if(i.itemType == itemType)
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
