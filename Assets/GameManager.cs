using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager me;
    // Start is called before the first frame update
    public Scene nextScene;
    public string loadScene;

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

    public void SceneChange(Scene newScene)
    {
        nextScene = newScene;
        SceneManager.LoadScene("loadScene");
    }
}
