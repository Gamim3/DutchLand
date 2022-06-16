using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item")
        {
            item = other.gameObject.GetComponent<ItemDeviner>().item;

            GetComponent<InventoryManager>().AddItem(item);
            Destroy(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        item = null;
    }
}
