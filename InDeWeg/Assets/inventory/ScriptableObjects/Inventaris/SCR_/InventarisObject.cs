using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Inventaris",menuName ="Inventaris Systeem/Inventaris")]
public class InventarisObject : ScriptableObject
{
    public List<InventarisSlot> Container = new List<InventarisSlot>();
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i<Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new InventarisSlot(_item, _amount));
        }

    }
}

[System.Serializable]
public class InventarisSlot
{
    public ItemObject item;
    public int amount;
    public InventarisSlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
