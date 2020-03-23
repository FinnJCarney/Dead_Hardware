using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryController : MonoBehaviour
{
    public int timer;

    public TextMesh tm;
    public string[] words;

    public GameObject cords;

    public int timerStop;

    public float speed;
    public float offset;
    public float scale;

    public int doorwayInt;

    public int memoryNumber;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].Replace("\\n", "\n");
        }

        if(GameManager.me.Memory1)
        {
            memoryNumber++;
        }

        if (GameManager.me.Memory2)
        {
            memoryNumber++;
        }

        if (GameManager.me.Memory3)
        {
            memoryNumber++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        timer++;

        if(timer < timerStop)
        {
            tm.text = words[0];
        }
        if(timer > timerStop * 2)
        {

            tm.text = words[1];
        }
        if(timer > timerStop * 3)
        {
            tm.text = words[2];
        }
        if(timer > timerStop * 4)
        {
            tm.text = words[3];
        }
        if(timer > timerStop * 6)
        {
            tm.text = null;
            cords.transform.position += Vector3.up * speed;
            speed += offset;
            cords.transform.localScale *= scale;
        }
        if(timer > timerStop * 8)
        {
            if(memoryNumber == 0)
            {
                tm.text = "Thank you, traveller \n Only two more doorways to find";
            }

            if (memoryNumber == 1)
            {
                tm.text = "Thank you, traveller \n Only one more memory to restore";
            }

            if (memoryNumber == 2)
            {
                tm.text = "Thank you, traveller \n Return to whence you came. You have saved us";
            }
        }
        if(timer > timerStop * 12)
        {
            if (doorwayInt == 3)
            {
                GameManager.me.Memory1 = true;
            }
            if (doorwayInt == 4)
            {
                GameManager.me.Memory2 = true;
            }
            if (doorwayInt == 5)
            {
                GameManager.me.Memory3 = true;
            }
            GameManager.me.stateTracker = doorwayInt;
            GameManager.me.SceneChange("Tower_Streets");
        }
    }
}
