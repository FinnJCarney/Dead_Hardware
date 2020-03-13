using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouldSpinner : MonoBehaviour
{

    public Vector3 rotOffset;

    // Start is called before the first frame update
    void Start()
    {
        rotOffset.y = Random.Range(-1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(rotOffset.y) < 0.1f)
        {
            rotOffset.y = Random.Range(-1.5f, 1.5f);
        }
    }

    private void FixedUpdate()
    {
        transform.eulerAngles += rotOffset;
    }
}
