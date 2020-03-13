using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Start is called before the first frame update
    public bool goUp;
    public Vector3 offset;
    public TextMesh tm;
    public Transform elevator;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(goUp)
        {
            elevator.position += offset;
        }

        if(transform.position.y > 200)
        {
            goUp = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (GameManager.me.MemoriesComplete)
            {
                goUp = true;
                PlayerMovement.me.baseSpeed = 0;
                PlayerMovement.me.sprintSpeed = 0;
            }
            else
            {
                tm.text = "Please Save Before Continuing";
            }
        }
    }
}
