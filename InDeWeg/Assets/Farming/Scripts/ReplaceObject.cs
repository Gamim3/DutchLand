using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceObject : MonoBehaviour
{
    public GameObject groundTile;
    public GameObject groundWatered;
    public GameObject groundTileTilled;
    public GameObject groundTileWatered;

    public GameObject seeds;
    public GameObject growth1;
    public GameObject growth2;

    public Transform origin;

    public int groundstates;

    // Start is called before the first frame update
    void Start()
    {
        groundstates = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Replace(string Toolstate)
    {
        // tilled ground
        if (Toolstate == "Hoe" && groundstates == 0)
        {
            groundstates = 1;

            GameObject gTClone = Instantiate(groundTileTilled, transform.position, Quaternion.identity);
        }
        // waterd ground
        if (Toolstate == "WateringCan" && groundstates == 0)
        {
            groundstates = 2;

            Instantiate(groundWatered, transform.position, Quaternion.identity);
        }
        // waterd tilled ground Water can last
        if (Toolstate == "WateringCan" && groundstates == 1)
        {
            groundstates = 3;

            Instantiate(groundTileWatered, transform.position, Quaternion.identity);
        }
        // waterd tilled ground Hoe last
        if (Toolstate == "Hoe" && groundstates == 2)
        {
            groundstates = 3;

            Instantiate(groundTileWatered, transform.position, Quaternion.identity);
        }
        // planting seeds
        if (Toolstate == "Shovel" && groundstates == 3)
        {
            groundstates = 4;

            GameObject seedsClone = Instantiate(seeds, transform.position, Quaternion.identity);
            StartCoroutine(Growing1());
            Destroy(seedsClone, 8f);
        }
    }
    public IEnumerator Growing1()
    {
        yield return new WaitForSeconds(8f);
        GameObject growth1clone = Instantiate(growth1, transform.position, Quaternion.identity);
        Destroy(growth1clone, 5f);
        StartCoroutine(Growing2());
    }
    public IEnumerator Growing2()
    {
        yield return new WaitForSeconds(5f);
        GameObject growth2clone = Instantiate(growth2, transform.position, Quaternion.identity);
    }
}

