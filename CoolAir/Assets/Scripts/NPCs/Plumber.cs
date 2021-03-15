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
        Item.ItemType neededItem = PlayerController.Instance.neededItems.Peek();
        if (neededItem == Item.ItemType.Pump)
        {
            if (!PlayerController.Instance.HasItem(Item.ItemType.VoodooDoll))
            {
				PlayerController.Instance.neededItems.Push(Item.ItemType.VoodooDoll);
            }

            else
            {
				PlayerController.Instance.RemoveItem(Item.ItemType.VoodooDoll);
				PlayerController.Instance.neededItems.Pop();
				PlayerController.Instance.AcquireItem(pump);
            }
        }
    }
}
