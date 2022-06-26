using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public ItemSeeds itemS;
    public ItemProduct itemP;

    public int itemAmount;

    public TMP_Text itemAmountVisual;
    public TMP_Text itemNameVisual;


    private void Update()
    {
        if (itemS != null)
        {
            itemNameVisual.text = itemS.idName;
        }
        else if (itemS == null)
        {
            itemNameVisual.text = null;
        }
        if (itemP != null)
        {
            itemNameVisual.text = itemP.idName;
        }
        else if (itemP == null)
        {
            itemNameVisual.text = null;
        }

        string s = itemAmount.ToString();
        itemAmountVisual.text = s;
    }

    public void AddItemS(ItemSeeds itemToAddSeed)
    {
        itemS = itemToAddSeed;
        // set img and stuff here.
    }
    public void AddItemP(ItemProduct itemToAddProduct)
    {
        itemP = itemToAddProduct;
        // set img and stuff here.
    }

    public void RemoveItem()
    {
        itemS = null;
        itemP = null;
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
