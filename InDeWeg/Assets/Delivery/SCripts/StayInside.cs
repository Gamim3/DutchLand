using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour
{
    public Transform miniMapCam;
    public float miniMapSize;
    public float clipDistance;
    public Vector3 temp;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LateUpdate()
    {
        //Center of MiniMap.
        Vector3 centerPosition = miniMapCam.transform.localPosition;

        //Keep the distance between the center close so it doesnt clip out.
        centerPosition.y -= clipDistance;

        //Distance from the GameObject to MiniMap.
        float Distance = Vector3.Distance(transform.position, centerPosition);

        // If the Distance is less than MinimapSize, it is within the Minimap view and we don't need to do anything
        // But if the Distance is greater than the MinimapSize, then do this
        if (Distance > miniMapSize)
        {
            // Gameobject - Minimap
            Vector3 fromOriginToObject = transform.position - centerPosition;

            // Multiply by MinimapSize and Divide by Distance
            fromOriginToObject *= miniMapSize / Distance;

            // Minimap + above calculation
            transform.position = centerPosition + fromOriginToObject;
        }
    }
}
