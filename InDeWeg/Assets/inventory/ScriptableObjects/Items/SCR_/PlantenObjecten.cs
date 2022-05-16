using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Planten Object",menuName = "Inventaris Systeem/Items/Planten")]
public class PlantenObjecten : ItemObject
{
    public void Awake()
    {
        types = ItemType.Planten;
    }
}
