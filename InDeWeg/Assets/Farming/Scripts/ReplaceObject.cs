using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceObject : MonoBehaviour
{
    public bool replaceO;
    public bool replaceT;
    public bool replaceW;

    public GameObject groundTile;
    public GameObject groundWatered;
    public GameObject groundTileTilled;
    public GameObject groundTileWatered;

    public Transform origin;

    public int groundstates;

    // Start is called before the first frame update
    void Start()
    {
        replaceO = false;
        replaceT = false;
        replaceW = false;

        groundstates = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Replace(int GroundState)
    {
        // tilled ground
        if (GroundState == 1 && groundstates == 0)
        {
            Instantiate(groundTileTilled, transform.position, Quaternion.identity);

            groundstates = 1;
        }
        // waterd ground
        if (GroundState == 3 && groundstates == 0)
        {
            Instantiate(groundWatered, transform.position, Quaternion.identity);

            groundstates = 3;
        }
        // waterd tilled ground Water can last
        if (GroundState == 2)
        {
            if (groundstates == 1)
            {
                Instantiate(groundTileWatered, transform.position, Quaternion.identity);

                groundstates = 2;
            }
        }
        // waterd tilled ground Hoe last
        if (GroundState == 4)
        {
            if (groundstates == 3)
            {
                Instantiate(groundTileWatered, transform.position, Quaternion.identity);

                groundstates = 2;
            }
        }
    }
}
