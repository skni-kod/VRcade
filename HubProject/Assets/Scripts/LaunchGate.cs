using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGate : MonoBehaviour
{
    //path to game exectuable for example: /Games/Game1/Game.exe
    public string appToLaunch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //If collided object has tag LaunchCube start loading application.
        if (other.CompareTag("LaunchCube"))
        {
            SystemManager.LoadApp(appToLaunch);
        }
    }
}
