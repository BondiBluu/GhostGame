using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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

    GameObject buttonOption1Object;
    GameObject buttonOption2Object;
    int optionPicked;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        //instantiating option buttons
        buttonOption1Object = Instantiate(manager.option1Button, manager.option1Transform);
        buttonOption2Object = Instantiate(manager.option2Button, manager.option2Transform);
        ClearOptions();
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
            EndDialogueOptions();
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

        if(currentLine < data.dialogueLines.Length && !optionChosen)
        {
            ShowDialogue();
        }
        else if (currentLine < data.dialogueLines.Length && optionChosen)
        {
            ShowOptionDialogue(optionPicked);
        }
        else
        {
            EndDialogueOptions();
            ResetOptions();
        }

        if(data.hasOptions && !optionChosen && currentLine == data.optionIndex)
        {
           GenerateOptions();
        } else
        {
            ClearOptions();
        }
    }

    void ShowDialogue()
    {
            manager.dialogueText.text = data.dialogueLines[currentLine];
            manager.nameText.text = data.nameLines[currentLine];
    }

    public void GenerateOptions()
    {
        //avoiding ArgumentNullException
        if (buttonOption1Object != null)
        {
            Debug.Log("button 1 object is not null");
            buttonOption1Object.SetActive(true); // Ensure the button is active
            buttonOption1Object.GetComponentInChildren<TMP_Text>().text = data.option1Lines;

            //adding onClick event
            Button buttonComponent = buttonOption1Object.GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => StartDialogueOptions(0));
        }

        if (buttonOption2Object != null)
        {
            buttonOption2Object.SetActive(true); // Ensure the button is active
            buttonOption2Object.GetComponentInChildren<TMP_Text>().text = data.option2Lines;

            //adding onClick event
            Button buttonComponent = buttonOption2Object.GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => StartDialogueOptions(1));
        }
    }

    void ClearOptions()
    {
        if(buttonOption1Object != null)
        {
            buttonOption1Object.SetActive(false);
        }

        if (buttonOption2Object != null)
        {
            buttonOption2Object.SetActive(false);
        }
    }

    void EndDialogueOptions()
    {
        manager.CloseDialogue();
        currentLine = 0;
    }

    public void StartDialogueOptions(int optionValue)
    {

        Debug.Log("Option Chosen: " + optionValue);
        ClearOptions();
        optionChosen = true;
        optionPicked = optionValue;
        Debug.Log("Option picked: " + optionPicked);
        currentLine = 0;
        
        if (optionValue == 0)
        {
            ShowOptionDialogue(optionValue);
        }
        else if(optionValue == 1)
        {
            ShowOptionDialogue(optionValue);
        }
    }

    void ShowOptionDialogue(int optionValue)
    {
        if(optionValue == 0)
        {
            manager.dialogueText.text = data.option1Dialogue[currentLine];
            manager.nameText.text = data.option1Name[currentLine];
        }
        else if(optionValue == 1)
        {
            manager.dialogueText.text = data.option2Dialogue[currentLine];
            manager.nameText.text = data.option2Name[currentLine];
        }
    }

    void ResetOptions()
    {
        optionChosen = false;
        optionPicked = 0;
    }
}
