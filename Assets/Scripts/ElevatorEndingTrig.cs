using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorEndingTrig : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;

    public TextMesh tm;
    public TextMeshScript tms;
    public string words;
    public float vertSpeed;

    public bool changeFont;
    public bool changePos;
    public Vector3 pos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerMovement.me.Ending(vertSpeed);
            tm.text = words;
            if (changePos)
            {
                tm.transform.position = cam.transform.position + pos;
            }
            //if(changeFont)
            //{
            //    tms.ChangeFont(2);
            //}
        }
    }
}
