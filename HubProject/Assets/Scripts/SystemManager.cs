using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

/**
 * Class used for handling most of the OS logic for VRcade HUB. Loads settings from specified location and launches games.
 */
public class SystemManager : MonoBehaviour
{
    public static SystemManager Instance { get; protected set;}


    private static bool isLaunchingApp = false;

    public static VRcadeSettings globalSettings;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            UnityEngine.Debug.Log(Application.dataPath + "/../../Settings/vrcade.json");
            using (StreamReader r = new StreamReader(Application.dataPath + "/../../Settings/vrcade.json"))
            {
                string json = r.ReadToEnd();
                globalSettings = JsonUtility.FromJson<VRcadeSettings>(json);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Load specified app from {VRcadeInstallPath}/path and call Quit to close Hub.
     * @param path Path to game exectuable to be launched.
     */
    public static void LoadApp(string path)
    {
        if(!isLaunchingApp)
        {
            isLaunchingApp = true;

#if UNITY_EDITOR
            UnityEngine.Debug.Log("ShouldLaunch:" + globalSettings.VrcadeInstallPath + path);
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Debug.Log("ShouldLaunch:" + globalSettings.VrcadeInstallPath + path);            
            Process.Start(globalSettings.VrcadeInstallPath + path);            
            Application.Quit();
#endif
            //Add logic to switch to other app when ready
        }
    }
}
