using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshScript : MonoBehaviour
{
    TextMesh tm;

    public Font ft1;
    public Font ft2;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = tm.text.Replace("\\n", "\n");
    }

    public void ChangeFont(int i)
    {
        if(i == 1)
        {
            tm.font = ft1;
        }
        else
        {
            tm.font = ft2;
        }
    }
}
