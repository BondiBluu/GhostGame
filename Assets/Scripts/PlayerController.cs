using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InvenObject inventory;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Hazard")){
            Debug.Log("Player unable to proceed.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
