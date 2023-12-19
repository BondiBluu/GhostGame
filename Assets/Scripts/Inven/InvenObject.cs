using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "InventorySystem/Inventory")]
public class InvenObject : ScriptableObject
{
    //storing the types of items inventory slots
    public List<InventorySlot> Container = new List<InventorySlot>();

    //adding items to inven
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        //checking if the item is already in the inventory
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        //if the item is not in the inventory, add it
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
}

[System.Serializable]
//holding the types and amount of items held in the slots of the above list
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    //constructor
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    //adding amounts
    public void AddAmount(int value)
    {
        amount += value;
    }
}
