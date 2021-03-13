using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plumber : Character
{
    public GameObject pump;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        characterName = CharacterName.Plumber;

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void UpdatePlayerState()
    {
        Item.ItemType neededItem = player.neededItems.Peek();
        if (neededItem == Item.ItemType.Pump)
        {
            if (!player.HasItem(Item.ItemType.VoodooDoll))
            {
                player.neededItems.Push(Item.ItemType.VoodooDoll);
            }

            else
            {
                player.RemoveItem(Item.ItemType.VoodooDoll);
                player.neededItems.Pop();
                player.AcquireItem(pump);
            }
        }
    }
}
