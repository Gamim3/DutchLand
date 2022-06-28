using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RequestManagerBas : MonoBehaviour
{
    public RequestTemplate request;

    public ItemProduct[] allItemP;

    public GameObject[] uiPannels;
    public GameObject[] requestManagerGO;

    public bool hidden;

    public int maxItemAmount;
    public int minItemAmount;

    public bool twoItems;

    public float requestTime = 100f;

    public int numberdRequest;

    public int baseWorthForItem;

    public int itemWorthOne;
    public int itemWorthTwo;
    public int requestWorth;


    private void Start()
    {
        hidden = true;
        RewardCalculations();
        RandomItemSelector(0);
    }
    public void Update()
    {

    }
    public void RewardCalculations()
    {
        baseWorthForItem = uiPannels[numberdRequest].GetComponent<RequestSlot>().itemOne.waarde;

        baseWorthForItem *= uiPannels[numberdRequest].GetComponent<RequestSlot>().itemOneAmount;

        itemWorthOne = baseWorthForItem;

        print(itemWorthOne);

        if (uiPannels[numberdRequest].GetComponent<RequestSlot>().doubleOrder == true)
        {
            baseWorthForItem = uiPannels[numberdRequest].GetComponent<RequestSlot>().itemOne.waarde;

            baseWorthForItem *= uiPannels[numberdRequest].GetComponent<RequestSlot>().itemOneAmount;

            itemWorthTwo = baseWorthForItem;

            itemWorthOne += itemWorthTwo = requestWorth;

            print(requestWorth);

            GetComponent<ShopManager>().AddCoins(requestWorth);
        }
        else
        {
            GetComponent<ShopManager>().AddCoins(itemWorthOne);
        }
        //baseCostForItem += itemAmount + baseCostForitem2 + itemTwoAmount


    }
    public void RandomItemSelector(int slotIndex)
    {
        //requestTime += Random.Range(-10, 10);

        //if (requestTime >= 0)
        //{
           // requestTime = Random.Range(5, 15);
        //}

        if (twoItems == false)
        {
            uiPannels[slotIndex].GetComponent<RequestSlot>().itemTwo = null;
            uiPannels[slotIndex].GetComponent<RequestSlot>().itemTwoAmount = 0;
        }

        int newRandomTwoItems = Random.Range(0, 2);
        if(newRandomTwoItems == 0)
        {
            twoItems = true;
        }

        int newRandomItem = Random.Range(0, allItemP.Length);

        int newRandomAmount = Random.Range(minItemAmount, maxItemAmount);

        uiPannels[slotIndex].GetComponent<RequestSlot>().itemOne = allItemP[newRandomItem];
        uiPannels[slotIndex].GetComponent<RequestSlot>().itemOneAmount = newRandomAmount;

        uiPannels[numberdRequest].SetActive(true);

        if (twoItems == true)
        {
            int newRandomItemTwo = Random.Range(0, allItemP.Length);
            int newRandomAmountTwo = Random.Range(minItemAmount, maxItemAmount);
            if (newRandomItemTwo != newRandomItem)
            {
                uiPannels[slotIndex].GetComponent<RequestSlot>().itemTwo = allItemP[newRandomItemTwo];
                uiPannels[slotIndex].GetComponent<RequestSlot>().itemTwoAmount = newRandomAmountTwo;

                uiPannels[numberdRequest].SetActive(true);
            }
        }
        

        twoItems = false;

        print("request Ready");

        RewardCalculations();
        StartCoroutine(makeNewRequestOverTime()); 
    }

    public void CreateUi()
    {
        for(int i = 0; i < uiPannels.Length; i++)
        {
            //UiPannels[i].
        }
    }
    public void DeleteRequest(int requestButtonNumber)
    {
        numberdRequest = requestButtonNumber;

        uiPannels[numberdRequest].SetActive(false);

        uiPannels[requestButtonNumber].GetComponent<RequestSlot>().itemOne = null;

        uiPannels[requestButtonNumber].GetComponent<RequestSlot>().itemTwo = null;

        uiPannels[requestButtonNumber].GetComponent<RequestSlot>().itemOneAmount = 0;

        uiPannels[requestButtonNumber].GetComponent<RequestSlot>().itemTwoAmount = 0;

        //numberdRequest = requestButtonNumber;

        StartCoroutine(makeNewRequestOverTime());
    }
    public void HideRequestUI()
    {
        if (hidden == true)
        {
            requestManagerGO[0].SetActive(true);
            requestManagerGO[1].SetActive(true);

            hidden = false;
            return;
        }

        if (hidden == false)
        {
            requestManagerGO[0].SetActive(false);
            requestManagerGO[1].SetActive(false);

            hidden = true;
            return;
        }

    }

    public IEnumerator makeNewRequestOverTime()
    {
        yield return new WaitForSeconds(requestTime);

        for(numberdRequest = 0; numberdRequest < uiPannels.Length; numberdRequest++)
        {
            if(uiPannels[numberdRequest].GetComponent<RequestSlot>().itemOne == null)
            {
                RandomItemSelector(numberdRequest);
            }
        }
        print("break");
    }
}
