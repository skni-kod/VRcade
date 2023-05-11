using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenClick : MonoBehaviour
{
    [SerializeField]
    DHVRMachine machine;
    Ray dr;
    // Start is called before the first frame update
    void Start()
    {
        dr = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.
        Debug.DrawRay(dr.origin, dr.direction * 100, Color.blue);
    }

    public void OnSelect(InputValue value)
    {
        if(!value.isPressed) return;

        RaycastHit hit;
        Ray r = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        dr = r;
        if (Physics.Raycast(r, out hit))
        {
            //check if we actually hit this screen.
            if(hit.transform == transform)
            {
                //here we might want to add some more stuff, so for now it sits.
                if (machine == null || machine.minigameCamera == null) return;
               
                Ray mr = machine.minigameCamera.ViewportPointToRay(hit.textureCoord);
                Transform hitObject = Physics2D.Raycast(mr.origin, mr.direction).transform;
                
                if(hitObject != null && hitObject.CompareTag("Duck"))
                    hitObject.transform.GetComponent<MachineDuckController>().HitDuck();
            }
        }
    }
}
