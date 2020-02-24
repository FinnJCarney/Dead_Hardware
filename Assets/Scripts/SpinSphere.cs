using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSphere : MonoBehaviour
{
    public Vector3 rotSpeed;
    public Vector3 rotAcc;

    public Vector3 accContoller;

    // Start is called before the first frame update
    void Start()
    {
        ///accContoller = new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
        rotSpeed = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotSpeed);

        rotSpeed += rotAcc;

        accContoller += Vector3.one;
        rotAcc.x = (Mathf.Sin((accContoller.x * Mathf.PI) / 180)) / 25;
        rotAcc.y = (Mathf.Sin(((accContoller.y + 90 )* Mathf.PI) / 180)) / 25;
        rotAcc.z = (Mathf.Sin(((accContoller.z - 90) * Mathf.PI) / 180)) / 25;
    }
}
