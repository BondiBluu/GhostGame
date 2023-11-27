using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetDialogue : MonoBehaviour
{
    DialogueManager manager;
    bool inRange = false;
    int currentLine = 0;
    [SerializeField] NPCData data;

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
    }

    void ShowDialogue()
    {
        manager.dialogueText.text = data.dialogueLines[currentLine];
        manager.nameText.text = data.nameLines[currentLine];
    }

    
}
