using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirConditionerScript : MonoBehaviour
{
    public Inventory inventory;
    public PlayerController player;
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
            if(inventory.Contains(Item.ItemType.Wrench))
                AddItem(Item.ItemType.Wrench);

            else
            {
                dialogueText.text = "It looks like some of these bolts are lose...";

                if(!player.neededItems.Contains(Item.ItemType.Wrench))
                    player.neededItems.Push(Item.ItemType.Wrench);
            }
        }

        if (acInv.Count == 1)
        {
            if (inventory.Contains(Item.ItemType.Pump))
                AddItem(Item.ItemType.Pump);

            else
            {
                dialogueText.text = "The screws are fine but it is not pumping anymore...";

                if (!player.neededItems.Contains(Item.ItemType.Pump))
                    player.neededItems.Push(Item.ItemType.Pump);
            }
        }

        if (acInv.Count == 2)
        {
            if (inventory.Contains(Item.ItemType.Ammonia))
                AddItem(Item.ItemType.Ammonia);

            else
            {
                dialogueText.text = "Now I just need to find some ammonia...";

                if (!player.neededItems.Contains(Item.ItemType.Ammonia))
                    player.neededItems.Push(Item.ItemType.Ammonia);
            }
        }
    }

    public void AddItem(Item.ItemType itemType)
    {
        acInv.Add(itemType);
        player.RemoveItem(itemType);
    }
}
