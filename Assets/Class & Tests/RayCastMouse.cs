using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastMouse : MonoBehaviour
{
    // Set Max raycast Distance
    public float maxDistance = 1000f;
    public GameObject paintbrush;

    bool M0;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            M0 = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            M0 = false;
        }


        //Define the Ray
        //Screem point to ray
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Visualize raycast
        Debug.DrawRay(camRay.origin, camRay.direction * maxDistance, Color.magenta);

        // Detecting the object with the ray
        // (a) Detecting the object with a ray

        RaycastHit hitObject;

        if(Physics.Raycast(camRay, out hitObject, maxDistance))
        {
            //When hit, do something useful
            paintbrush.transform.position = hitObject.point;
            
            //Paint
            if (M0)
            {
                GameObject paint = Instantiate(paintbrush, hitObject.point, Quaternion.identity);
                paint.transform.SetParent(hitObject.transform);
            }

            hitObject.transform.Rotate(new Vector3(0, Time.deltaTime * 30, 0));
        }


    }
}
