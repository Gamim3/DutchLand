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
    public GameObject growth3;
    public GameObject growth4;

    public GameObject gTiledClone;
    public GameObject pPlantedClone;

    public Transform origin;

    public int groundstates;

    // Start is called before the first frame update
    void Start()
    {
        groundstates = 0;

        gTiledClone = Instantiate(groundTile, transform.position, Quaternion.identity);
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

            Destroy(gTiledClone);

            gTiledClone = Instantiate(groundTileTilled, transform.position, Quaternion.identity);
        }
        // waterd ground
        if (Toolstate == "WateringCan" && groundstates == 0)
        {
            groundstates = 2;

            Destroy(gTiledClone);

            gTiledClone = Instantiate(groundWatered, transform.position, Quaternion.identity);
        }
        // waterd tilled ground Water can last
        if (Toolstate == "WateringCan" && groundstates == 1)
        {
            groundstates = 3;

            Destroy(gTiledClone);

            gTiledClone = Instantiate(groundTileWatered, transform.position, Quaternion.identity);
        }
        // waterd tilled ground Hoe last
        if (Toolstate == "Hoe" && groundstates == 2)
        {
            groundstates = 3;

            Destroy(gTiledClone);

            gTiledClone = Instantiate(groundTileWatered, transform.position, Quaternion.identity);
        }
        // planting seeds
        if (Toolstate == "Shovel" && groundstates == 3)
        {
            groundstates = 4;

            pPlantedClone = Instantiate(seeds, transform.position, Quaternion.identity);
            StartCoroutine(Growing1());
            Destroy(pPlantedClone, 8f);
        }
    }
    public IEnumerator Growing1()
    {
        yield return new WaitForSeconds(8f);
        pPlantedClone = Instantiate(growth1, transform.position, Quaternion.identity);
        Destroy(pPlantedClone, 5f);
        StartCoroutine(Growing2());
    }
    public IEnumerator Growing2()
    {
        yield return new WaitForSeconds(5f);
        pPlantedClone = Instantiate(growth2, transform.position, Quaternion.identity);
        Destroy(pPlantedClone, 5f);
        StartCoroutine(Growing3());
    }
    public IEnumerator Growing3()
    {
        yield return new WaitForSeconds(5f);
        pPlantedClone = Instantiate(growth3, transform.position, Quaternion.identity);
        Destroy(pPlantedClone, 5f);
        StartCoroutine(Growing4());
    }
    public IEnumerator Growing4()
    {
        yield return new WaitForSeconds(5f);
        pPlantedClone = Instantiate(growth4, transform.position, Quaternion.identity);
    }
}

