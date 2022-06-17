using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;

    public int slotIndex;

    public void AddItem(Item itemToAdd)
    {
        // for loop to check if one is free, then put it in there.
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].item != null && inventorySlots[i].item.idName == itemToAdd.idName)
            {
                inventorySlots[i].StackItem();
                return;
            }
            if (inventorySlots[i].item == null)
            {
                inventorySlots[i].AddItem(itemToAdd);

                inventorySlots[i].StackItem();
                return;
            }
        }
    }

    public void RemoveItem()
    {
        if (inventorySlots[slotIndex].itemAmount == 1)
        {
            inventorySlots[slotIndex].RemoveItem();
        }
        if (inventorySlots[slotIndex].itemAmount >= 1)
        {
            inventorySlots[slotIndex].RemoveStackItem();
        }
        //index to remove.

    }

    public void SelectedSlot(int SlotSelect)
    {
        slotIndex = SlotSelect;
    }
}