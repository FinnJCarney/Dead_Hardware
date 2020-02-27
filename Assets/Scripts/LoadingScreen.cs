using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public int loadBars;
    public MeshRenderer[] loadingBarsMR;

    public Material loaded;

    public float rotSpeed;
    public float spdController;

    void Awake()
    {

    }
    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < loadingBarsMR.Length; i++)
        {
            if (i <= loadBars)
            {
                loadingBarsMR[i].material = loaded;
            }
        }

        if(loadBars >= 9)
        {
            ChangeScene();
        }
    }

    void FixedUpdate()
    {
        spdController++;
        rotSpeed = Mathf.Sin((spdController / 180) * Mathf.PI) / 4;

        transform.Rotate(0, rotSpeed, 0);

        int randomChance = Random.Range(0, 100);
        if(randomChance > 95)
        {
            loadBars += 1;
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(GameManager.me.nextScene);
    }
}
