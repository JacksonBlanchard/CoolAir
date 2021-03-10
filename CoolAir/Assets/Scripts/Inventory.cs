using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<Item> itemList;
    public GameObject itemSlotPrefab;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        // add item to the List<Item>
        itemList.Add(item);
        // instantiate the itemSlotPrefab UI Panel and make it a child of this object
        GameObject itemSlot = Instantiate(itemSlotPrefab, transform);
        // make the item a child of the panel so that it is visible
        item.gameObject.transform.parent = itemSlot.transform;
        item.gameObject.transform.position = Vector3.zero;

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
}
