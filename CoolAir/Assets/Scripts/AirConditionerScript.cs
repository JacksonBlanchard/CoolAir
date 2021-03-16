using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AirConditionerScript : MonoBehaviour
{
	public Sprite OkayImage;
	public Sprite FixedImage;
	public Image BackgroundImage;

    private int ACstage;
    [SerializeField] private GameObject speechBubble;
    private Text dialogueText;

    void Start()
    {
		ACstage = PlayerController.Instance.ACStage;
		if(ACstage == 1)
		{
			BackgroundImage.sprite = OkayImage;
		}else if(ACstage == 2)
		{
			BackgroundImage.sprite = FixedImage;
		}
		dialogueText = speechBubble.GetComponentInChildren<Text>();

    }

    private void Update()
    {
        if(ACstage >= 3)
        {
            // Win Condition
            SceneManager.LoadScene("WinScene");
            //Debug.Log("You Won!!");
        }
    }

    public void CheckForItems()
    {
        if (ACstage == 0)
        {
			if (Inventory.Instance.Contains(Item.ItemType.Wrench))
			{
				AddItem(Item.ItemType.Wrench);
				BackgroundImage.sprite = OkayImage;
			}

			else
			{
				dialogueText.text = "It looks like some of these bolts are lose...";

				if (!PlayerController.Instance.neededItems.Contains(Item.ItemType.Wrench))
					PlayerController.Instance.neededItems.Push(Item.ItemType.Wrench);
			}
        }
        else if (ACstage == 1)
        {

			if (Inventory.Instance.Contains(Item.ItemType.Pump))
			{
				AddItem(Item.ItemType.Pump);
				BackgroundImage.sprite = FixedImage;
			}

			else
			{
				dialogueText.text = "The screws are fine but it is not pumping anymore...";

				if (!PlayerController.Instance.neededItems.Contains(Item.ItemType.Pump))
					PlayerController.Instance.neededItems.Push(Item.ItemType.Pump);
			}
        }
        else if (ACstage == 2)
        {
			
            if (Inventory.Instance.Contains(Item.ItemType.Ammonia))
                AddItem(Item.ItemType.Ammonia);

            else
            {
                dialogueText.text = "Now I just need to find some ammonia...";

                if (!PlayerController.Instance.neededItems.Contains(Item.ItemType.Ammonia))
					PlayerController.Instance.neededItems.Push(Item.ItemType.Ammonia);
            }
        }
    }

    public void AddItem(Item.ItemType itemType)
    {
        //acInv.Add(itemType);
		PlayerController.Instance.AddItemToAC(itemType);
		PlayerController.Instance.ACStage++;
    }
}
