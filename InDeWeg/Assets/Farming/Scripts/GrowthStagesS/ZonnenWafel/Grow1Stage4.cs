using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow1Stage4 : MonoBehaviour
{
    public PlantenObject Plant1Stage4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Plant1Stage4, transform.position, Quaternion.identity);
        }
    }
}