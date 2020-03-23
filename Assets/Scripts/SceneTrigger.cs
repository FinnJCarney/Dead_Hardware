using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public int newState;
    public string newScene;

    public int altState;

    public bool initDoorway;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameManager.me.SceneChange(newScene);
            if (!initDoorway || (initDoorway && !GameManager.me.MemoriesComplete))
            {
                GameManager.me.stateTracker = newState;
                
            }
            else
            {
                GameManager.me.stateTracker = altState;
            }
        }
    }
}
