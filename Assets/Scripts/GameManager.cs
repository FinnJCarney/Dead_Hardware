using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager me;
    // Start is called before the first frame update
    public string nextScene;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        me = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange(string newScene)
    {
        nextScene = newScene;
        SceneManager.LoadScene("LoadingScreen");
    }
}
