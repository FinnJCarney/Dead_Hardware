using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastRoomba2 : MonoBehaviour
{
    //Set Max Distance
    public float maxDistance;

    public float rotSpeed;
    public float speed;
    public float baseSpeed;

    bool noL;
    bool noR;

    public bool onlyMove;
    bool dontMove;

    //p stands for player, d stands for detector
    public GameObject pDObj;
    public GameObject pDObjDisplay;
    public GameObject pObj;
    public float pDMaxDistance;
    bool canSeePlayer;

    Vector3 pDirection;

    int timer;

    void Awake()
    {
        //pObj = PlayerMovement.me;
    }

    void Update()
    {
        SpeedController();
        PlayerDetectionRay();
        HeadTurner();
        CloseRangeRays();
        Movement();      
    }

    void FixedUpdate()
    {
        if(onlyMove)
        {
            timer++;
            if(timer > 45)
            {
                onlyMove = false;
                timer = 0;
            }
        }
    }

    void SpeedController()
    {
        float disToP = Vector3.Distance(transform.position, pObj.transform.position);
        speed = baseSpeed * (disToP / 40);
        if(speed < 12)
        {
            speed = 12;
        }
    }

    void PlayerDetectionRay()
    {
        pDObj.transform.LookAt(pObj.transform);
        Ray pDRay = new Ray(pDObj.transform.position, pDObj.transform.forward);
        RaycastHit pDHit;

        Debug.DrawRay(pDRay.origin, pDRay.direction * pDMaxDistance, Color.magenta);

        if(Physics.Raycast(pDRay, out pDHit, pDMaxDistance))
        {
            if(pDHit.collider.tag == "Player")
            {
                pDirection = new Vector3(transform.eulerAngles.x, pDObj.transform.eulerAngles.y, transform.eulerAngles.z);
                canSeePlayer = true;
            }
            else
            {
                canSeePlayer = false;
            }
        }
    }

    //Turns the Head and activates canSeePlayer if they are in front of the monster
    void HeadTurner()
    {
        if(Mathf.Abs(transform.rotation.y) - Mathf.Abs(pDirection.y) < 90 && canSeePlayer)
        {
            pDObjDisplay.transform.rotation = pDObj.transform.rotation;
        }
        else
        {
            pDObjDisplay.transform.eulerAngles = transform.eulerAngles;
        }
    }

    void CloseRangeRays()
    {
        // Define Ray

        Ray roombaRayL = new Ray(transform.position, transform.forward - transform.right);
        Ray roombaRayR = new Ray(transform.position, transform.forward + transform.right);

        // Draw Debug Ray
        Debug.DrawRay(roombaRayL.origin, roombaRayL.direction * maxDistance, Color.cyan);
        Debug.DrawRay(roombaRayR.origin, roombaRayR.direction * maxDistance, Color.cyan);

        //Shoot RayCast

        if (Physics.Raycast(roombaRayL, maxDistance))
        {
            transform.Rotate(0, rotSpeed, 0);
            noL = false;
            onlyMove = true;
            timer = 0;
        }
        else
        {
            noL = true;
        }

        if (Physics.Raycast(roombaRayR, maxDistance))
        {
            transform.Rotate(0, -rotSpeed, 0);
            noR = false;
            onlyMove = true;
            timer = 0;
        }
        else
        {
            noR = true;
        }
    }

    void Movement()
    {
        if (!noR && !noL)
        {
            int randomChance = Random.Range(0, 100);
            if (randomChance < 50)
            {
                transform.Rotate(0, 100, 0);
            }
            else
            {
                transform.Rotate(0, -100, 0);
            }
        }

        if (noR && noL)
        {
            if(canSeePlayer && !onlyMove)
            {
                transform.eulerAngles = pDirection;
                //Debug.Log("Trying to Rotate");
                //if (Mathf.Abs(transform.eulerAngles.y + pDirection.y) > 30)
                //{
                //    Debug.Log("Trying to Rotate Postivly");
                //    transform.Rotate(0, rotSpeed, 0);
                //}
                //else if(Mathf.Abs(transform.eulerAngles.y - pDirection.y) > 30)
                //{
                //    Debug.Log("Trying to Rotate Negativly");
                //    transform.Rotate(0, -rotSpeed, 0);
                //}
            }
            transform.Translate(0, 0, Time.deltaTime * speed);
        }
    }
}
