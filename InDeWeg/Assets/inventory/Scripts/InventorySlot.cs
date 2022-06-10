using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Item item;


    public void AddItem(Item itemToAdd)
    {
        item = itemToAdd;
        // set img and stuff here.
    }

    public void RemoveItem()
    {
        item = null;
        // Remove item img and stuff here.
    }
}
