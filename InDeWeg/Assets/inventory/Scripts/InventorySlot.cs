using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Item item;

    public int itemAmount;

    public TMP_Text Amount;


    private void Update()
    {
        string s = itemAmount.ToString();
        Amount.text = s;
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
