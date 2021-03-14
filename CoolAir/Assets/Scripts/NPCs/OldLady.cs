using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLady : Character
{
    public GameObject soupPrefab;
    public GameObject voodooDollPrefab;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        characterName = CharacterName.OldLady;

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

        // give the player soup if they need it
        if(neededItem == Item.ItemType.Soup)
        {
            player.neededItems.Pop();
            player.AcquireItem(soupPrefab);
        }
        // if the player needs the voodoo doll
        else if (neededItem == Item.ItemType.VoodooDoll)
        {
            // if the player doesn't have thread, add it to the stack of needed items
            if (!player.HasItem(Item.ItemType.Thread))
            {
                player.neededItems.Push(Item.ItemType.Thread);
            }
            // otherwise trade the thread for the voodoo doll
            else
            {
                player.RemoveItem(Item.ItemType.Thread);
                player.AcquireItem(voodooDollPrefab);
            }
        }
    }
}
