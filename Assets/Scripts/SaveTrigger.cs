using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : MonoBehaviour
{

    public TextMesh tm;
    public bool playerIn;

    public string[] texts;

    bool timer;
    int time;

    public Vector3 playerEndPos;

    public MoveBlock mb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerIn && Input.GetKeyDown(KeyCode.F))
        {
            SaveTeleporter();
            if(GameManager.me.stateTracker == 0)
            {
                GameManager.me.stateTracker = 1;
            }
        }
    }

    void FixedUpdate()
    {
        if (timer)
        {
            time++;
        }

        if (time > 0 && time < 120)
        {
            tm.text = texts[0];
        }
        if (time > 120 && time < 240)
        {
            tm.text = texts[1];
        }
        if (time > 240 && time < 360)
        {
            tm.text = texts[2];
        }
        if (time > 360 && time < 420)
        {
            PlayerMovement.me.transform.position = playerEndPos;
            PlayerMovement.me.transform.eulerAngles = Vector3.zero;
        }
        if (time > 420)
        {
            mb.move = true;
        }
    }

    void SaveTeleporter()
    {
        timer = true;
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            tm.text = "Press F to Save";
            playerIn = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            tm.text = null;
            playerIn = false;
        }
    }
}
