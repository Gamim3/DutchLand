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

    public TMP_Text rewardText;

    public bool doubleOrder;

    public int requestNumber;

    public int moneyForthisRequest;

    public Button acceptButton;

    // Update is called once per frame
    private void Start()
    {
        acceptButton.interactable = false;
    }
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
        else
        {
            doubleOrder = false;
        }
        
        
    }
    public void FillRewardText(int AmountOfMoney)
    {
        rewardText.text = "€: " + AmountOfMoney.ToString();

        moneyForthisRequest = AmountOfMoney;
    }
    public void AcceptRequest(bool interactable)
    {
        acceptButton.interactable = interactable;
    }
}
