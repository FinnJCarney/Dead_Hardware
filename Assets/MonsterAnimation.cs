using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{
    public GameObject LeftSpinner;
    public GameObject FLLeg;
    public GameObject BLLeg;

    public GameObject RightSpinner;
    public GameObject FRLeg;
    public GameObject BRLeg;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        LeftSpinner.transform.Rotate(-2, 0, 0);
        FLLeg.transform.eulerAngles = Vector3.zero;
        BLLeg.transform.eulerAngles = Vector3.zero;

        RightSpinner.transform.Rotate(-2, 0, 0);
        FRLeg.transform.eulerAngles = Vector3.zero;
        BRLeg.transform.eulerAngles = Vector3.zero;
    }
}
