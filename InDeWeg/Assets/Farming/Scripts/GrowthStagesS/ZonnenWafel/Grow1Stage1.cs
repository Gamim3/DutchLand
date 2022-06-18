using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow1Stage1 : MonoBehaviour
{
    public GameObject nextGrowthStage;

    public float growthTime;

    public GameObject clonePlant;

    

    // Start is called before the first frame update
    void Start()
    {
        

        StartCoroutine(Growing());
    }
    // Update is called once per frame
    public IEnumerator Growing()
    {
        yield return new WaitForSeconds(growthTime);

        clonePlant = Instantiate(nextGrowthStage, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
