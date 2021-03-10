using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour //Interactable
{
    public enum ItemType
    {
        Wrench,
        Pump,
        Ammonia,
        Soup,
        Thread,
        VoodooDoll,
        RedPaperClip,
        Pen,
        Prescription
    }

    public ItemType itemType;
}
