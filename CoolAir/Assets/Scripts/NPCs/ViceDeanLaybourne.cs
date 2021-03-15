using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViceDeanLaybourne : Character
{
    public GameObject ammoniaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        characterName = CharacterName.ViceDeanLaybourne;
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

        // if the player needs ammonia
        if(neededItem == Item.ItemType.Ammonia)
        {
            // if the player doesn't have the prescription, add it to the stack of needed items
            if (!PlayerController.Instance.HasItem(Item.ItemType.Prescription))
            {
				PlayerController.Instance.neededItems.Push(Item.ItemType.Prescription);
            }
            // otherwise trade the prescription for the ammonia
            else
            {
				PlayerController.Instance.RemoveItem(Item.ItemType.Prescription);
                PlayerController.Instance.AcquireItem(ammoniaPrefab);
            }
        }
    }
}
