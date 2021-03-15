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
        Item.ItemType neededItem = PlayerController.Instance.neededItems.Peek();

        // give the player thread if they need it
        if (neededItem == Item.ItemType.Thread)
        {
			PlayerController.Instance.neededItems.Pop();
			PlayerController.Instance.AcquireItem(threadPrefab);
        }
        // if the player needs the prescription
        else if(neededItem == Item.ItemType.Prescription)
        {
            // if the player doesn't have a pen, add it to the stack of needed items
            if (!PlayerController.Instance.HasItem(Item.ItemType.Pen))
            {
				PlayerController.Instance.neededItems.Push(Item.ItemType.Pen);
            }
            // otherwise trade the pen for the prescription
            else
            {
				PlayerController.Instance.RemoveItem(Item.ItemType.Pen);
				PlayerController.Instance.AcquireItem(prescriptionPrefab);
            }
        }
    }
}
