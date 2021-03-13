using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : Character
{
    public GameObject thread;

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
        Item.ItemType neededItem = player.neededItems.Peek();
        if (neededItem == Item.ItemType.Thread)
        {
            player.neededItems.Pop();
            player.AcquireItem(thread);
        }
    }
}
