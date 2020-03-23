using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SManager : MonoBehaviour
{
    public states[] states;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < states.Length; i++)
        {
            if(GameManager.me.stateTracker == states[i].state)
            {
                PlayerMovement.me.transform.position = states[i].pos;
                PlayerMovement.me.transform.eulerAngles = states[i].rot;
                CameraController.me.InitCam(states[i].cam);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public struct states
{
    public Camera cam;
    public int state;
    public Vector3 pos;
    public Vector3 rot;

}

