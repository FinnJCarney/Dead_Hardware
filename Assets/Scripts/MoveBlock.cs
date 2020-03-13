using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public bool move;
    public float moveAmount;
    public AudioSource aS;
    bool played;

    void Start()
    {
        aS = GetComponent<AudioSource>();
        if(GameManager.me.stateTracker > 0)
        {
            transform.position += new Vector3(0, moveAmount, 0);
            moveAmount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(move && (moveAmount > 0))
        {
            moveAmount -= 0.025f;
            transform.position += new Vector3(0, 0.025f, 0);
        }
        if(moveAmount <= 0 && !played)
        {
            aS.Play();
            played = true;
        }
    }
}
