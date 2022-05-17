using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayInventaris : MonoBehaviour
{
    public InventarisObject inventaris;
    public int x_Space_Between_Items;
    public int number_Of_Column;
    public int y_Space_Between_Items;

    Dictionary<InventarisSlot, GameObject> itemsDisplayed = new Dictionary<InventarisSlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for(int i = 0; i < inventaris.Container.Count; i++)
        {
            var obj = Instantiate(inventaris.Container[i].item.prefabs, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventaris.Container[i].amount.ToString("n0");
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(x_Space_Between_Items * (i % number_Of_Column), (-y_Space_Between_Items * (i / number_Of_Column)), 0f);
    }
}
