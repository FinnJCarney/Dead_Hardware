using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController me;
    public bool inCamTrigger;

    public CameraInfo[] cameras;
    public float minDistance;

    void Awake()
    {
        StaticMe();       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!inCamTrigger)
        {
            SetAutoCamera();
        }
    }

    public void SetAutoCamera()
    {
        minDistance = Mathf.Infinity;
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].distanceToPlayer = Mathf.Abs(Vector3.Distance(this.transform.position, cameras[i].myCam.transform.position));
            minDistance = Mathf.Min(cameras[i].distanceToPlayer, minDistance);
            Debug.Log("Checked Camera " + i + " , minDistance = " + minDistance);
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            if(cameras[i].distanceToPlayer == minDistance)
            {
                ChangeCamera(cameras[i].myCam);
                Debug.Log("Attempting to Change Camera to " + i);
            }
        }
    }

    public void ChangeCamera(Camera newCam)
    {
        Camera.main.enabled = false;
        newCam.enabled = true;
    }

    void StaticMe()
    {
        me = this;
    }

    public void EnterTrigger()
    {
        inCamTrigger = true;
    }

    public void ExitTrigger()
    {
        inCamTrigger = false;
    }

}

[System.Serializable]
public struct CameraInfo
{
    public Camera myCam;
    public float distanceToPlayer;
}

