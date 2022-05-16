using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speler : MonoBehaviour
{
    public InventarisObject inventaris;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventaris.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventaris.Container.Clear();
    }

}
