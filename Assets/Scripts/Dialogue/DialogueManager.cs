using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue Boxes and Text")]
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject nameBox;
    public TMP_Text dialogueText;
    public TMP_Text nameText;

    [Header("Dialogue Buttons")]
    public GameObject option1Button;
    public GameObject option2Button;
    public Transform option1Transform;
    public Transform option2Transform;

    [Header("Items")]
    public GameObject itemBox;
    public TMP_Text itemText;

    public bool dialogeActive = false;

    void Start()
    {
        CloseDialogue();
        ItemTellerOff();
    }

    public void ItemTellerOff(){
        itemBox.SetActive(false);
    }

    public void ItemTellerOn(){
        itemBox.SetActive(true);
    }
    
    public void OpenDialogue(){
        dialogueBox.SetActive(true);
        nameBox.SetActive(true);
        dialogeActive = true;
    }

    public void CloseDialogue(){
        dialogeActive = false;
        dialogueBox.SetActive(false);
        nameBox.SetActive(false);
        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);
    }
}
