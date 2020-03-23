using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController me;
    public bool inCamTrigger;

    public CameraInfo[] cameras;
    public float minDistance;

    public Camera currentCam;
    public Camera mainCamera;
    public RenderTexture rT;

    public bool kill;
    public Camera killCam;

    public Rigidbody rb;

    void Awake()
    {
        StaticMe();       
    }

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.enabled = false;
        mainCamera.enabled = true;

        transform.position = PlayerMovement.me.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inCamTrigger)
        {
            SetAutoCamera();
        }

        if (kill)
        {
            currentCam.enabled = false;
            killCam.enabled = true;
            killCam.targetTexture = rT;
        }

        transform.position = Vector3.Lerp(transform.position, PlayerMovement.me.transform.position + (PlayerMovement.me.transform.forward * 2), 0.15f);
    }

    public void SetAutoCamera()
    {
        minDistance = Mathf.Infinity;
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i].myScript.canSeePlayer)
            {
                cameras[i].distanceToPlayer = Mathf.Abs(Vector3.Distance(this.transform.position, cameras[i].myCam.transform.position));
                minDistance = Mathf.Min(cameras[i].distanceToPlayer, minDistance);
            }
            else
            {
                
            }
        }

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i].distanceToPlayer == minDistance)
            {
                cameras[i].myCam.enabled = true;
                ChangeCamera(cameras[i].myCam);
            }
            else if (minDistance != Mathf.Infinity)
            {
                cameras[i].myCam.enabled = false;
            }
        }
    }

    public void ChangeCamera(Camera newCam)
    {
        if (newCam != currentCam && !kill)
        {
            currentCam.enabled = false;
            newCam.enabled = true;
            newCam.targetTexture = rT;
            currentCam = newCam;
        }
    }

    public void InitCam(Camera newCam)
    {
        newCam.enabled = true;
        newCam.targetTexture = rT;
        currentCam = newCam;
    }

    void StaticMe()
    {
        me = this;
    }

    public void Kill()
    {
        kill = true;
    }


    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "CameraTrigger")
        {
            inCamTrigger = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "CameraTrigger")
        {
            inCamTrigger = false;
        }
    }

}

[System.Serializable]
public struct CameraInfo
{
    public Camera myCam;
    public AutoCam myScript;
    public float distanceToPlayer;
}

