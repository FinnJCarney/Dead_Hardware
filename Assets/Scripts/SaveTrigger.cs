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

    public AudioSource as1;
    public AudioSource as2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerIn && Input.GetKeyDown(KeyCode.X))
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

        if (!GameManager.me.MemoriesComplete)
        {
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
                as1.Stop();
                as2.Stop();
                PlayerMovement.me.transform.position = playerEndPos;
                PlayerMovement.me.transform.eulerAngles = Vector3.zero;
            }
            if (time > 450)
            {
                mb.move = true;
            }
        }
        else
        {
            if(time > 0 && time < 120)
            {
                tm.text = texts[0];
            }
            if (time > 120 && time < 240)
            {
                tm.text = texts[3];
            }
            if(time > 240 && time < 360)
            {
                tm.text = null;
            }
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
            tm.text = "Press X to Save";
            playerIn = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            tm.text = null;
            playerIn = false;
            if (GameManager.me.MemoriesComplete)
            {
                timer = false;
                time = 0;
            }
        }
    }
}
