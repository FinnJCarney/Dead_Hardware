﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillScript : MonoBehaviour
{
    public PlayerMovement pm;
    public MonsterScript ms;
    public MonsterAnimation ma;
    public GameManager gm;
    public CameraController cc;

    public bool dead;
    public int timer;
    public Camera cam;

    void Start()
    {
        pm = PlayerMovement.me;
        ms = MonsterScript.me;
        ma = MonsterAnimation.me;
        gm = GameManager.me;
        cc = CameraController.me;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(dead)
        {
            if (timer < 0)
            {
                cc.Kill();
                gm.Kill();
            }
            else
            {
                timer--;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            dead = true;
            pm.Kill();
            ms.Kill();
            ma.Kill();           
        }
    }
}
