using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;

    public int slotIndex;

    public int addItemAmount = 1;

    public void AddItemSeeds(ItemSeeds itemToAddSeed)
    {
        // for loop to check if one is free, then put it in there.
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if(inventorySlots[i].itemP == null)
            {
                if (inventorySlots[i].itemS != null && inventorySlots[i].itemS.idName == itemToAddSeed.idName)
                {
                    inventorySlots[i].StackItem(addItemAmount);
                    return;
                }
                if (inventorySlots[i].itemS == null)
                {
                    inventorySlots[i].AddItemS(itemToAddSeed);

                    inventorySlots[i].StackItem(addItemAmount);
                    return;
                }
            }
        }
    }
    public void AddItemProduct(ItemProduct itemToAddProduct)
    {
        GetComponent<RequestManagerBas>().CheckIfAcceptable(0);
        GetComponent<RequestManagerBas>().CheckIfAcceptable(1);
        GetComponent<RequestManagerBas>().CheckIfAcceptable(2);

        // for loop to check if one is free, then put it in there.
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if(inventorySlots[i].itemS == null)
            {
                

                if (inventorySlots[i].itemP != null && inventorySlots[i].itemP.idName == itemToAddProduct.idName)
                {
                    inventorySlots[i].StackItem(addItemAmount);
                    return;
                }
                if (inventorySlots[i].itemP == null)
                {
                    inventorySlots[i].AddItemP(itemToAddProduct);

                    inventorySlots[i].StackItem(addItemAmount);
                    return;
                }
            }
        }
    }

    public void RemoveItem(int removeItemAmount = 1)
    {
        GetComponent<RequestManagerBas>().CheckIfAcceptable(0);
        GetComponent<RequestManagerBas>().CheckIfAcceptable(1);
        GetComponent<RequestManagerBas>().CheckIfAcceptable(2);

        if (inventorySlots[slotIndex].itemAmount == 1)
        {
            inventorySlots[slotIndex].RemoveItem();
        }
        if (inventorySlots[slotIndex].itemAmount >= 1)
        {
            inventorySlots[slotIndex].RemoveStackItem(removeItemAmount);
        }
        //index to remove.

    }

    public void SelectedSlot(int SlotSelect)
    {
        slotIndex = SlotSelect;
    }
}
