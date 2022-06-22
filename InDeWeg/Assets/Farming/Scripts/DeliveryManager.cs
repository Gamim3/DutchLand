using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryManager : MonoBehaviour
{
    public bool canRequest;
    public int requests;

    public int[] itemRequest;
    public int[] itemAmount;
    public bool isChoosingMultipleItems;

    public int requestNumber;
    public int itemType;

    public Button[] requestButton;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
  public void GenerateNewOrder()
    {

    }
    public void CheckIfAcceptable()
    {
        for (int i = 0; i < requestNumber; i++)
        {
            if (itemRequest[i] >= GetComponent<InventoryManager>().inventorySlots[i].itemAmount)
            {
                requestButton[i].interactable = true;
            }
            else
            {
                requestButton[i].interactable = false;
            }
        }
    }
    public void ChoosingItems()
    {
        
    }
    public void ChoosingMultipleItems()
    {

    }
}
