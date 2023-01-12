using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGate : MonoBehaviour
{
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
        if (other.CompareTag("LaunchCube"))
        {
            SystemManager.LoadApp(appToLaunch);
        }
    }
}
