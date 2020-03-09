using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCam : MonoBehaviour
{

    public bool canSeePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(CameraController.me.transform.position);

        Ray pDRay = new Ray(transform.position, transform.forward);
        RaycastHit pDHit;

        Debug.DrawRay(pDRay.origin, pDRay.direction * 1000, Color.magenta);

        if (Physics.Raycast(pDRay, out pDHit, 1000))
        {
            if (pDHit.collider.tag == "PlayerCamera")
            {
                canSeePlayer = true;
            }
            else
            {
                canSeePlayer = false;
            }
        }
    }
}
