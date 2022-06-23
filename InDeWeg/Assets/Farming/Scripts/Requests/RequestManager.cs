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

    // Start is called before the first frame update
    void Start()
    {
        LoadRequests();
        CheckIfAcceptable();

        inventoryManager = GetComponent<InventoryManager>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void CheckIfAcceptable()
    {
        /*
        for (int i = 0; i < request.Length; i++)
        {
            for (int y = 0; y < request[i].item.Length; y++)
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
        */
    }
    public void LoadRequests()
    {

    }
    public void MakeRequests()
    {

    }
    public IEnumerator MakeRequestsOverTime()
    {
        yield return (requestTime);

        for (indextor = 0; indextor < request[indextor].item.Length; indextor++)
        {
            if (request[indextor].item.Length <= 3)
            {
                request[indextor].canDeliver = false;
            }
            else
            {
                requestTime += 5f;

                MakeRequests();
            }
        }
    }
}
