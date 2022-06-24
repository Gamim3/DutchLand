using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RequestManager : MonoBehaviour
{
    public RequestTemplate[] request;
    public Item[] item;

    public GameObject[] requestItemsGO;

    private InventoryManager inventoryManager;

    public float requestTime;

    public int indextor;

    public int minimumRequestAmount;
    public int maximumRequestAmount;

    public int itemsAmount;

    public bool requestTwice;

    // Start is called before the first frame update
    void Start()
    {
        requestTime = 1f;

        print("dit deel werkt4");

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
        for (int i = 0; i < request.Length; i++)
        {
            for (int y = 0; y < request[i].item.Count; y++)
            {
                for (int s = 0; s < inventoryManager.inventorySlots.Length; s++)
                {
                    if (inventoryManager.inventorySlots[s].item == request[i].item[y])
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
    public void LoadRequests()
    {
        
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
            requestTwice = false;
        }

        RequestTemplate newRequest = new RequestTemplate();

        for (int i = 0; i < request.Length; i++)
        {
            if (requestTwice == true)
            {
                //item 1
                itemsAmount = Random.Range(minimumRequestAmount, maximumRequestAmount);

                newRequest.item.Add(GetComponent<InventoryManager>().inventorySlots[i].item);
                newRequest.itemAmount.Add(itemsAmount);

                //item 2
                itemsAmount = Random.Range(minimumRequestAmount, maximumRequestAmount);

                i++;

                newRequest.item.Add(GetComponent<InventoryManager>().inventorySlots[i].item);
                newRequest.itemAmount.Add(itemsAmount);

                i--;

                StartCoroutine(MakeRequestsOverTime());
            }
            else
            {
                itemsAmount = Random.Range(minimumRequestAmount, maximumRequestAmount);

                newRequest.item.Add(GetComponent<InventoryManager>().inventorySlots[i].item);
                newRequest.itemAmount.Add(itemsAmount);

                StartCoroutine(MakeRequestsOverTime());
            }

        }
    }
    public IEnumerator MakeRequestsOverTime()
    {
        yield return new WaitForSeconds(requestTime);

        print("dit deel werkt3");

        for (int i = 0; i < request[i].item.Count; i++)
        {
            if (request[i].item.Count <= 3)
            {
                print("dit deel werkt2");
            }
            else
            {
                print("dit deel werkt");

                requestTime += Random.Range(-15, 15);

                MakeRequests();
            }
        }
    }
}
