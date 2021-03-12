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
    [SerializeField] private CharacterName characterName;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private PlayerController player;
    private Text dialogueText; 

    // Start is called before the first frame update
    void Start()
    {
        dialogueText = GetComponentInChildren<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterClick()
    {
        string dialogue = dialogueManager.RetrieveDialogueLine(characterName, player.LookingForItem);

        // This line is from https://stackoverflow.com/questions/21319257/insert-newline-character-after-specific-number-of-words
        // It separates the string at every ninth word and adds a return so that things are actually spaced out
        dialogue = string.Join(Environment.NewLine, dialogue.Split().Select((word, index) => new { word, index }).GroupBy(x => x.index / 9).Select(grp => string.Join(" ", grp.Select(x => x.word))));
        
        dialogueText.text = dialogue; 
    }
}
