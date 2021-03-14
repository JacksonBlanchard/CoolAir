using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : Character
{
    public GameObject threadPrefab;
    public GameObject prescriptionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        characterName = CharacterName.Doctor;
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

        // give the player thread if they need it
        if (neededItem == Item.ItemType.Thread)
        {
            player.neededItems.Pop();
            player.AcquireItem(threadPrefab);
        }
        // if the player needs the prescription
        else if(neededItem == Item.ItemType.Prescription)
        {
            // if the player doesn't have a pen, add it to the stack of needed items
            if (!player.HasItem(Item.ItemType.Pen))
            {
                player.neededItems.Push(Item.ItemType.Pen);
            }
            // otherwise trade the pen for the prescription
            else
            {
                player.RemoveItem(Item.ItemType.Pen);
                player.AcquireItem(prescriptionPrefab);
            }
        }
    }
}
