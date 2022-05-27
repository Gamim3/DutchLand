using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Planten Object", menuName = "Inventory System/Items/Planten")]
public class PlantenObject : ItemObjects
{
    public void Awake()
    {
        type = ItemType.Planten;
    }
}