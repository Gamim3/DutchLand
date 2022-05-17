using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceObject : MonoBehaviour
{
    public bool replaceO;
    public bool replaceT;
    public bool replaceW;

    public GameObject groundTile;
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
        // if ground tiles will be placeable
        //if (GroundState == 0 && replaceO == true)
       // {
            //Instantiate(groundTile, transform.position, Quaternion.identity);
            //Destroy(groundTile);
            //replaceO = false;
            //groundstates = 0;
       // }
        if (GroundState == 1 && groundstates == 0)
        {
            Instantiate(groundTileTilled, transform.position, Quaternion.identity);
            Destroy(groundTile);
            groundstates = 1;
        }
        if (GroundState == 2 && groundstates == 1)
        {
            
            Instantiate(groundTileWatered, transform.position, Quaternion.identity);

            groundstates = 2;
        }
    }
}
