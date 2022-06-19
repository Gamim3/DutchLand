using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Item item;

    public int itemAmount;

    public TMP_Text itemAmountVisual;
    public TMP_Text itemNameVisual;


    private void Update()
    {
        if (item != null)
        {
            itemNameVisual.text = item.idName;
        }
        else if (item == null)
        {
            itemNameVisual.text = null;
        }
        
        string s = itemAmount.ToString();
        itemAmountVisual.text = s;
    }

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
    public void StackItem(int addItemAmount)
    {
        itemAmount += addItemAmount;
    }
    public void RemoveStackItem(int removeItemAmount)
    {
        itemAmount -= removeItemAmount;
    }
}
