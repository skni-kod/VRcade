using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DHMinigameController : MonoBehaviour
{
    [SerializeField]
    AreaPointGenerator duckFlyingArea;
    [SerializeField]
    AreaPointGenerator duckSpawnArea;
    [SerializeField]
    MachineDuckController duckPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            MachineDuckController duck = Instantiate(duckPrefab);
            duck.target = duckFlyingArea.GetPoint();
            duck.duckFlyingArea = duckFlyingArea;
            duck.transform.position = duckSpawnArea.GetPoint();
            duck.ready = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
