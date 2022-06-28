using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RequestManager : MonoBehaviour
{
    public RequestTemplate[] request;
    public ItemProduct[] allPossibleItems;

    public GameObject[] requestItemsGO;

    private InventoryManager inventoryManager;

    public float requestTime;

    //public int indextor;

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

        int newRandomItem = Random.Range(0, allPossibleItems.Length);

        newRequest.item.Add(allPossibleItems[newRandomItem]);
        newRequest.item.Add(allPossibleItems[newRandomItem]);
        newRequest.item.Add(allPossibleItems[newRandomItem]);
        newRequest.item.Add(allPossibleItems[newRandomItem]);
        newRequest.item.Add(allPossibleItems[newRandomItem]);

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
        howmanyRequests--;
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
        int t = Random.Range(0, 2);

        print("1");

        if (t == 0)
        {
            print("2");

            requestTwice = true;
        }
        if (t == 1)
        {
            print("2.5");

            requestTwice = false;
        }

        RequestTemplate newRequest = new RequestTemplate();

        int newRandomItem = Random.Range(0, allPossibleItems.Length);
        newRequest.item.Add(allPossibleItems[newRandomItem]);

        for (int i = 0; i < newRequest.item.Count; i++)
        {
            print("3");

            if (requestTwice == true)
            {
                print("4");
                //item 1
                itemsAmount = Random.Range(minimumRequestAmount, maximumRequestAmount);

                if (allPossibleItems[i])
                {
                    print("5");

                    newRequest.item.Add(allPossibleItems[newRandomItem]);
                    newRequest.itemAmount.Add(itemsAmount);

                    itemsAmount = Random.Range(minimumRequestAmount, maximumRequestAmount);

                    

                    for (int y = 0; y < newRequest.item.Count; y++)
                    {
                        print("6");

                        // keeps repeating it cant find a 2nd item
                        RequestTemplate new2Request = new RequestTemplate();

                        int new2RandomItem = Random.Range(0, allPossibleItems.Length);
                        new2Request.item.Add(allPossibleItems[newRandomItem]);

                        //return;

                        if (new2Request.item == newRequest.item)
                        {
                            print("7");

                            newRequest.item.Add(allPossibleItems[newRandomItem]);
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
                print("4.5");
                itemsAmount = Random.Range(minimumRequestAmount, maximumRequestAmount);

                newRequest.item.Add(GetComponent<InventoryManager>().inventorySlots[i].itemP);
                newRequest.itemAmount.Add(itemsAmount);

                //return;

                StartCoroutine(MakeRequestsOverTime());
            }

        }
    }
    public IEnumerator MakeRequestsOverTime()
    {
        yield return new WaitForSeconds(requestTime);

        RequestTemplate newRequest = new RequestTemplate();

        int newRandomItem = Random.Range(0, allPossibleItems.Length);
        newRequest.item.Add(allPossibleItems[newRandomItem]);

        if (howmanyRequests < 2)
        {
            for (int i = 0; i < newRequest.item.Count; i++)
            {
                howmanyRequests++;
                
                print("Less Than 3");

                requestTime += Random.Range(1, 2);

                MakeRequests();
                
            }
        }
    }
}
