using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public bool move;
    public float moveAmount;

    void Start()
    {
        
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
            transform.position -= new Vector3(0, -0.025f, 0);
        }
    }
}
