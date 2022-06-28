using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RequestSlot : MonoBehaviour
{
    public ItemProduct itemOne;
    public ItemProduct itemTwo;

    public int itemOneAmount;
    public int itemTwoAmount;

    public TMP_Text itemTextDisplayOne;
    public TMP_Text itemAmountDisplayOne;

    public TMP_Text itemTextDisplayTwo;
    public TMP_Text itemAmountDisplayTwo;

    public TMP_Text reward;

    public bool doubleOrder;

    // Update is called once per frame
    void Update()
    {
        if(itemOne != null)
        {
            itemTextDisplayOne.text = itemOne.idName;
            itemAmountDisplayOne.text = itemOneAmount.ToString();
        }
        else if(itemOne == null)
        {
            itemTextDisplayOne.text = null;
            itemAmountDisplayOne.text = null;
        }
        if (itemTwo != null)
        {
            itemTextDisplayTwo.text = itemTwo.idName;
            itemAmountDisplayTwo.text = itemTwoAmount.ToString();
        }
        else if (itemTwo == null)
        {
            itemTextDisplayTwo.text = null;
            itemAmountDisplayTwo.text = null;
        }

        if (itemOne != null && itemTwo != null)
        {
            doubleOrder = true;
        }
    }
}
