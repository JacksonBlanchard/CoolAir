using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanic : Character
{

    public GameObject wrenchPrefab;

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
        Item.ItemType neededItem = player.neededItems.Peek();
        if(neededItem == Item.ItemType.Wrench)
        {
            if (!player.HasItem(Item.ItemType.Soup))
            {
                player.neededItems.Push(Item.ItemType.Soup);
            }

            else
            {
                player.RemoveItem(Item.ItemType.Soup);
                player.neededItems.Pop();
                player.AcquireItem(wrenchPrefab);
            }
        }
    }
}
