using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InvenObject inventory;
    public bool itemCanBePicked;
    GameObject itemToCollect;
    public string itemCollectedName;
    public SetDialogue setDialogue;

    void Start()
    {
        setDialogue = FindObjectOfType<SetDialogue>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Hazard")){
            Debug.Log("Player unable to proceed.");
        }

        var item = other.GetComponent<Item>();
        if(item){
            itemCanBePicked = true;
            //storing a reference to the item's game object
            itemToCollect = other.gameObject;
            Debug.Log("Item can be collected.");
        }
    }

    void OnCollect(InputValue value){
        if(value.isPressed && itemCanBePicked){
            itemCollectedName = itemToCollect.GetComponent<Item>().item.itemName;
            StartCoroutine(setDialogue.ItemCollected(itemCollectedName));
            Debug.Log("Item collected.");
            inventory.AddItem(itemToCollect.GetComponent<Item>().item, 1);
            Destroy(itemToCollect);
            itemToCollect = null;
            itemCanBePicked = false;
        }
    }

    void OnApplicationQuit(){
        inventory.Container.Clear();
    }
}
