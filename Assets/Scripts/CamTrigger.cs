using System.Collections;
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
    public Vector3 posOffset;

    public GameObject obj1;
    public GameObject obj2;

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
            float disToObj1 = Vector3.Distance(CameraController.me.transform.position, obj1.transform.position);
            float disToObj2 = Vector3.Distance(CameraController.me.transform.position, obj2.transform.position);
            disFraction = disToObj1 / (disToObj1 + disToObj2);
        }

        if(nonStaticAng)
        {
            myCam.transform.eulerAngles = ogAng + (angOffset * disFraction);
        }

        if(nonStaticPos)
        {
            myCam.transform.position = ogPos + (posOffset * disFraction);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            CameraController.me.ChangeCamera(myCam);
            CameraController.me.EnterTrigger();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        CameraController.me.ExitTrigger();
    }
}
