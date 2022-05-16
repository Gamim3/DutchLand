using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Zaden,
    Planten
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefabs;
    public ItemType types;
    [TextArea(15,20)]
    public string description;
}
