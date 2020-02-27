using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastGrounded : MonoBehaviour
{
    public float castingDistance = 4;
    void Start()
    {
        
    }


    void Update()
    {
        // Declare A Ray at the point of origin and point it down

        Ray myRay = new Ray(transform.position, Vector3.down);

        // Set the Max Distance

        // Draw a debbug line that shows the ray

        Debug.DrawRay(myRay.origin, myRay.direction * castingDistance, Color.magenta);

        if(Physics.Raycast(myRay, castingDistance))
        {
            Debug.Log("Hit Ground");
        }
        else
        {
            transform.Rotate(0, 2.5f, 0);
        }
    }
}
