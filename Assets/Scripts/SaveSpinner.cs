using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSpinner : MonoBehaviour
{

    public Vector3 rotSpeed;
    public Vector3 rotAcc;

    public Vector3 accContoller;

    float slowDown;
    
    void Start()
    {
        rotSpeed.y = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotSpeed);

        rotSpeed += rotAcc;

        accContoller += Vector3.one * 5;


        //rotAcc.x = (Mathf.Sin((accContoller.x * Mathf.PI) / 180)) / 75;

        if (slowDown > 0)
        {
            rotSpeed.y -= 0.01f;
            slowDown -= 0.01f;
        }
    

        if(slowDown > 5)
        {
            slowDown = 5;
            rotSpeed.y = 5;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            rotSpeed.y += 5f;
            slowDown += 5f;
            Debug.Log("Adding Speed");
        }
    }
}
