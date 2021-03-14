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
        Item.ItemType neededItem = player.neededItems.Peek();

        // if the player needs the wrench
        if(neededItem == Item.ItemType.Wrench)
        {
            // if the player doesn't have soup, add it to the stack of needed items
            if (!player.HasItem(Item.ItemType.Soup))
            {
                player.neededItems.Push(Item.ItemType.Soup);
            }
            // otherwise trade the soup for the wrench
            else
            {
                player.RemoveItem(Item.ItemType.Soup);
                player.AcquireItem(wrenchPrefab);
            }
        }
        // if the player needs a pen
        else if(neededItem == Item.ItemType.Pen)
        {
            // if the player doesn't have a paper clip, add it to the stack of needed items
            if (!player.HasItem(Item.ItemType.RedPaperClip))
            {
                player.neededItems.Push(Item.ItemType.RedPaperClip);
            }
            // otherwise trade the paper clip for the pen
            else
            {
                player.RemoveItem(Item.ItemType.RedPaperClip);
                player.AcquireItem(penPrefab);
            }
        }
    }
}
