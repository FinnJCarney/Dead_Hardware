using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastRoomba : MonoBehaviour
{
    //Set Max Distance
    public float maxDistance = 2f;

    public float speed = 0.5f;

    void Update()
    {
        // Define Ray

        Ray roombaRay = new Ray(transform.position, transform.forward);

        // Draw Debug Ray
        Debug.DrawRay(roombaRay.origin, roombaRay.direction * maxDistance, Color.cyan);

        //Shoot RayCast

        if (Physics.Raycast(roombaRay, maxDistance))
        {
            int randomNumber = Random.Range(0, 100);
            if(randomNumber < 50)
            {
                //transform.Rotate(0, 90, 0);
                transform.Rotate(0, 10, 0);
            }
            else
            {
                //transform.Rotate(0, -90, 0);
                transform.Rotate(0, -10, 0);
            }
        }
        else
        {
            transform.Translate(0, 0, Time.deltaTime * speed);
        }
    }
}
