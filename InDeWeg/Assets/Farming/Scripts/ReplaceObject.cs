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

    public bool canPlace;
    // Start is called before the first frame update
    void Start()
    {
        replaceO = false;
        replaceT = false;
        replaceW = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Replace(int GroundState)
    {
        if (GroundState == 0 && groundstates !< 1 && groundstates !> 0 && canPlace == true)
        {
            Instantiate(groundTile, transform.position, Quaternion.identity);
            Destroy(groundTile);
            canPlace = false;
            groundstates =
        }
        if (GroundState == 1 && groundstates !< 2 && groundstates! > 0)
        {
            Instantiate(groundTileTilled, transform.position, Quaternion.identity);
        }
        if (GroundState == 2)
        {
            Instantiate(groundTileWatered, transform.position, Quaternion.identity);
        }
    }
}
