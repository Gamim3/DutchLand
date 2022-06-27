using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RequestManagerBas : MonoBehaviour
{
    public RequestTemplate request;

    public ItemProduct[] allItemP;

    public GameObject[] UiPannels;

    public int maxItemAmount;
    public int minItemAmount;

    public bool twoItems;

    public float requestTime = 100f;

    public int numberdRequest;
    private void Start()
    {
        RandomItemSelector(0);
    }
    public void Update()
    {

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
            UiPannels[slotIndex].GetComponent<RequestSlot>().itemTwo = null;
            UiPannels[slotIndex].GetComponent<RequestSlot>().itemTwoAmount = 0;
        }

        int newRandomTwoItems = Random.Range(0, 2);
        if(newRandomTwoItems == 0)
        {
            twoItems = true;
        }

        int newRandomItem = Random.Range(0, allItemP.Length);

        int newRandomAmount = Random.Range(minItemAmount, maxItemAmount);

        UiPannels[slotIndex].GetComponent<RequestSlot>().itemOne = allItemP[newRandomItem];
        UiPannels[slotIndex].GetComponent<RequestSlot>().itemOneAmount = newRandomAmount;

        UiPannels[numberdRequest].SetActive(true);

        if (twoItems == true)
        {
            int newRandomItemTwo = Random.Range(0, allItemP.Length);
            int newRandomAmountTwo = Random.Range(minItemAmount, maxItemAmount);
            if (newRandomItemTwo != newRandomItem)
            {
                UiPannels[slotIndex].GetComponent<RequestSlot>().itemTwo = allItemP[newRandomItemTwo];
                UiPannels[slotIndex].GetComponent<RequestSlot>().itemTwoAmount = newRandomAmountTwo;

                UiPannels[numberdRequest].SetActive(true);
            }
        }
        

        twoItems = false;

        print("request Ready");

        StartCoroutine(makeNewRequestOverTime()); 
    }

    public void CreateUi()
    {
        for(int i = 0; i < UiPannels.Length; i++)
        {
            //UiPannels[i].
        }
    }
    public void DeleteRequest(int requestButtonNumber)
    {
        numberdRequest = requestButtonNumber;

        UiPannels[numberdRequest].SetActive(false);

        UiPannels[requestButtonNumber].GetComponent<RequestSlot>().itemOne = null;

        UiPannels[requestButtonNumber].GetComponent<RequestSlot>().itemTwo = null;

        UiPannels[requestButtonNumber].GetComponent<RequestSlot>().itemOneAmount = 0;

        UiPannels[requestButtonNumber].GetComponent<RequestSlot>().itemTwoAmount = 0;

        //numberdRequest = requestButtonNumber;

        StartCoroutine(makeNewRequestOverTime());
    }
    public void HideUIPanelIfEmpty()
    {
        //UiPannels[numberdRequest].SetActive(false);
    }
    public IEnumerator makeNewRequestOverTime()
    {
        yield return new WaitForSeconds(requestTime);

        for(numberdRequest = 0; numberdRequest < UiPannels.Length; numberdRequest++)
        {
            if(UiPannels[numberdRequest].GetComponent<RequestSlot>().itemOne == null)
            {
                RandomItemSelector(numberdRequest);
            }
        }
        print("break");
    }
}
