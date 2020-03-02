using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement me;

    Rigidbody rb;

    public Vector3 velocity;
    public float rotation;

    public float moveSpeed;
    public float rotateSpeed;

    public bool w;
    public bool s;
    public bool a;
    public bool d;

    public bool reverse;

    public bool noVel;
    public bool noRot;

    public float maxRayDis;
    public float floorOffset;

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

    void Movement()
    {
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
