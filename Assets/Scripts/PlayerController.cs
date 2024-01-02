using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InvenObject inventory;
    public bool itemCanBePicked;
    GameObject itemToCollect;

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
            // inventory.AddItem(item.item, 1);
            // Destroy(other.gameObject);
        }
    }

    void OnCollect(InputValue value){
        if(value.isPressed && itemCanBePicked){
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
