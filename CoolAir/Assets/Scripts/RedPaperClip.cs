using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedPaperClip : MonoBehaviour
{
    public GameObject paperClipPrefab;
    public PlayerController player;
    [SerializeField] private GameObject speechBubble;
    private Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText = speechBubble.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPaperClip()
    {
        dialogueText.text = "A red paper clip, I'll hold onto this for now.\nI wonder what I could end up trading this for...";
        player.AcquireItem(paperClipPrefab);

        // for testing purposes only
        player.neededItems.Push(Item.ItemType.Ammonia);
    }
}
