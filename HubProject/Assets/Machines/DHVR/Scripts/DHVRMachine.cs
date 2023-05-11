using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DHVRMachine : MonoBehaviour
{
    AsyncOperation loadingScene;
    
    public Camera minigameCamera = null;
    // Start is called before the first frame update
    void Start()
    {
        loadingScene = SceneManager.LoadSceneAsync("DHMinigameScene", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        if(loadingScene.isDone)
        {
            minigameCamera = GameObject.Find("DH_CAM").GetComponent<Camera>();
        }
    }
}
