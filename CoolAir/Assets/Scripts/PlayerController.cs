﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Sequence
{
    public int GetCurrentState()
    {
        return currentState;
    }

    public void IncrementState()
    {
        currentState++;
    }

    public int currentState = 0;
}

public class Sequence1: Sequence
{
    int NeedsWrench = 0;
    int NeedsSoup = 1;
    int GotSoup = 2;
    int GotWrench = 3;

}

public class Sequence2: Sequence
{
    int NeedsPump = 0;
    int NeedsVoodooDoll = 1;
    int NeedsThread = 2;
    int GotThread = 3;
    int GotVoodooDoll = 4;
    int GotPump = 5;
}

public class Sequence3: Sequence
{
    int NeedsAmmonia = 0;
    int NeedsPrescription = 1;
    int NeedsPen = 2;
    int NeedsPaperClip = 3;
    int GotPaperClip = 4;
    int GotPen = 5;
    int GotPrescription = 6;
    int GotAmmonia = 7;

}


public class PlayerController : MonoBehaviour
{
    private GameObject interactable;
    [SerializeField]
    private Inventory inventory;
    private Item.ItemType lookingForItem; 

    float yawInput;
    float pitchInput;

    private int currentSequence;
    private List<Sequence> sequences = new List<Sequence>();

    private Sequence1 firstSequence;
    private Sequence2 secondSequence;
    private Sequence3 thirdSequence;

    public Inventory Inventory { get { return inventory; } }
    public Item.ItemType LookingForItem { get { return lookingForItem; } }

    // Start is called before the first frame update
    void Start()
    {
        //inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        currentSequence = 0;
        lookingForItem = Item.ItemType.Wrench;
        sequences.Add(new Sequence1());
        sequences.Add(new Sequence2());
        sequences.Add(new Sequence3());

    }

    // Update is called once per frame
    void Update()
    {
        if(interactable != null)
        {
            ExamineObject(interactable);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            interactable.GetComponent<Renderer>().enabled = false;
            interactable = null;
            inventory.ToggleInteraction();
        }
    }

    public void ExamineObject(GameObject obj)
    {
        //obj.transform.position = (transform.position + transform.forward * 1f);
        yawInput = Input.GetAxisRaw("Mouse X") * 1.5f;
        pitchInput = Input.GetAxisRaw("Mouse Y") * 1.5f;

        if (Mathf.Abs(pitchInput) > Mathf.Abs(yawInput))
            obj.transform.Rotate(transform.right, pitchInput, Space.World);

        else
            obj.transform.Rotate(transform.up, -yawInput, Space.World);
    }

    void QueryPlayerState()
    {
        switch(currentSequence)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
    public void ClickedItem(Item item)
    {
        item.gameObject.GetComponent<Renderer>().enabled = true;

        // intermittent 2D items
        if(item.intermittent)
        {

        }
        // 3D items to inspect
        else
        {
            interactable = item.gameObject;
        }
    }

    public void AcquireItem(GameObject itemPrefab)
    {
        GameObject item = Instantiate(itemPrefab, transform);
        inventory.AddItem(item.GetComponent<Item>());
    }

    public void RemoveItem(Item.ItemType itemType)
    {
        inventory.RemoveItem(itemType);
    }
}
