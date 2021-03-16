using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterName
{
    Doctor,
    Mechanic,
    OldLady,
    Plumber,
    ViceDeanLaybourne
}

public class Character : MonoBehaviour
{
    [SerializeField] protected CharacterName characterName;
    [SerializeField] protected DialogueManager dialogueManager;
    [SerializeField] protected GameObject speechBubble;
    protected Text dialogueText; 

    // Start is called before the first frame update
    public void Start()
    {
        dialogueText = speechBubble.GetComponentInChildren<Text>(); 
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            speechBubble.SetActive(false);
        }
    }

    public void CharacterClick()
    {

        speechBubble.SetActive(true);

        string dialogue; 

        if (PlayerController.Instance.neededItems.Count == 0)
        {
            dialogue = dialogueManager.RetrieveIdleDialogue(characterName);
        }
        else
        {
            dialogue = dialogueManager.RetrieveDialogueLine(characterName, PlayerController.Instance.neededItems.Peek());
        }

        // This line is from https://stackoverflow.com/questions/21319257/insert-newline-character-after-specific-number-of-words
        // It separates the string at every ninth word and adds a return so that things are actually spaced out
        dialogue = string.Join(Environment.NewLine, dialogue.Split().Select((word, index) => new { word, index }).GroupBy(x => x.index / 9).Select(grp => string.Join(" ", grp.Select(x => x.word))));
        
        dialogueText.text = dialogue;

        if (PlayerController.Instance.neededItems.Count != 0)
        {
            UpdatePlayerState();
        }
    }

    public virtual void UpdatePlayerState()
    {

    }
}
