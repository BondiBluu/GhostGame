using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    SetDialogue setDialogue;

    void Start()
    {
        setDialogue = FindObjectOfType<SetDialogue>();
    }

    public void ClickOption(int value)
    {
        Debug.Log("Clicked. Value: " + value);
        setDialogue.DialogueOption(value);

    }
}
