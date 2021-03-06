﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager me;
    // Start is called before the first frame update
    public string nextScene;

    public int stateTracker;

    public bool Memory1;
    public bool Memory2;
    public bool Memory3;

    public bool dead;
    public int timer;

    public bool MemoriesComplete;

    public AudioSource aS;

    private void Awake()
    {
        if(me != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            me = this;
        }

        
    }
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dead)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                SceneChange("Tower_Streets");
            }
        }
    }

    public void SceneChange(string newScene)
    {
        nextScene = newScene;
        SceneManager.LoadScene("LoadingScreen");
    }

    public void CheckMemories()
    { 
        if(Memory1)
        {
            Destroy(MemoriesManager.me.Memories1);
        }
        if (Memory2)
        {
            Destroy(MemoriesManager.me.Memories2);
        }
        if (Memory3)
        {
            Destroy(MemoriesManager.me.Memories3);
        }

        if(Memory1 && Memory2 && Memory3)
        {
            MemoriesComplete = true;
        }
    }

    public void Kill()
    {
        dead = true;
    }

}
