using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SetDialogue : MonoBehaviour
{
    DialogueManager manager;
    bool inRange = false;
    int currentLine = 0;
    [SerializeField] NPCData data;
    bool optionChosen = false;
    NPCDraft draft;

    GameObject buttonOption1Object;
    GameObject buttonOption2Object;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player entered space");
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player has left space");
            inRange = false;
            EndDialogue();
        }
    }

    void OnOpenUI(InputValue value)
    {
        if(value.isPressed && inRange)
        {
            if(!manager.dialogeActive)
            {
                StartDialogue();
            } 
            else
            {
                ContinueDialogue();
            }
        }
    }

    
    void StartDialogue()
    {
        manager.OpenDialogue();
        ShowDialogue();
    }

    void ContinueDialogue()
    {
        currentLine++;

        if(currentLine < data.dialogueLines.Length)
        {
            ShowDialogue();
        }
        else
        {
            EndDialogue();
        }

        if(data.hasOptions && !optionChosen && currentLine == data.optionIndex)
        {
           //ShowOptions();
           GenerateOptions();
        } else if(currentLine != data.optionIndex)
        {
            ClearOptions();
        }
    }

    void ShowDialogue()
    {
            manager.dialogueText.text = data.dialogueLines[currentLine];
            manager.nameText.text = data.nameLines[currentLine];
        
    }

    // void ShowOptions()
    // {
    //     manager.option1Button.gameObject.SetActive(true);
    //     manager.option2Button.gameObject.SetActive(true);
    //     // manager.option1Text.text = data.option1Lines;
    //     // manager.option2Text.text = data.option2Lines;
    // }

    public void GenerateOptions()
    {
        buttonOption1Object = Instantiate(manager.option1Button, manager.option1Transform);
        buttonOption2Object = Instantiate(manager.option2Button, manager.option2Transform);

        //avoiding ArgumentNullException
        if (buttonOption1Object != null)
        {
            Debug.Log("button 1 object is not null");
            buttonOption1Object.SetActive(true); // Ensure the button is active
            buttonOption1Object.GetComponentInChildren<TMP_Text>().text = data.option1Lines;

            //adding onClick event
            Button buttonComponent = buttonOption1Object.GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => DialogueOption(0));
        }

        if (buttonOption2Object != null)
        {
            buttonOption2Object.SetActive(true); // Ensure the button is active
            buttonOption2Object.GetComponentInChildren<TMP_Text>().text = data.option2Lines;

            //adding onClick event
            Button buttonComponent = buttonOption2Object.GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => DialogueOption(1));
        }
    }

    void ClearOptions()
    {
        if(buttonOption1Object != null)
        {
            Debug.Log("button 1 object is not null");
            buttonOption1Object.SetActive(false); // Ensure the button is active
        }

        if (buttonOption2Object != null)
        {
            buttonOption2Object.SetActive(false); // Ensure the button is active
        }
    }


    void EndDialogue()
    {
        manager.CloseDialogue();
        currentLine = 0;
    }

    public void DialogueOption(int optionValue)
    {

        Debug.Log("Option Chosen: " + optionValue);
        // optionChosen = true;
        // currentLine = 0;
        // manager.option1Button.gameObject.SetActive(false);
        // manager.option2Button.gameObject.SetActive(false);
        
        // if (optionValue == 0)
        // {
        //     manager.dialogueText.text = data.option1Dialogue[currentLine];
        //     manager.nameText.text = data.option1Name[currentLine];
        //     //ShowPickedDialogueOptions(data.option1Dialogue[currentLine], data.option1Name[currentLine]);
        // }
        // else if(optionValue == 1)
        // {
        //     manager.dialogueText.text = data.option2Dialogue[currentLine];
        //     manager.nameText.text = data.option2Name[currentLine];
        //     // ShowPickedDialogueOptions(data.option2Dialogue[currentLine], data.option2Name[currentLine]);
        // }
    }

    void ShowPickedDialogueOptions(string dialogue, string name)
    {
        Debug.Log("showing picked dialogue options");
        //everthing works until here. Please fix. Index is set outside of bounds of array
        manager.dialogueText.text = dialogue;
        manager.nameText.text = name;
    }
    
}
