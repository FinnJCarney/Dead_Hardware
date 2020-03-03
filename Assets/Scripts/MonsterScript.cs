using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    //Set Max Distance
    public float maxDistance;

    public float rotSpeed;
    public float speed;
    public float baseSpeed;
    public float minSpeed;

    bool noL;
    bool noR;

    public bool onlyMove;
    bool dontMove;

    //p stands for player, d stands for detector
    public GameObject pDObj;
    public GameObject pDObjDisplay;
    public GameObject pObj;
    public float pDMaxDistance;
    bool couldSeePlayer;
    bool canSeePlayer;

    public Vector3 pDirection;

    int timer;

    public float angle;

    public Light light;
    public float detectionTimer;
    public Color blue;
    public Color pink;
    public Color red;
    public int stateOfSeeing;

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
    }

    void FixedUpdate()
    {
        if (couldSeePlayer)
        {
            DetectionTimer();
        }

        if(stateOfSeeing == 2)
        {
            dontMove = true;
        }
        else
        {
            dontMove = false;
        }
        if (!dontMove)
        {
            Movement();
        }
        if (onlyMove)
        {
            timer++;
            if (timer > 45)
            {
                onlyMove = false;
                timer = 0;
            }
        }
    }

    void SpeedController()
    {
        float disToP = Vector3.Distance(transform.position, pObj.transform.position);
        speed = baseSpeed * (disToP / 30);
        if (speed < minSpeed)
        {
            speed = minSpeed;
        }
    }

    void PlayerDetectionRay()
    {
        pDObj.transform.LookAt(pObj.transform);
        Ray pDRay = new Ray(pDObj.transform.position, pDObj.transform.forward);
        RaycastHit pDHit;

        Debug.DrawRay(pDRay.origin, pDRay.direction * pDMaxDistance, Color.magenta);

        if (Physics.Raycast(pDRay, out pDHit, pDMaxDistance))
        {
            if (pDHit.collider.tag == "Player")
            {
                pDirection = new Vector3(transform.eulerAngles.x, pDObj.transform.eulerAngles.y, transform.eulerAngles.z);
                couldSeePlayer = true;
            }
            else
            {
                canSeePlayer = false;
                couldSeePlayer = false;
                stateOfSeeing = 1;
                detectionTimer = 0;
            }
        }
    }

    void DetectionTimer()
    {
        detectionTimer++;
        if(detectionTimer > 60)
        {
            stateOfSeeing = 3;
            canSeePlayer = true;
        }
        else
        {
            stateOfSeeing = 2;
        }

    }

    //Turns the Head and activates canSeePlayer if they are in front of the monster
    void HeadTurner()
    {
        if (couldSeePlayer)
        {
            pDObjDisplay.transform.rotation = pDObj.transform.rotation;
        }
        else
        {
            pDObjDisplay.transform.eulerAngles = transform.eulerAngles;
        }

        if(stateOfSeeing == 1)
        {
            Debug.Log("Can't See Player");
            light.color = blue;
        }
        if(stateOfSeeing == 2)
        {
            Debug.Log("Can see player a lil");
            light.color = pink;
        }
        if(stateOfSeeing == 3)
        {
            Debug.Log("Player Detected");
            light.color = red;
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
        if (!noL)
        {
            transform.Rotate(0, rotSpeed, 0);
        }

        if(!noR)
        {
            transform.Rotate(0, -rotSpeed, 0);
        }

        if (transform.eulerAngles.x != 0)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (transform.eulerAngles.z != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

        if (!noR && !noL)
        {
            int randomChance = Random.Range(0, 100);
            if (randomChance < 50)
            {
                transform.Rotate(0, 30, 0);
            }
            else
            {
                transform.Rotate(0, -30, 0);
            }
        }

        if (noR && noL)
        {
            if (canSeePlayer && !onlyMove)
            {
                //transform.eulerAngles = pDirection;    
                Debug.Log("Trying to Rotate");
                Vector3 pDir = pObj.transform.position - transform.position;
                Vector3 nDir = Vector3.RotateTowards(transform.forward, pDir, 0.025f, 0.0f);
                transform.rotation = Quaternion.LookRotation(nDir);
            }
            transform.Translate(0, 0, Time.deltaTime * speed);
        }    
    }
}
