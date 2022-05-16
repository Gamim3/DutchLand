using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Zaden Object",menuName ="Inventaris Systeem/Items/Zaden")]
public class ZadenObject : ItemObject
{
    public void Awake()
    {
        types = ItemType.Zaden;
    }
}
