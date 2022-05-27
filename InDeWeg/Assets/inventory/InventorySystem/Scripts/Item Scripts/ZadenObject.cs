using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Zaden Object", menuName = "Inventory System/Items/Zaden")]
public class ZadenObject : ItemObjects
{
    public void Awake()
    {
        type = ItemType.Zaden;
    }

}
