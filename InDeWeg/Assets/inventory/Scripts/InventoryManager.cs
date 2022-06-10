using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    
    public void AddItem(Item itemToAdd)
    {
        // for loop to check if one is free, then put it in there.
        for (int i = 0; i <inventorySlots.Length ; i++)
        {
            if(inventorySlots[i].item == null) 
            {
                inventorySlots[i].AddItem(itemToAdd);
            }
        }
    }

    public void RemoveItem(int indexToRemove)
    {
         //index to remove.
    }
}
