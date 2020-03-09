using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoriesManager : MonoBehaviour
{
    public static MemoriesManager me;

    public GameObject Memories1;
    public GameObject Memories2;
    public GameObject Memories3;

    // Start is called before the first frame update
    private void Awake()
    {
        me = this;
    }

    void Start()
    {
        GameManager.me.CheckMemories();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
