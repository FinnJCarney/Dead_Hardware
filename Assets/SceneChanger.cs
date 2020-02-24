using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Scene newScene;

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
        //if (col.gameObject.tag == "Player")
        //{
        //    GameManager.me.SceneChange(newScene);
        //}
        SceneManager.LoadScene("Tower_Entrance");
    }
}
