using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanic : Character
{
    public GameObject wrenchPrefab;
    public GameObject redPaperClipPrefab;
    public GameObject penPrefab;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        characterName = CharacterName.Mechanic;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void UpdatePlayerState()
    {
        // check what item the player currently needs
        Item.ItemType neededItem = PlayerController.Instance.neededItems.Peek();

        // if the player needs the wrench
        if(neededItem == Item.ItemType.Wrench)
        {
            // if the player doesn't have soup, add it to the stack of needed items
            if (!PlayerController.Instance.HasItem(Item.ItemType.Soup))
            {
				PlayerController.Instance.neededItems.Push(Item.ItemType.Soup);
            }
            // otherwise trade the soup for the wrench
            else
            {
				PlayerController.Instance.RemoveItem(Item.ItemType.Soup);
				PlayerController.Instance.AcquireItem(wrenchPrefab);
            }
        }
        // if the player needs a pen
        else if(neededItem == Item.ItemType.Pen)
        {
            // if the player doesn't have a paper clip, add it to the stack of needed items
            if (!PlayerController.Instance.HasItem(Item.ItemType.RedPaperClip))
            {
				PlayerController.Instance.neededItems.Push(Item.ItemType.RedPaperClip);
            }
            // otherwise trade the paper clip for the pen
            else
            {
				PlayerController.Instance.RemoveItem(Item.ItemType.RedPaperClip);
				PlayerController.Instance.AcquireItem(penPrefab);
            }
        }
    }
}
