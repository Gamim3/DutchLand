using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public TMP_Text titleTXT;
    public TMP_Text descriptionTXT;
    public TMP_Text costTXT;

    public GameObject stage0;
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;

}
