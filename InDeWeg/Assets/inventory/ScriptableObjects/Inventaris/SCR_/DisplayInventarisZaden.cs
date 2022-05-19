using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayInventarisZaden : MonoBehaviour
{
    public InventarisObject inventaris;

    public int x_Start_Zaden;
    public int y_Start_Zaden;
    public int x_Space_Between_Items_Zaden;
    public int number_Of_Column_Zaden;
    public int y_Space_Between_Items_Zaden;

    Dictionary<InventarisSlot, GameObject> itemsDisplayed = new Dictionary<InventarisSlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i <inventaris.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventaris.Container[i]))
            {
                itemsDisplayed[inventaris.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventaris.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventaris.Container[i].item.prefabs, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventaris.Container[i].amount.ToString("n0");

                itemsDisplayed.Add(inventaris.Container[i], obj);
            }
        }
    }

    public void CreateDisplay()
    {
        for(int i = 0; i < inventaris.Container.Count; i++)
        {
            var obj = Instantiate(inventaris.Container[i].item.prefabs, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventaris.Container[i].amount.ToString("n0");

            itemsDisplayed.Add(inventaris.Container[i], obj);
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(x_Start_Zaden + (x_Space_Between_Items_Zaden * (i % number_Of_Column_Zaden)), y_Start_Zaden + (-y_Space_Between_Items_Zaden * (i % number_Of_Column_Zaden)), 0f);
    }


}
