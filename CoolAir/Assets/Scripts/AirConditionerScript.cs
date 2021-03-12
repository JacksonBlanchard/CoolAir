using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirConditionerScript : MonoBehaviour
{
    public Inventory inventory;
    [SerializeField]
    private List<Item> acInv;

    void Start()
    {
        acInv = new List<Item>();

    }

    private void Update()
    {
        if(acInv.Count >= 3)
        {
            // Win Condition
            Debug.Log("You Won!!");
        }
    }


    public void CheckForItems()
    {
        Item item = new Item();
        if (inventory.Contains(Item.ItemType.Wrench) && (acInv.Count == 0))
        {
            AddItem(item, Item.ItemType.Wrench);

        }

        if (inventory.Contains(Item.ItemType.Pump) && (acInv.Count == 1))
        {
            AddItem(item, Item.ItemType.Pump);

        }

        if (inventory.Contains(Item.ItemType.Ammonia) && (acInv.Count == 2))
        {
            AddItem(item, Item.ItemType.Ammonia);

        }

    }

    public void AddItem(Item item, Item.ItemType type)
    {
        item.itemType = type;
        acInv.Add(item);
        inventory.RemoveItem(type);

    }


}
