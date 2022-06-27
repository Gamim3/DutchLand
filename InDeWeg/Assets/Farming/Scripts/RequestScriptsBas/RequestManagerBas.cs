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

    private void Start()
    {
        RandomItemSelector(0);
    }
    public void RandomItemSelector(int slotIndex)
    {
        if (twoItems == false)
        {
            UiPannels[slotIndex].GetComponent<RequestSlot>().itemTwo = null;
            UiPannels[slotIndex].GetComponent<RequestSlot>().itemTwoAmount = 0;
        }

        int newRandomTwoItems = Random.Range(0, 1);
        if(newRandomTwoItems == 0)
        {
            twoItems = true;
        }

        int newRandomItem = Random.Range(0, allItemP.Length);

        int newRandomAmount = Random.Range(minItemAmount, maxItemAmount);

        UiPannels[slotIndex].GetComponent<RequestSlot>().itemOne = allItemP[newRandomItem];
        UiPannels[slotIndex].GetComponent<RequestSlot>().itemOneAmount = newRandomAmount;

        if (twoItems == true)
        {
            int newRandomItemTwo = Random.Range(0, allItemP.Length);
            int newRandomAmountTwo = Random.Range(minItemAmount, maxItemAmount);
            if (newRandomItemTwo != newRandomItem)
            {
                UiPannels[slotIndex].GetComponent<RequestSlot>().itemTwo = allItemP[newRandomItemTwo];
                UiPannels[slotIndex].GetComponent<RequestSlot>().itemTwoAmount = newRandomAmountTwo;
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

    public IEnumerator makeNewRequestOverTime()
    {
        yield return new WaitForSeconds(2);
        for(int i = 0; i < UiPannels.Length; i++)
        {
            if(UiPannels[i].GetComponent<RequestSlot>().itemOne == null)
            {
                RandomItemSelector(i);
            }
        }
        print("break");
    }
}
