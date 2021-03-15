﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirConditionerScript : MonoBehaviour
{
    private List<Item.ItemType> acInv;
    [SerializeField] private GameObject speechBubble;
    private Text dialogueText;

    void Start()
    {
        acInv = new List<Item.ItemType>();
        dialogueText = speechBubble.GetComponentInChildren<Text>();
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
        if (acInv.Count == 0)
        {
            if(Inventory.Instance.Contains(Item.ItemType.Wrench))
                AddItem(Item.ItemType.Wrench);

            else
            {
                dialogueText.text = "It looks like some of these bolts are lose...";

                if(!PlayerController.Instance.neededItems.Contains(Item.ItemType.Wrench))
					PlayerController.Instance.neededItems.Push(Item.ItemType.Wrench);
            }
        }

        if (acInv.Count == 1)
        {
            if (Inventory.Instance.Contains(Item.ItemType.Pump))
                AddItem(Item.ItemType.Pump);

            else
            {
                dialogueText.text = "The screws are fine but it is not pumping anymore...";

                if (!PlayerController.Instance.neededItems.Contains(Item.ItemType.Pump))
					PlayerController.Instance.neededItems.Push(Item.ItemType.Pump);
            }
        }

        if (acInv.Count == 2)
        {
            if (Inventory.Instance.Contains(Item.ItemType.Ammonia))
                AddItem(Item.ItemType.Ammonia);

            else
            {
                dialogueText.text = "Now I just need to find some ammonia...";

                if (!PlayerController.Instance.neededItems.Contains(Item.ItemType.Ammonia))
					PlayerController.Instance.neededItems.Push(Item.ItemType.Ammonia);
            }
        }
    }

    public void AddItem(Item.ItemType itemType)
    {
        acInv.Add(itemType);
		PlayerController.Instance.RemoveItem(itemType);
    }
}
