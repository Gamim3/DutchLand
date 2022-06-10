using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Inventory System",menuName ="ScriptableObject")]
public class Item : ScriptableObject
{
    public string idName;
    public string description;
    public GameObject prefab;
    public GameObject seed;

    public TMP_Text titleTXT;
    public TMP_Text descriptionTXT;
    public TMP_Text priveTXT;
   


}
