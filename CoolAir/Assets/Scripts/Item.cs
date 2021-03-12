using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
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
    public Sprite inventoryImage;
    public bool intermittent;

    void Start()
    {
        transform.position = new Vector3(0, 0, 2);
        GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        
    }
}
