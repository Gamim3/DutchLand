using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow1Stage3 : MonoBehaviour
{
    public PlantenObject Plant1Stage3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Plant1Stage3, transform.position, Quaternion.identity);
        }
    }
    public void PlaceGrowthStage3()
    {
        StartCoroutine(Growing());
    }
    public IEnumerator Growing()
    {
        yield return new WaitForSeconds(Plant1Stage3.growthTime);
        Instantiate(Plant1Stage3.plant, transform.position, Quaternion.identity);
    }
}