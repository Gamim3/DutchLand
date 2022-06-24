using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RequestManager : MonoBehaviour
{
    public RequestTemplate[] request;
    public Item[] allPossibleItems;

    public GameObject[] requestItemsGO;

    private InventoryManager inventoryManager;

    public float requestTime;

    public int indextor;

    public int minimumRequestAmount;
    public int maximumRequestAmount;

    public int itemsAmount;

    public bool requestTwice;

    public int howmanyRequests;

    public Button[] deleteRequestButtonA;

    // Start is called before the first frame update
    void Start()
    {
        requestTime = 1f;

        LoadRequests();
        CheckIfAcceptable();
        StartCoroutine(MakeRequestsOverTime());

        inventoryManager = GetComponent<InventoryManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (requestTwice == true)
        {
            minimumRequestAmount = 1;
            maximumRequestAmount = 10;
        }
        else
        {
            minimumRequestAmount = 5;
            maximumRequestAmount = 15;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(MakeRequestsOverTime());
        }
    }
    public void CheckIfAcceptable()
    {
        RequestTemplate newRequest = new RequestTemplate();

        for (int i = 0; i < newRequest.item.Count; i++)
        {
            for (int y = 0; y < request[i].item.Count; y++)
            {
                for (int s = 0; s < inventoryManager.inventorySlots.Length; s++)
                {
                    if (inventoryManager.inventorySlots[s].itemS == request[i].item[y])
                    {
                        if (request[i].itemAmount[y] >= request[i].itemAmount[i])
                        {
                            request[i].canDeliver = true;
                            print("werkt");
                        }
                        else
                        {
                            request[i].canDeliver = false;
                            print("werkt niet");
                        }
                    }
                }
            }
        }
    }
    public void DeleteRequests()
    {
        //Destroy(correct panel);
    }
    public void LoadRequests()
    {

    }
    public void AcceptRequest()
    {
        RequestTemplate newRequest = new RequestTemplate();

        for (int i = 0; i < inventoryManager.inventorySlots.Length; i++)
        {
            //inventoryManager.inventorySlots[i].item.idName
        }
    }
    public void MakeRequests()
    {
        int t = Random.Range(0, 1);

        if (t == 0)
        {
            requestTwice = true;
        }
        else
        {
            print("hahah");
            requestTwice = false;
        }

        RequestTemplate newRequest = new RequestTemplate();

        for (int i = 0; i < newRequest.item.Count; i++)
        {
            if (requestTwice == true)
            {
                //item 1
                itemsAmount = Random.Range(minimumRequestAmount, maximumRequestAmount);

                if (inventoryManager.inventorySlots[i].itemS.itemTag == "crop")
                {
                    newRequest.item.Add(inventoryManager.inventorySlots[i].itemS);
                    newRequest.itemAmount.Add(itemsAmount);

                    itemsAmount = Random.Range(minimumRequestAmount, maximumRequestAmount);

                    for (int y = 0; y < newRequest.item.Count; y++)
                    {
                        if (inventoryManager.inventorySlots[i].itemS.itemTag == "crop" && inventoryManager.inventorySlots[y].itemS.idName != inventoryManager.inventorySlots[i].itemS.idName)
                        {
                            newRequest.item.Add(GetComponent<InventoryManager>().inventorySlots[y].itemS);
                            newRequest.itemAmount.Add(itemsAmount);
                        }
                    }
                }
                else
                {
                    return;
                }
                

                //item 2
                

                StartCoroutine(MakeRequestsOverTime());
            }
            else
            {
                itemsAmount = Random.Range(minimumRequestAmount, maximumRequestAmount);

                newRequest.item.Add(GetComponent<InventoryManager>().inventorySlots[i].itemS);
                newRequest.itemAmount.Add(itemsAmount);

                StartCoroutine(MakeRequestsOverTime());
            }

        }
    }
    public IEnumerator MakeRequestsOverTime()
    {
        yield return new WaitForSeconds(requestTime);

        RequestTemplate newRequest = new RequestTemplate();

        int newRandomItem = Random.RandomRange(0, allPossibleItems.Length);
        newRequest.item.Add(allPossibleItems[newRandomItem]);


        print("Vis");

        for (int i = 0; i < newRequest.item.Count; i++)
        {
            print("hagagh");

            if (howmanyRequests < 4)
            {
                MakeRequests();
            }
            else
            {
                requestTime += Random.Range(1, 15);

                howmanyRequests++;

                MakeRequests();
            }
        }
    }
}
