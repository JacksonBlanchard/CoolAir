using System.Collections;
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

    [System.NonSerialized]
    public Stack<Item.ItemType> neededItems = new Stack<Item.ItemType>();

    float yawInput;
    float pitchInput;

    private Item.ItemType[] itemArray = { 
        Item.ItemType.Soup, 
        Item.ItemType.Wrench,
        Item.ItemType.Thread,
        Item.ItemType.VoodooDoll,
        Item.ItemType.Pump,
        Item.ItemType.RedPaperClip,
        Item.ItemType.Pen,
        Item.ItemType.Prescription,
        Item.ItemType.Ammonia   
    };

    [SerializeField]
    private Item.ItemType currentItem;
    [SerializeField]
    private Item.ItemType nextItem;
    private int currentItemIndex;

    private int currentSequence;
    private List<Sequence> sequences = new List<Sequence>();

    private Sequence1 firstSequence;
    private Sequence2 secondSequence;
    private Sequence3 thirdSequence;

	private static PlayerController _instance;

	public static PlayerController Instance
	{
		get
		{
			//normaly you would instantiate a new instance if one did not exist
			//but since this requires inventory, and their is no way to tell which
			//will instantiate first im just gonna skip that step
			return _instance;
		}
	}

    public Inventory Inventory { get { return inventory; } }
    public Item.ItemType LookingForItem { get { return lookingForItem; } }

    // Start is called before the first frame update
    void Start()
    {
		if (_instance != null && _instance != this)
		{
			Destroy(gameObject);
			return;
		}
		_instance = this;
		//inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
		DontDestroyOnLoad(transform.parent.gameObject);
		currentItemIndex = 0;
        currentSequence = 0;
        neededItems.Push(Item.ItemType.Pump);
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

        CheckItems();

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
        neededItems.Pop();
    }

    public void CheckItems()
    {
        for(int i = 0; i < itemArray.Length; i++)
        {
            if(inventory.Contains(itemArray[i]))
            {
                currentItem = itemArray[i];
                currentItemIndex = i;
                if(i < itemArray.Length)
                {
                    nextItem = itemArray[i + 1];

                }
                else
                {
                    nextItem = itemArray[0];
                }

            }

        }

    }

    public bool HasItem(Item.ItemType itemType)
    {
        return (inventory.Contains(itemType)) ;
    }
}
