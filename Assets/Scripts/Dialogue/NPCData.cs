using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/New NPC Dialog")]
public class NPCData : ScriptableObject
{
    //each NPC will have their own dialogue and such,made into scriptable objects

    [Header("Dialogue Lines")]
    public string[] dialogueLines;
    public string[] nameLines;
    public string option1Lines;
    public string option2Lines;
    public string[] option1Dialogue;
    public string[] option2Dialogue;
    public string[] option1Name;
    public string[] option2Name;
    public bool hasOptions;
    public int optionIndex;
}
