using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    #region Fields
    // Character names mapped to lists of their dialogue
    private Dictionary<CharacterName, List<string>> dialogueLines = new Dictionary<CharacterName, List<string>>();
    #endregion


    #region Methods
    void Start()
    {
        
        // Read in all the dialogue from the files
        ReadAllDialogue();

        // Testing code
        //Debug.Log(RetrieveDialogueLine(Character.Mechanic, Item.ItemType.Wrench));
        //Item test = new Item();
        //test.itemType = Item.ItemType.Soup;
        //player.Inventory.AddItem(test);
        //Debug.Log(RetrieveDialogueLine(Character.Mechanic, Item.ItemType.Wrench));
        //Debug.Log(RetrieveDialogueLine(Character.Mechanic, Item.ItemType.Pen));
        //Debug.Log(RetrieveDialogueLine(Character.Mechanic, Item.ItemType.VoodooDoll));
    }

    /// <summary>
    /// Retrieves the idle dialogue for the given character
    /// </summary>
    /// <param name="characterName">The character whose idle dialogue is needed</param>
    /// <returns>A character's idle dialogue</returns>
    public string RetrieveIdleDialogue(CharacterName characterName)
    {
        return dialogueLines[characterName][0]; 
    }

    /// <summary>
    /// Retrieves a dialogue line for a given character depending on the given item
    /// </summary>
    /// <param name="characterName">The character whose dialogue is needed</param>
    /// <param name="item">The item the player wants from the given character</param>
    /// <returns>A character's dialogue depending on a given item</returns>
    public string RetrieveDialogueLine(CharacterName characterName, Item.ItemType item)
    {
        int lineNumber = 0; 

        // Each character only has cases for the items that they deal with
        // Otherwise they return idle dialogue
        switch (characterName)
        {
            case CharacterName.Doctor:
                switch (item)
                {
                    case Item.ItemType.Thread:
                        lineNumber = 1;
                        break;
                    case Item.ItemType.Prescription:
                        lineNumber = ChooseCharacterLine(item, Item.ItemType.Pen, 2, 3);
                        break;
                }
                break;
            case CharacterName.Mechanic:
                switch (item)
                {
                    case Item.ItemType.Wrench:
                        lineNumber = ChooseCharacterLine(item, Item.ItemType.Soup, 1, 2);
                        break;
                    case Item.ItemType.Pen:
                        lineNumber = ChooseCharacterLine(item, Item.ItemType.RedPaperClip, 3, 4);
                        break;
                }
                break;
            case CharacterName.OldLady:
                switch (item)
                {
                    case Item.ItemType.Soup:
                        lineNumber = 1;
                        break;
                    case Item.ItemType.VoodooDoll:
                        lineNumber = ChooseCharacterLine(item, Item.ItemType.Thread, 2, 3);
                        break;
                }
                break;
            case CharacterName.Plumber:
                switch (item)
                {
                    case Item.ItemType.Pump:
                        lineNumber = ChooseCharacterLine(item, Item.ItemType.VoodooDoll, 1, 2);
                        break;
                }
                break;
            case CharacterName.ViceDeanLaybourne:
                switch (item)
                {
                    case Item.ItemType.Ammonia:
                        lineNumber = ChooseCharacterLine(item, Item.ItemType.Prescription, 1, 2);
                        break;
                }
                break;
        }

        return RetrieveDialogueLine(characterName, lineNumber);
    }

    #region Helper Methods
    /// <summary>
    /// Determines which line number a character should be saying depending on the item
    /// the player is looking for and what they have
    /// </summary>
    /// <param name="lookingFor">The item the player is looking for</param>
    /// <param name="needed">The item the character needs in return for what the player is looking for</param>
    /// <param name="lookingForLineNum">The line number for the dialogue the character should say if the player doesn't have what the character is looking for</param>
    /// <param name="haveNeededLineNum">The line number for the dialogue the character should say if the player has what the character is looking for</param>
    /// <returns>An integer representing the line number that the character should be saying</returns>
    private int ChooseCharacterLine(Item.ItemType lookingFor, Item.ItemType needed, int lookingForLineNum, int haveNeededLineNum)
    {
        int lineNumber = 0;

        // If the player does not have the item they are looking for
        // the character should say their line that asks the player for an item
        if (!PlayerController.Instance.HasItem(lookingFor))
        {
            lineNumber = lookingForLineNum;
        }

        // If the player has the item that the character wants in return for what the player's looking for
        // the character should say the line that asks for that item and gives the player the item they're looking for
        if (PlayerController.Instance.HasItem(needed))
        {
            lineNumber = haveNeededLineNum;
        }
        // If the player already has the item that they are looking for
        // the character should say idle dialogue because the player should go interact with the air conditioning
        else if (PlayerController.Instance.HasItem(lookingFor))
        {
            lineNumber = 0;
        }

        return lineNumber;
    }

    /// <summary>
    /// Retrieves a character's dialogue line from the dictionary given a line number
    /// </summary>
    /// <param name="characterName">The character whose dialogue should be returned</param>
    /// <param name="lineNumber">The line number for the dialogue that should be returned</param>
    /// <returns>A string representing the character's dialogue</returns>
    private string RetrieveDialogueLine(CharacterName characterName, int lineNumber)
    {
        if (lineNumber < 0)
        {
            return "Unhandled dialogue";
        }

        return dialogueLines[characterName][lineNumber]; 
    }

    /// <summary>
    /// Reads in all the dialogue from files
    /// </summary>
    private void ReadAllDialogue()
    {
        ReadDialogueLines(CharacterName.Doctor);
        ReadDialogueLines(CharacterName.Mechanic);
        ReadDialogueLines(CharacterName.OldLady);
        ReadDialogueLines(CharacterName.Plumber);
        ReadDialogueLines(CharacterName.ViceDeanLaybourne);
    }

    /// <summary>
    /// Reads in all the dialogue lines for a given character and populates their entry in the dictionary
    /// </summary>
    /// <param name="characterName">The name of the character whose file should be read</param>
    private void ReadDialogueLines(CharacterName characterName)
    {
        try
        {
            StreamReader input = new StreamReader(Application.dataPath+ "/Resources/" + characterName.ToString() + ".txt");

            if (!dialogueLines.ContainsKey(characterName))
            {
                dialogueLines.Add(characterName, new List<string>());
            }

            while (!input.EndOfStream)
            {
                dialogueLines[characterName].Add(input.ReadLine());
            }
        }
        catch
        {
            Debug.Log($"Problem reading in {characterName}'s dialogue"); 
        }
    }
    #endregion
    #endregion
}
