using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public bool canRequest;
    public int requests;

    public int[] itemRequest;
    public int[] itemAmount;
    public bool isChoosingMultipleItems;

    public int requestNumber;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (requests == 3)
        {
            canRequest = false;
        }
    }
  public void GenerateNewOrder()
    {


    }
    public void CheckIfAcceptable()
    {

    }
    public void ChoosingItems()
    {
        itemAmount[requestNumber] = Random.Range(0, 15);

        GetComponent<InventoryManager>().inventorySlots[].item.itemTag == "crop";
        
    }
    public void ChoosingMultipleItems()
    {

    }
}
