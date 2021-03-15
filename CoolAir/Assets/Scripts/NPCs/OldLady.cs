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
        Item.ItemType neededItem = PlayerController.Instance.neededItems.Peek();

        // give the player soup if they need it
        if(neededItem == Item.ItemType.Soup)
        {
			PlayerController.Instance.neededItems.Pop();
			PlayerController.Instance.AcquireItem(soupPrefab);
        }
        // if the player needs the voodoo doll
        else if (neededItem == Item.ItemType.VoodooDoll)
        {
            // if the player doesn't have thread, add it to the stack of needed items
            if (!PlayerController.Instance.HasItem(Item.ItemType.Thread))
            {
				PlayerController.Instance.neededItems.Push(Item.ItemType.Thread);
            }
            // otherwise trade the thread for the voodoo doll
            else
            {
				PlayerController.Instance.RemoveItem(Item.ItemType.Thread);
				PlayerController.Instance.AcquireItem(voodooDollPrefab);
            }
        }
    }
}
