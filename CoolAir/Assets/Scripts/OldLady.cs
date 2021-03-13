using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLady : Character
{
    public GameObject soupPrefab;
    public GameObject voodooDoll;

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
        Item.ItemType neededItem = player.neededItems.Peek();
        if(neededItem == Item.ItemType.Soup)
        {
            player.neededItems.Pop();
            player.AcquireItem(soupPrefab);
        }

        else if (neededItem == Item.ItemType.VoodooDoll)
        {
            if (!player.HasItem(Item.ItemType.Thread))
            {
                player.neededItems.Push(Item.ItemType.Thread);
            }

            else
            {
                player.RemoveItem(Item.ItemType.Thread);
                player.neededItems.Pop();
                player.AcquireItem(voodooDoll);
            }
        }
    }
}
