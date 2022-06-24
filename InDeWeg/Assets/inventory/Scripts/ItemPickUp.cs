using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemSeeds itemS;
    public ItemProduct itemP;

    public GameObject inventoryMan;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            if(other.gameObject.GetComponent<ItemDeviner>().itemP != null)
            {
                itemP = other.gameObject.GetComponent<ItemDeviner>().itemP;

                inventoryMan.GetComponent<InventoryManager>().AddItemProduct(itemP);
                Destroy(other.gameObject);
            }
            else if(other.gameObject.GetComponent<ItemDeviner>().itemS != null)
            {
                itemS = other.gameObject.GetComponent<ItemDeviner>().itemS;

                inventoryMan.GetComponent<InventoryManager>().AddItemSeeds(itemS);
                Destroy(other.gameObject);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        itemS = null;
        itemP = null;
    }
}
