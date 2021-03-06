﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{

    public Camera myCam;

    public bool nonStaticAng;
    public Vector3 ogAng;
    public Vector3 angOffset;

    public bool nonStaticPos;
    public Vector3 ogPos;

    public cameraObj[] cameraObjs;
    public float totalDis;

    public float disFraction;

    // Start is called before the first frame update
    void Start()
    {
        ogAng = myCam.transform.eulerAngles;
        ogPos = myCam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (nonStaticAng || nonStaticPos)
        {
            totalDis = 0;
            for (int i = 0; i < cameraObjs.Length; i++)
            {
                cameraObjs[i].disToObj = 1 / Vector3.Distance(CameraController.me.transform.position, cameraObjs[i].obj.transform.position);
                totalDis += cameraObjs[i].disToObj;
            }
        }

        if(nonStaticAng)
        {
            Vector3 newAng = Vector3.zero;
            for (int i = 0; i < cameraObjs.Length; i++)
            {
                newAng += (cameraObjs[i].rotOffset * (cameraObjs[i].disToObj / totalDis));
            }
            myCam.transform.eulerAngles = ogAng + newAng;
        }

        if(nonStaticPos)
        {
            Vector3 newPos = Vector3.zero;
            for (int i = 0; i < cameraObjs.Length; i++)
            {
                newPos += (cameraObjs[i].posOffset * (cameraObjs[i].disToObj / totalDis));
            }
            myCam.transform.position = ogPos + newPos;
        }

    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            //myCam.enabled = true;
            CameraController.me.ChangeCamera(myCam);
            //CameraController.me.EnterTrigger();
            Debug.Log(this.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!PlayerMovement.me.goingUp)
            {
                //myCam.enabled = false;
                //CameraController.me.ExitTrigger();
                Debug.Log("Exited Sucessfully");
            }
            else if(PlayerMovement.me.transform.position.y > 180)
            {
                Destroy(this);
            }
        }
    }
}

[System.Serializable]
public struct cameraObj
{
    public GameObject obj;
    public float disToObj;
    public Vector3 posOffset;
    public Vector3 rotOffset;
}
