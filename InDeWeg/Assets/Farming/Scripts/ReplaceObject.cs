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

            Instantiate(groundTileTilled, transform.position, Quaternion.identity);
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

            Instantiate(seeds, transform.position, Quaternion.identity);
        }
    }
}
