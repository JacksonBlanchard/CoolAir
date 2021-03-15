using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedPaperClip : MonoBehaviour
{
    public GameObject paperClipPrefab;
    [SerializeField] private GameObject speechBubble;
    private Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText = speechBubble.GetComponentInChildren<Text>();
    }

    public void AddPaperClip()
    {
		if (!PlayerController.Instance.HasItem(Item.ItemType.RedPaperClip))
		{
			dialogueText.text = "A red paper clip, I'll hold onto this for now.\nI wonder what I could end up trading this for...";
			PlayerController.Instance.AcquireItem(paperClipPrefab);

			// for testing purposes only
			PlayerController.Instance.neededItems.Push(Item.ItemType.Ammonia);
		}
		else
		{
			dialogueText.text = "What happened to the paper clip?...\nOh right I took it";
		}
    }
}
