using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement me;

    Rigidbody rb;

    public Vector3 velocity;
    public float rotation;

    public float baseSpeed;
    public float sprintSpeed;
    public float moveSpeed;
    public float baseRotate;
    public float sprintRotate;
    public float rotateSpeed;

    public bool w;
    public bool s;
    public bool a;
    public bool d;
    public bool space = true;

    public bool reverse;

    public bool noVel;
    public bool noRot;

    public float maxRayDis;
    public float floorOffset;

    public int sprintTimer;

    void Awake()
    {
        me = this;
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Inputs();
    }

    void FixedUpdate()
    {
        //FloorCast();
        SprintTimer();
        Movement();    
    }

    void Inputs()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            w = true;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            w = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            s = true;
            reverse = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            s = false;
            reverse = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            a = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            a = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            d = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            d = false;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            space = true;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            space = false;
        }

        if(!w && !s)
        {
            noVel = true;
        }
        else
        {
            noVel = false;
        }

        if(!a && !d)
        {
            noRot = true;
        }
        else
        {
            noRot = false;
        }
    }

    void SprintTimer()
    {
        if(space)
        {
            sprintTimer--;
        }
        else if (sprintTimer < 240)
        {
            sprintTimer++;
        }
    }

    void Movement()
    {
        if(space && sprintTimer > 40)
        {
            moveSpeed = sprintSpeed;
            rotateSpeed = sprintRotate;
        }
        else
        {
            moveSpeed = baseSpeed;
            rotateSpeed = baseRotate;
        }

        if (w)
        {
            velocity = transform.forward * moveSpeed;
        }

        if(s)
        {
            velocity = transform.forward * -moveSpeed;
        }

        if(noVel)
        {
            velocity = Vector3.zero;
        }

        if((a && !reverse) || (d && reverse))
        {
            rotation = -rotateSpeed;
        }

        if ((d && !reverse)|| (a && reverse))
        {
            rotation = rotateSpeed;
        }

        if(noRot)
        {
            rotation = 0;
        }

        transform.Rotate(0, rotation, 0);
        rb.MovePosition(transform.position + velocity);
    }
}
