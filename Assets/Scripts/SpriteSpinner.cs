using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpinner : MonoBehaviour
{
    float spin;
    // Start is called before the first frame update
    void Start()
    {
        spin = Random.Range(-2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * spin );
    }
}
