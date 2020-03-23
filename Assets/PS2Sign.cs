using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS2Sign : MonoBehaviour
{
    // Start is called before the first frame update

    SpriteRenderer sprRend;
    public Sprite spr;

    int timer;

    bool on;

    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            sprRend.sprite = spr;
        }
        else
        {
            sprRend.sprite = null;
        }
    }

    void FixedUpdate()
    {
        timer++;
        if(timer > 40)
        {
            int randomChance = Random.Range(0, 10);
            if(randomChance > 5)
            {
                if(on)
                {
                    on = false;
                }
                else
                {
                    on = true;
                }
            }
        }
    }
}
