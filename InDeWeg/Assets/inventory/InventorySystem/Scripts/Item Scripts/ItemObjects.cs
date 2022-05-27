using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Zaden,
    Planten
}
public abstract class ItemObjects : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)]
    public string description;

}
