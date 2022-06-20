using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public GameObject[] deliveryPlace;

    public int[] numberPlace;

    public GameObject[] outline;

    public bool sceneSwitch;

    public int[] itemAmountRequested;

    public int[] itemTypeRequested;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sceneSwitch == true)
        {
            numberPlace[0] = Random.Range(0, 2);

            Instantiate(outline[0], deliveryPlace[numberPlace[0]].transform.position, Quaternion.identity);

            numberPlace[1] = Random.Range(3, 6);

            Instantiate(outline[1], deliveryPlace[numberPlace[1]].transform.position, Quaternion.identity);

            numberPlace[2] = Random.Range(7, 9);

            Instantiate(outline[2], deliveryPlace[numberPlace[2]].transform.position, Quaternion.identity);

            sceneSwitch = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<InventoryManager>().RemoveItem(itemAmountRequested[0]);
        }
    }
    public void RequestItem()
    {
        itemTypeRequested[0] = Random.Range(1, 3);
        itemTypeRequested[1] = Random.Range(1, 3);
        itemTypeRequested[2] = Random.Range(1, 3);

        itemAmountRequested[0] = Random.Range(1, 5);
        itemAmountRequested[1] = Random.Range(1, 5);
        itemAmountRequested[2] = Random.Range(1, 5);
        itemAmountRequested[3] = Random.Range(1, 5);


        //GetComponent<InventoryManager>().inventorySlots[].itemAmount;
    }
}
