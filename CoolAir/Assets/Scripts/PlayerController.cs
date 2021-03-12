using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject interactable;
    [SerializeField]
    private Inventory inventory;
    private Item.ItemType lookingForItem; 

    float yawInput;
    float pitchInput;

    public Inventory Inventory { get { return inventory; } }
    public Item.ItemType LookingForItem { get { return lookingForItem; } }

    // Start is called before the first frame update
    void Start()
    {
        //inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        lookingForItem = Item.ItemType.Wrench;
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
