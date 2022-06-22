using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Request", menuName = "Scriptable Objects/New Request", order = 2)]
public class RequestSO : ScriptableObject
{
    public string itemTXT;
    public int amountTXT;
    public string item2TXT;
    public int amonunt2TXT;
}
