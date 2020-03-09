using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainWater : MonoBehaviour
{

    int timer;

    public Vector3 vertSpeed;
    public float vertAcc;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0, 360);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        timer++;

        vertSpeed.y = Mathf.Sin((timer * Mathf.PI / 180)) / 50;

        //vertSpeed.y += vertAcc;
        transform.position += vertSpeed;
    }
}
