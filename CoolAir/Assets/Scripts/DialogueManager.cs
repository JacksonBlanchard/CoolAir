using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    #region Fields
    private Dictionary<string, List<string>> dialogueLines = new Dictionary<string, List<string>>(); 
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ReadAllDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string RetrieveIdleDialogue(string characterName)
    {
        return dialogueLines[characterName][0]; 
    }

    public string RetreiveDialogueLine(string characterName, int lineNumber)
    {
        return dialogueLines[characterName][lineNumber]; 
    }

    private void ReadAllDialogue()
    {
        ReadDialogueLines("Doctor");
        ReadDialogueLines("Mechanic");
        ReadDialogueLines("OldLady");
        ReadDialogueLines("Plumber");
        ReadDialogueLines("ViceDeanLaybourne");
    }

    private void ReadDialogueLines(string characterName)
    {
        try
        {
            StreamReader input = new StreamReader("Assets/Dialogue/" + characterName + ".txt");

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
}
