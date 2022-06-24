using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Inventory System",menuName ="seeds")]
public class ItemSeeds : ScriptableObject
{
    public string idName;

    public GameObject[] Plant;
    public GameObject crop;
    public float growTime;
   


}
