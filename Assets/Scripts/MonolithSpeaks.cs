using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolithSpeaks : MonoBehaviour
{
    public bool start;
    public bool mid;
    public bool end;

    public string[] startWords;
    public string midWords;
    public string[] endWords;

    public int wordState;

    public TextMesh tm;

    bool noMove;
    bool inTrig;

    float sprintStore;
    float baseStore;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (inTrig && Input.GetKeyDown(KeyCode.X))
        {
            wordState++;
        }

        if(start)
        {
            if(wordState > startWords.Length)
            {
                tm.text = null;
                AllowMovement();
            }
            else
            {
                tm.text = startWords[wordState];
            }
        }

        if (mid)
        {
            if (wordState >= 1)
            {
                tm.text = null;
                AllowMovement();
            }
            else
            {
                tm.text = midWords;
            }
        }

        if (end)
        {
            if (wordState > endWords.Length)
            {
                tm.text = null;
                AllowMovement();
            }
            else
            {
                tm.text = endWords[wordState];
            }
        }

        tm.text = tm.text.Replace("0", "\n");

        tm.text = tm.text.Replace("9", "...");
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            inTrig = true;
            StopMovement();
            if(!GameManager.me.MemoriesComplete)
            {
                if (!GameManager.me.Memory1 && !GameManager.me.Memory2 && !GameManager.me.Memory3)
                {
                    start = true;
                }
                else
                {
                    mid = true;
                }
            }
            else
            {
                end = true;
            }
        }
    }

    void StopMovement()
    {
        sprintStore = PlayerMovement.me.sprintSpeed;
        baseStore = PlayerMovement.me.moveSpeed;
        PlayerMovement.me.sprintSpeed = 0;
        PlayerMovement.me.baseSpeed = 0;
    }

    void AllowMovement()
    {
        PlayerMovement.me.sprintSpeed = sprintStore;
        PlayerMovement.me.baseSpeed = baseStore;
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            inTrig = false;
        }
    }
}
