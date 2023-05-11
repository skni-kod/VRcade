using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardRay : MonoBehaviour
{
    public Transform attachPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(attachPoint.position, attachPoint.forward * 20.0f);
    }
}
